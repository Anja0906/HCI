using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using HelpSistem;

namespace HCI_big_project.view
{
    public partial class NewAccommodationWindow : Window, INotifyPropertyChanged
    {
        public Accommodation Accommodation { get; set; }
        private User _user;
        public ObservableCollection<string> Images { get; } = new ObservableCollection<string>
        {
            "../res/logo.png",
            "../res/mapPin.png",
            "../res/searchIcon.png",
        };
        public event PropertyChangedEventHandler PropertyChanged;

        private string selectedImage;
        private Location location;
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
        public NewAccommodationWindow(User user)
        {
            _user = user;
            Accommodation = new Accommodation();
            location = new Location();
            DataContext = this;
            if (Images.Count > 0)
            {
                SelectedImage = Images[0];
            }
            InitializeComponent();
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
            gmap.Position =  new PointLatLng(44.0165, 21.0059);

    
            GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultCredentials;
            
        }

        private void AddMarker(double lat, double lon)
        {
            GMapMarker marker = new GMapMarker(new PointLatLng(lat, lon));
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("pack://application:,,,/res/mapPin.png");
            bi.EndInit();
            Image pinImage = new Image();
            pinImage.Source = bi;
            pinImage.Width = 50; // Adjust as needed
            pinImage.Height = 50; // Adjust as needed
            
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

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string helpKey = "UrediHotel";
            HelpProvider.ShowHelp(helpKey, this);
        }

        private void Confirm_OnClick(object sender, RoutedEventArgs e)
        {
            if (Accommodation.Address != null)
            {
                if (NameInput.Text.Length==0)
                {
                    CustomDialogWindow.Show("Morate uneti naziv smestaja!");
                }
                else if (NameInput.Text.Length>30)
                {
                    CustomDialogWindow.Show("Naziv smestaja sadrzi previse karaktera!");
                }
                else if (AddressInput.Text.Length==0)
                {
                    CustomDialogWindow.Show("Morate uneti adresu smestaja!");
                }
                else if (AddressInput.Text.Length>30)
                {
                    CustomDialogWindow.Show("Adresa smestaja sadrzi previse karaktera!");
                }
                else if (CaptionInput.Text.Length==0)
                {
                    CustomDialogWindow.Show("Morate uneti opis smestaja!");
                }
                else if (CaptionInput.Text.Length>100)
                {
                    CustomDialogWindow.Show("Opis smestaja sadrzi previse karaktera!");
                }
                else if (RatingInput.Text.Length==0)
                {
                    CustomDialogWindow.Show("Morate uneti ocenu smestaja!");
                }
                else if (LinkInput.Text.Length==0)
                {
                    CustomDialogWindow.Show("Morate uneti link do smestaja!");
                }
                else if (LinkInput.Text.Length>30)
                {
                    CustomDialogWindow.Show("Link do stranice smestaja sadrzi previse karaktera!");
                }
                else
                {
                    CustomYesNoDialog dialog = new CustomYesNoDialog("Da li ste sigurni da želite da dodate uneti smestaj?");
                    bool? result = dialog.ShowDialog();

                    if (result == true)
                    {
                        
                        Random random = new Random();
                        Accommodation.Id = random.Next(9999);
                        Accommodation.Pictures = new List<Picture>();
                        AccomodationService accomodationService = new AccomodationService(new AccommodationRepository());
                        accomodationService.AddNewAccommodation(Accommodation);
                        AccomodationsWindow accomodations = new AccomodationsWindow(_user);
                        accomodations.Show();
                        this.Hide();
                
                    }
                    else
                    {
                        AccomodationsWindow accomodationsWindow = new AccomodationsWindow(_user);
                        accomodationsWindow.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                CustomDialogWindow.Show("Morate uneti lokaciju smestaja. Desim klikom na mapi oznacite lokaciju!");
            }
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            CustomYesNoDialog dialog = new CustomYesNoDialog("Da li ste sigurni da želite da odustanete od dodavanja smestaja? ");
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                AttractionsWindow attractionsWindow = new AttractionsWindow(_user);
                attractionsWindow.Show();
                this.Hide();
            }
            else
            {
                // No was clicked, do something else
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";
    
            if (openFileDialog.ShowDialog() == true)
            {
                Image myImage = new Image();
                var filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                var bitmap = new BitmapImage(new Uri(filePath, UriKind.Absolute));
                myImage.Source = bitmap;
                Images.Add(filePath);
                Console.WriteLine(filePath);
            }
        }

        private void Gmap_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                Point clickLocation = e.GetPosition(gmap);
                PointLatLng point = gmap.FromLocalToLatLng((int)clickLocation.X, (int)clickLocation.Y);
                if (gmap.Markers.Count>0)
                {
                    gmap.Markers.Clear();
                }

                CustomYesNoDialog dialog = new CustomYesNoDialog("Da li želite da dodate smestaj na sledece koordinate:  Lat: " + point.Lat + ", Lng: " + point.Lng);
                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    location = new Location(point.Lat, point.Lng, "Neka adresa");
                    AddMarker(point.Lat, point.Lng);
                    Accommodation.Address = location;
                }
                else
                {
                    // No was clicked, do something else
                }
            }
            
        }
    }
}