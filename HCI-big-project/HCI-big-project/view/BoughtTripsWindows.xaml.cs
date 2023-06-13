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
using HCI_big_project.userControls;
using HelpSistem;

namespace HCI_big_project.view
{
    public partial class BoughtTripsWindows : Window
    {
        private User _user;
        public List<Trip> Trips = new List<Trip>();
        private TripService _tripService = new TripService(new TripRepository());
        public BoughtTripsWindows( User user)
        {
            _user = user;
            Trips = _tripService.GetPurchasedTrips();
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
            string helpKey = "KupljenaPutovanjaUser";
            HelpProvider.ShowHelp(helpKey, this);
        }
        
    }
}