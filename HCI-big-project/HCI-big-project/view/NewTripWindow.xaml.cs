using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GMap.NET;
using GMap.NET.MapProviders;
using HCI_big_project.model;
using HCI_big_project.repository;
using HCI_big_project.service;

namespace HCI_big_project.view
{
    public partial class NewTripWindow : Window
    {
        private User _user;

        private AccomodationService _accomodationService;
        private AttractionService _attractionService;
        private RestaurantService _restaurantService;
        
        public NewTripWindow(User user)
        {
            _user = user;
            InitializeComponent();
            this.DataContext = this;
            InitListBoxes();
        }

        private void InitListBoxes()
        {
            _accomodationService = new AccomodationService(new AccommodationRepository());
            foreach (Accommodation accomodation in _accomodationService.GetAll())
            {
                AllAccommodationsListBox.Items.Add(accomodation);
            }

            _attractionService = new AttractionService(new AttractionRepository());
            foreach (Attraction attraction in _attractionService.GetAll())
            {
                AllAttractionListBox.Items.Add(attraction);
            }

            _restaurantService = new RestaurantService(new RestaurantRepository());
            foreach (Restaurant restaurant in _restaurantService.GetAll())
            {
                AllRestaurantsListBox.Items.Add(restaurant);
            }
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
        
        private void NextButton1_Click(object sender, RoutedEventArgs e)
        {
            Step1.Visibility = Visibility.Collapsed;
            Step2.Visibility = Visibility.Visible;

            // Update progress
            StepLabel.Content = "Korak 2 od 4";
            StepProgressBar.Value = 2;
        }

        private void BackButton2_Click(object sender, RoutedEventArgs e)
        {
            Step2.Visibility = Visibility.Collapsed;
            Step1.Visibility = Visibility.Visible;

            // Update progress
            StepLabel.Content = "Korak 1 od 4";
            StepProgressBar.Value = 1;
        }

        private void NextButton2_Click(object sender, RoutedEventArgs e)
        {
            Step2.Visibility = Visibility.Collapsed;
            Step3.Visibility = Visibility.Visible;

            // Update progress
            StepLabel.Content = "Korak 3 od 4";
            StepProgressBar.Value = 3;
        }

        private void BackButton3_Click(object sender, RoutedEventArgs e)
        {
            Step3.Visibility = Visibility.Collapsed;
            Step2.Visibility = Visibility.Visible;

            // Update progress
            StepLabel.Content = "Korak 2 od 4";
            StepProgressBar.Value = 2;
        }

        // ...

        private void NextButton3_Click(object sender, RoutedEventArgs e)
        {
            Step3.Visibility = Visibility.Collapsed;
            Step4.Visibility = Visibility.Visible;

            // Update progress
            StepLabel.Content = "Korak 4 od 4";
            StepProgressBar.Value = 4;
        }

        private void BackButton4_Click(object sender, RoutedEventArgs e)
        {
            Step4.Visibility = Visibility.Collapsed;
            Step3.Visibility = Visibility.Visible;

            // Update progress
            StepLabel.Content = "Korak 3 od 4";
            StepProgressBar.Value = 3;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Done!");
        }

        private object draggedItem;
        private ListBox sourceListBox;

        private void SelectedItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            sourceListBox = listBox;
            draggedItem = listBox.SelectedItem;
        }

        private void MoveItem_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (e.LeftButton == MouseButtonState.Pressed && draggedItem != null)
            {
                DragDrop.DoDragDrop(listBox, draggedItem, DragDropEffects.Move);
            }
        }

        private void DragAccomodation_PreviewDragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(Accommodation)))
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void DragOverAccomodation_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(Accommodation))) 
            {
                e.Effects = DragDropEffects.None;
            }
            else
            {
                e.Effects = DragDropEffects.Move;
            }
            e.Handled = true;
        }

        private void DropAccomodation_PreviewDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Accommodation))) 
            {
                Accommodation draggedItem = e.Data.GetData(typeof(Accommodation)) as Accommodation; 
                ListBox listBox = sender as ListBox;
                listBox.Items.Add(draggedItem);
           
            
                if (sourceListBox.Items.Contains(this.draggedItem))
                {
                    sourceListBox.Items.Remove(draggedItem);
                }  
            
                e.Handled = true;
            }
        }
        
        private void DragAttraction_PreviewDragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(Attraction)))
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void DragOverAttraction_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(Attraction))) 
            {
                e.Effects = DragDropEffects.None;
            }
            else
            {
                e.Effects = DragDropEffects.Move;
            }
            e.Handled = true;
        }

        private void DropAttraction_PreviewDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Attraction))) 
            {
                Attraction draggedItem = e.Data.GetData(typeof(Attraction)) as Attraction; 
                ListBox listBox = sender as ListBox;
                listBox.Items.Add(draggedItem);
           
            
                if (sourceListBox.Items.Contains(this.draggedItem))
                {
                    sourceListBox.Items.Remove(draggedItem);
                }  
            
                e.Handled = true;
            }
        }
        
        private void DragRestaurant_PreviewDragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(Restaurant)))
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void DragOverRestaurant_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(Restaurant))) 
            {
                e.Effects = DragDropEffects.None;
            }
            else
            {
                e.Effects = DragDropEffects.Move;
            }
            e.Handled = true;
        }

        private void DropRestaurant_PreviewDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Restaurant))) 
            {
                Restaurant draggedItem = e.Data.GetData(typeof(Restaurant)) as Restaurant; 
                ListBox listBox = sender as ListBox;
                listBox.Items.Add(draggedItem);
           
            
                if (sourceListBox.Items.Contains(this.draggedItem))
                {
                    sourceListBox.Items.Remove(draggedItem);
                }  
            
                e.Handled = true;
            }
        }

        private void NextButton4_Click(object sender, RoutedEventArgs e)
        {
            CustomYesNoDialog dialog = new CustomYesNoDialog("Da li ste sigurni da želite da potvrdite dodavanje novog putovanja?" );
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                // dodaj novo
            }
            else
            {
                // No was clicked, do something else
            }
        }
    }
}