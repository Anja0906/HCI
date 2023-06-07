using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HCI_big_project.model;
using System.Windows.Media.Imaging;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using HCI_big_project.repository;
using HCI_big_project.service;

namespace HCI_big_project.view
{
    public partial class TripDetailsWindow : Window
    {
        private User _user;
        public Trip Trip { get; set; }
        public ObservableCollection<Accommodation> Accommodations { get; set; }
        public ObservableCollection<Attraction> Attractions { get; set; }
        public ObservableCollection<Restaurant> Restaurants { get; set; }
        public TripDetailsWindow(Trip trip, User user)
        {
            Trip = trip;
            Accommodations = new ObservableCollection<Accommodation>(trip.Accommodations);
            Attractions = new ObservableCollection<Attraction>(trip.Attractions);
            Restaurants = new ObservableCollection<Restaurant>(trip.Restaurants);
            _user = user;
            DataContext = this;
            InitializeComponent();
        }

        private void Window_OnLoaded(object sender, RoutedEventArgs e)
        {
            Menu.SetUserRole(_user);
        }

        private void MapControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                gmap.Zoom = (gmap.Zoom < gmap.MaxZoom) ? gmap.Zoom + 1 : gmap.MaxZoom;
            }
        }

        private void map_load(object sender, RoutedEventArgs e)
        {
            gmap.Bearing = 0;
            gmap.CanDragMap = true;
            gmap.DragButton = MouseButton.Left;
            gmap.MaxZoom = 18;
            gmap.MinZoom = 2;
            gmap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
    
            gmap.ShowTileGridLines = false;
            gmap.Zoom = 11;
            gmap.ShowCenter = false;
    
            gmap.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(this.Trip.Beginning.Latitude, Trip.Beginning.Longitude);

    
            GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultCredentials;
    
        }

        private void ListBox_Click(object sender, RoutedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            var selectedItem = listBox.SelectedItem;
            if (selectedItem is Attraction attraction)
            {
                AttractionDetailsWindow attractionDetailsWindow = new AttractionDetailsWindow(attraction, _user);
                attractionDetailsWindow.Show();
            }
            else if(selectedItem is Accommodation accommodation)
            {
                AccomodationDetailsWidow accomodationDetailsWidow = new AccomodationDetailsWidow(accommodation, _user);
                accomodationDetailsWidow.Show();
            }
            else if(selectedItem is Restaurant restaurant)
            {
                RestaurantDetailsWindow restaurantDetailsWindow = new RestaurantDetailsWindow(restaurant, _user);
                restaurantDetailsWindow.Show();
            }
        }

        private void Update_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            CustomYesNoDialog dialog = new CustomYesNoDialog("Da li ste sigurni da želite da obrišete putovanje: " + Trip.Name + " ?");
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                TripService tripService = new TripService(new TripRepository());
                tripService.DeleteTripById(Trip.Id);
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null) parentWindow.Close();
                TripsWindow newWindow = new TripsWindow(_user);
                newWindow.Show();
            }
            else
            {
                // No was clicked, do something else
            }
        }
    }
}