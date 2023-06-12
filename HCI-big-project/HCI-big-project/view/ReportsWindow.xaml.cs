using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using HCI_big_project.model;
using HCI_big_project.repository;
using HCI_big_project.service;
using HCI_big_project.userControls;
using LiveCharts;
using LiveCharts.Wpf;

namespace HCI_big_project.view
{
    public partial class ReportsWindow : Window
    {
        private User _user;
        public List<Trip> Trips = new List<Trip>();
        private TripService _tripService = new TripService(new TripRepository());
        private int option;
        private string name;
        private DateTime _dateTime;
        
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        
        public ReportsWindow( User user)
        {
            _user = user;
            Trips = _tripService.GetOfferedTrips();
            DataContext = this;
            Labels = new string[100];
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Sales",
                    Values = new ChartValues<int>(),
                    Stroke = Brushes.ForestGreen // Custom color
                }
            };
            
            InitializeComponent();
            InitCombo();
        }

        private void InitCombo()
        {
            foreach (Trip trip in Trips)
            {
                TripsBox.Items.Add(trip.Name);
            }
        }

        private void InitGraph(string name, int option, DateTime dateTime)
        {
            Dictionary<string, int> purchasedTrips=new Dictionary<string, int>();
            if (option==1)
            {
                purchasedTrips = _tripService.MakeDictionary(_tripService.GetPurchasedTripsForSpecificTrip(name));
            }
            else if(option==2)
            {
                purchasedTrips = _tripService.MakeDictionary(_tripService.GetTripsForMonth(dateTime));
            }
            SeriesCollection[0].Values=new ChartValues<int>(purchasedTrips.Values.ToArray());
            Labels = new List<string>(purchasedTrips.Keys).ToArray();
            
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Menu.SetUserRole(_user);
            if (_user.Role == Role.Client)
            {
                Grid2.Visibility = Visibility.Hidden;
            }
        }
        

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = ((sender as ComboBox).SelectedItem as ComboBoxItem);
            string selectedContent = selectedItem.Content.ToString();

            switch (selectedContent)
            {
                case "Pregled prodatih putovanja u jednom mesecu":
                    option = 2;
                    break;
                case "Pregled odredjenih aranzmana po putovanju":
                    option = 1;
                    break;
                default:
                    option = 1;
                    break;
            }
        }

        private void Trips_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = ((sender as ComboBox).SelectedItem as ComboBoxItem);
            string selectedContent = selectedItem.Content.ToString();

            InitGraph(selectedContent, option, DateTime.Now);
        }
    }
}