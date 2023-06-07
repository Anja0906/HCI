using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using HCI_big_project.model;
using System.Windows.Media.Imaging;
using HCI_big_project.repository;
using HCI_big_project.service;
using HCI_big_project.view;

namespace HCI_big_project.userControls
{
    public partial class Card : UserControl
    {
        private Trip _trip;
        private User _user;
        public Card(Trip trip, User user)
        {
            _trip = trip;
            _user = user;
            this.DataContext = _trip;
            InitializeComponent();
        }

        private void Card_OnLoaded(object sender, RoutedEventArgs e)
        {
            NameLabel.Text += _trip.Name;
            DescriptionLabel.Text += _trip.Caption;
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
    
            // foreach (Attraction attraction in _trip.Attractions)
            // {
            //     GMapMarker marker = new GMapMarker(new PointLatLng(attraction.Address.Latitude, attraction.Address.Longitude));
            //     BitmapImage bi = new BitmapImage();
            //     bi.BeginInit();
            //     bi.UriSource = new Uri("pack://application:,,,/Images/redPin.png");
            //     bi.EndInit();
            //     Image pinImage = new Image();
            //     pinImage.Source = bi;
            //     pinImage.Width = 50; // Adjust as needed
            //     pinImage.Height = 50; // Adjust as needed
            //     pinImage.ToolTip = attraction.Address;
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


        private void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonBase2_OnClick(object sender, RoutedEventArgs e)
        {
            CustomYesNoDialog dialog = new CustomYesNoDialog("Da li ste sigurni da želite da obrišete putovanje: " + _trip.Name + " ?");
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                TripService tripService = new TripService(new TripRepository());
                tripService.DeleteTripById(_trip.Id);
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null) parentWindow.Close();
                //TODO ubaciti ulogovanog korisnika
                TripsWindow newWindow = new TripsWindow(new User("Anja", "Pi", "anja", "anja", DateTime.Now, Role.Administrator));
                newWindow.Show();
            }
            else
            {
                // No was clicked, do something else
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            TripDetailsWindow tripDetailsWindow = new TripDetailsWindow(_trip, _user);
            tripDetailsWindow.Show();
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null) parentWindow.Close();
        }
    }
}