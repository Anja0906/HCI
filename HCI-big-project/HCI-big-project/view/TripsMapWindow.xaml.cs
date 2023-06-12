using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using HCI_big_project.model;
using HCI_big_project.repository;
using HCI_big_project.service;

namespace HCI_big_project.view
{
    public partial class TripsMapWindow : Window
    {
        private User _user;
        private List<Trip> _trips;
        private TripService _tripService;
        public TripsMapWindow(User user)
        {
            _user = user;
            _tripService = new TripService(new TripRepository());
            _trips = _tripService.GetOfferedTrips();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Menu.SetUserRole(_user);
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

            List<Location> pins = InitPins();
            foreach (Location pin in pins)
            {
                SetPin(pin);
            }
        }

        private List<Location> InitPins()
        {
            List<Location> pins = new List<Location>();
            foreach (Trip trip in _trips)
            {
                foreach (Accommodation accommodation in trip.Accommodations)
                {
                    pins.Add(accommodation.Address);
                }

                foreach (Attraction attraction in trip.Attractions)
                {
                    pins.Add(attraction.Address);
                }
                foreach (Restaurant restaurant in trip.Restaurants)
                {
                    pins.Add(restaurant.Address);
                }
            }

            return pins;
        }

        private void SetPin(Location pin)
        {
            GMapMarker marker = new GMapMarker(new PointLatLng(pin.Latitude, pin.Longitude));
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("pack://application:,,,/res/mapPin.png");
            bi.EndInit();
            Image pinImage = new Image();
            pinImage.Source = bi;
            pinImage.Width = 50;
            pinImage.Height = 50; 
            pinImage.ToolTip = pin.Address;
            
            ToolTipService.SetShowDuration(pinImage, Int32.MaxValue);
            ToolTipService.SetInitialShowDelay(pinImage, 0);
            marker.Shape = pinImage;
            gmap.Markers.Add(marker);
        }

        private void MapControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                gmap.Zoom = (gmap.Zoom < gmap.MaxZoom) ? gmap.Zoom + 1 : gmap.MaxZoom;
            }
        }
    }
}