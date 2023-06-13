using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using HCI_big_project.model;
using HCI_big_project.repository;
using HCI_big_project.service;
using HCI_big_project.userControls;
using HelpSistem;

namespace HCI_big_project.view
{
    public partial class BookedTripsWindow : Window
    {
        private User _user;
        public List<Trip> Trips = new List<Trip>();
        private TripService _tripService = new TripService(new TripRepository());
        public BookedTripsWindow( User user)
        {
            _user = user;
            Trips = _tripService.GetReservedTrips();
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Menu.SetUserRole(_user);
            foreach (Trip trip in Trips)
            {
                Panel.Children.Add(new TripsOverviewCard(trip, _user));
            }
        }
        
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string helpKey = "RezervisanaPutovanjaUser";
            HelpProvider.ShowHelp(helpKey, this);
        }
        
    }
}