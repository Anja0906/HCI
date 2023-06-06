using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GMap.NET;
using GMap.NET.MapProviders;
using HCI_big_project.model;
using HCI_big_project.repository;
using HCI_big_project.service;
using HCI_big_project.userControls;

namespace HCI_big_project.view
{
    public partial class TripsWindow : Window
    {
        private User _user;
        public List<Trip> Trips = new List<Trip>();
        private TripService _tripService = new TripService(new TripRepository());
        public TripsWindow( User user)
        {
            _user = user;
            Trips = _tripService.GetOfferedTrips();
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Menu.SetUserRole(_user);
            foreach (Trip trip in Trips)
            {
                Panel.Children.Add(new Card(trip));
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
            gmap.Zoom = 7;
            gmap.ShowCenter = false;
    
            gmap.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(44.0165, 21.0059);
    
            GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultCredentials;
    
            // foreach (Location l in AttractionsLocations)
            // {
            //     GMapMarker marker = new GMapMarker(new PointLatLng(l.Latitude, l.Longitude));
            //     BitmapImage bi = new BitmapImage();
            //     bi.BeginInit();
            //     bi.UriSource = new Uri("pack://application:,,,/Images/redPin.png");
            //     bi.EndInit();
            //     Image pinImage = new Image();
            //     pinImage.Source = bi;
            //     pinImage.Width = 50; // Adjust as needed
            //     pinImage.Height = 50; // Adjust as needed
            //     pinImage.ToolTip = l.Address + " " + l.City;
            //
            //     ToolTipService.SetShowDuration(pinImage, Int32.MaxValue);
            //     ToolTipService.SetInitialShowDelay(pinImage, 0);
            //     marker.Shape = pinImage;
            //     gmap.Markers.Add(marker);
            // }
        }

        private void MapControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                gmap.Zoom = (gmap.Zoom < gmap.MaxZoom) ? gmap.Zoom + 1 : gmap.MaxZoom;
            }
        }
        
        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Code to handle text change in the search bar
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            // Code to handle search button click
        }

        private void AddTrip_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                NewTripWindow newTripWindow = new NewTripWindow(_user);
                newTripWindow.Show();
                this.Hide();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            
        }
    }
}