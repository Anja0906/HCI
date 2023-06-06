using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using HCI_big_project.model;

namespace HCI_big_project.view
{
    public partial class RestaurantDetailsWindow : Window, INotifyPropertyChanged
    {
        public RestaurantDetailsWindow(Restaurant restaurant, User user)
        {
            Restaurant = restaurant;
            _user = user;
            DataContext = this;
            InitializeComponent();
        }
        public Restaurant Restaurant { get; set; }
        private User _user;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> Images { get; } = new ObservableCollection<string>
        {
            "../res/logo.png",
            "../res/mapPin.png",
            "../res/searchIcon.png",
        };

        private string selectedImage;
        public string SelectedImage
        {
            get { return selectedImage; }
            set
            {
                if (selectedImage != value)
                {
                    selectedImage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedImage)));
                }
            }
        }

        private void Window_OnLoaded(object sender, RoutedEventArgs e)
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
            gmap.Zoom = 11;
            gmap.ShowCenter = false;
    
            gmap.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(this.Restaurant.Address.Latitude, Restaurant.Address.Longitude);

    
            GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultCredentials;
    
            GMapMarker marker = new GMapMarker(new PointLatLng(this.Restaurant.Address.Latitude, Restaurant.Address.Longitude));
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("pack://application:,,,/res/mapPin.png");
            bi.EndInit();
            Image pinImage = new Image();
            pinImage.Source = bi;
            pinImage.Width = 50; // Adjust as needed
            pinImage.Height = 50; // Adjust as needed
            pinImage.ToolTip = Restaurant.Address.Address;
            
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

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void Update_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}