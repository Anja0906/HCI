using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GMap.NET;
using GMap.NET.MapProviders;
using HCI_big_project.model;
using HCI_big_project.repository;
using HCI_big_project.service;
using HelpSistem;

namespace HCI_big_project.view
{
    public partial class NewTripWindow : Window
    {
        private User _user;

        private AccomodationService _accomodationService;
        private AttractionService _attractionService;
        private RestaurantService _restaurantService;
        private Trip Trip { get; set; }
        
        public NewTripWindow(User user)
        {
            _user = user;
            InitializeComponent();
            this.DataContext = this;
            Trip = new Trip();
            StepProgressBar.Value = 1;
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

            if (!ValidateStep1())
            {
                CustomDialogWindow.Show("Popunite sve podatke! Sva polja su obavezna!");
            }
            else
            {
                Step1.Visibility = Visibility.Collapsed;
                Step2.Visibility = Visibility.Visible;   
                StepLabel.Content = "Korak 2 od 4";
                StepProgressBar.Value = 2;
            }
        }
        
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string helpKey = "PravljenjeNovogPutovanja";
            if (Step1.Visibility == Visibility.Visible)
            {
                helpKey = "PravljenjeNovogPutovanja";
            }
            if (Step2.Visibility == Visibility.Visible)
            {
                helpKey = "PravljenjeNovogPutovanjaKorak2";
            }
            if (Step3.Visibility == Visibility.Visible)
            {
                helpKey = "PravljenjeNovogPutovanjaKorak3";
            }
            if (Step4.Visibility == Visibility.Visible)
            {
                helpKey = "PravljenjeNovogPutovanjaKorak4";
            }
            HelpProvider.ShowHelp(helpKey, this);
        }

        private bool ValidateStep1()
        {
            if (NameInput.Text.Length==0  )
            {
                CustomDialogWindow.Show("Niste popunili podatke za naziv putovanja! Sva polja su obavezna!");
                return false;
            }
            else if (NameInput.Text.Length>30  )
            {
                CustomDialogWindow.Show("Naziv putovanja sadrzi previse karaktera");
                return false;
            }
            else if (FormInput.SelectedDate == null)
            {
                CustomDialogWindow.Show("Niste izabrali datum pocetka putovanja! Sva polja su obavezna!");
                return false;
            }
            else if (ToInput.SelectedDate == null)
            {
                CustomDialogWindow.Show("Niste izabrali datum kraja putovanja! Sva polja su obavezna!");
                return false;
            }
            else if(CaptionInput.Text.Length==0)
            {
                CustomDialogWindow.Show("Niste popunili podatke za opis putovanja! Sva polja su obavezna!");
                return false;
            }
            else if (CaptionInput.Text.Length>100  )
            {
                CustomDialogWindow.Show("Opis putovanja sadrzi previse karaktera");
                return false;
            }
            else if(PriceInput.Text.Length==0)
            {
                CustomDialogWindow.Show("Niste popunili podatke za cenu putovanja! Sva polja su obavezna!");
                return false;
            }
            else
            {
                return true;
            }
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
            if (ChosenAttractionListBox.Items.Count==0)
            {
                CustomDialogWindow.Show("Niste prevukli zeljene atrakcije! Minimalno morate previci jednu atrakciju!");
            }
            else
            {
                Step2.Visibility = Visibility.Collapsed;
                Step3.Visibility = Visibility.Visible;
                StepLabel.Content = "Korak 3 od 4";
                StepProgressBar.Value = 3;
            }
            
        }

        private void BackButton3_Click(object sender, RoutedEventArgs e)
        {
            Step3.Visibility = Visibility.Collapsed;
            Step2.Visibility = Visibility.Visible;

            // Update progress
            StepLabel.Content = "Korak 2 od 4";
            StepProgressBar.Value = 2;
        }

        private void NextButton3_Click(object sender, RoutedEventArgs e)
        {
            if (ChosenAccommodationsListBox.Items.Count==0)
            {
                CustomDialogWindow.Show("Niste prevukli zeljene smestaje! Minimalno morate previci jedan smestaj!");
            }
            else
            {
                Step3.Visibility = Visibility.Collapsed;
                Step4.Visibility = Visibility.Visible;
                StepLabel.Content = "Korak 4 od 4";
                StepProgressBar.Value = 4;
            }
        }

        private void BackButton4_Click(object sender, RoutedEventArgs e)
        {
            Step4.Visibility = Visibility.Collapsed;
            Step3.Visibility = Visibility.Visible;

            // Update progress
            StepLabel.Content = "Korak 3 od 4";
            StepProgressBar.Value = 3;
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
            if (ChosenRestaurantsListBox.Items.Count==0)
            {
                CustomDialogWindow.Show("Niste prevukli zeljene restorane! Minimalno morate previci jedan restoran!");
            }
            else
            {
                CustomYesNoDialog dialog = new CustomYesNoDialog("Da li ste sigurni da želite da potvrdite dodavanje novog putovanja?" );
                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    PopulateData();
                    TripService tripService = new TripService(new TripRepository());
                    tripService.AddNewTrip(Trip);
                    TripsWindow tripsWindow = new TripsWindow(_user);
                    tripsWindow.Show();
                    this.Hide();
                }
                else
                {
                    TripsWindow tripsWindow = new TripsWindow(_user);
                    tripsWindow.Show();
                    this.Hide();
                }
            }
            
            
        }

        private void PopulateData()
        {
            List<Attraction> attractions = new List<Attraction>();

            foreach (var item in ChosenAttractionListBox.Items)
            {
                Attraction attraction = (Attraction)item;
                attractions.Add(attraction);
            }
            
            List<Accommodation> accommodations = new List<Accommodation>();

            foreach (var item in ChosenAccommodationsListBox.Items)
            {
                Accommodation accommodation = (Accommodation)item;

                if (accommodation != null)
                {
                    accommodations.Add(accommodation);
                }
            }
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var item in ChosenRestaurantsListBox.Items)
            {
                Restaurant restaurant = (Restaurant)item;

                if (restaurant != null)
                {
                    restaurants.Add(restaurant);
                }
            }

            Random random = new Random();
            Trip.Id = random.Next(9999);
            Trip.Accommodations = accommodations;
            Trip.Attractions = attractions;
            Trip.Restaurants = restaurants;
            Trip.State = State.Ponuda;
        }
    }
}