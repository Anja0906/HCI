using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using HCI_big_project.model;
using Location = HCI_big_project.model.Location;

namespace HCI_big_project.view
{
    public partial class AdminMainWindow : Window
    {
        private User _user;
        public AdminMainWindow(User user)
        {
            _user = user;
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
    }
}