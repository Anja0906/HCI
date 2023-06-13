using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using HCI_big_project.model;
using HCI_big_project.repository;
using HCI_big_project.service;
using HCI_big_project.userControls;
using HelpSistem;
using LiveCharts;
using LiveCharts.Wpf;

namespace HCI_big_project.view
{
    public partial class ReportsWindow : Window, INotifyPropertyChanged
    {
        private User _user;
        public List<Trip> Trips = new List<Trip>();
        private TripService _tripService = new TripService(new TripRepository());
        private int option;
        private string name;
        private DateTime _dateTime;
        
        private SeriesCollection _seriesCollection;
        private string[] _labels;

        public SeriesCollection SeriesCollection
        {
            get { return _seriesCollection; }
            set
            {
                _seriesCollection = value;
                OnPropertyChanged();
            }
        }
        
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string helpKey = "StartWindowBANE";
            HelpProvider.ShowHelp(helpKey, this);
        }

        public string[] Labels
        {
            get { return _labels; }
            set
            {
                _labels = value;
                OnPropertyChanged();
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
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
            Label2.Visibility = Visibility.Hidden;
            DatePicker.Visibility = Visibility.Hidden;
            Label1.Visibility = Visibility.Hidden;
            TripsBox.Visibility = Visibility.Hidden;
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
                Trips = _tripService.GetPurchasedTripsForSpecificTrip(name);
            }
            else if(option==2)
            {
                purchasedTrips = _tripService.MakeDictionary(_tripService.GetTripsForMonth(dateTime));
                Trips = _tripService.GetTripsForMonth(dateTime);
            }
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Sales",
                    Values = new ChartValues<int>(purchasedTrips.Values.ToArray()),
                    Fill = Brushes.ForestGreen // Custom color
                }
            };
            Labels = new List<string>(purchasedTrips.Keys).ToArray();
            if (Panel.Children.Count>0)
            {
                Panel.Children.Clear();
            }

            if (_tripService.FindTripByName(name) != null)
            {
                Panel.Children.Add(new TripsOverviewCard(_tripService.FindTripByName(name), _user));
            }
            Panel.Children.Add(new TripsCount(purchasedTrips.Values.Sum()));
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
                    Label1.Visibility = Visibility.Hidden;
                    TripsBox.Visibility = Visibility.Hidden;
                    Label2.Visibility = Visibility.Visible;
                    DatePicker.Visibility = Visibility.Visible;
                    break;
                case "Pregled odredjenih aranzmana po putovanju":
                    option = 1;
                    Label2.Visibility = Visibility.Hidden;
                    DatePicker.Visibility = Visibility.Hidden;
                    Label1.Visibility = Visibility.Visible;
                    TripsBox.Visibility = Visibility.Visible;
                    break;
                default:
                    option = 1;
                    break;
            }
        }
        private void Trips_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            var selectedItem = comboBox.SelectedItem;
            InitGraph(selectedItem.ToString(), option, DateTime.Now);
        }

        private void ChangedDate(object sender, SelectionChangedEventArgs e)
        {
            DatePicker datePicker = (DatePicker)sender;
            DateTime date = datePicker.SelectedDate.Value;
            InitGraph("", option, date);
        }
    }
}