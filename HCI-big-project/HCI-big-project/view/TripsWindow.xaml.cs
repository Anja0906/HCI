using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HCI_big_project.view
{
    public partial class TripsWindow : Window
    {
        private User _user;
        public List<Trip> Trips = new List<Trip>();
        private TripService _tripService = new TripService(new TripRepository());
        public TripsWindow( User user)
        {
            _user = user;
            Trips = _tripService.GetOfferedTrips();
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Menu.SetUserRole(_user);
            if (_user.Role == Role.Client)
            {
                Grid2.Visibility = Visibility.Hidden;
            }
            foreach (Trip trip in Trips)
            {
                Panel.Children.Add(new Card(trip, _user));
            }
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Code to handle text change in the search bar
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            // Code to handle search button click
        }

        private void AddTrip_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                NewTripWindow newTripWindow = new NewTripWindow(_user);
                newTripWindow.Show();
                this.Hide();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            
        }
    }
}