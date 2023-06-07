using System.Collections.Generic;
using System.Windows;
using HCI_big_project.model;
using HCI_big_project.repository;
using HCI_big_project.service;
using HCI_big_project.userControls;

namespace HCI_big_project.view
{
    public partial class AccomodationsWindow : Window
    {
        private User _user;
        public List<Accommodation> Accommodations = new List<Accommodation>();
        private AccomodationService _accomodationService = new AccomodationService(new AccommodationRepository());
        public AccomodationsWindow( User user)
        {
            _user = user;
            Accommodations = _accomodationService.GetAll();
            InitializeComponent();
        }

        private void AccomodationsWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Menu.SetUserRole(_user);
            foreach (Accommodation accommodation in Accommodations)
            {
                Panel.Children.Add(new AccomodationCard(accommodation, _user));
            }
        }

        private void AddAccomodation_OnClick(object sender, RoutedEventArgs e)
        {
            NewAccommodationWindow newAccommodationWindow = new NewAccommodationWindow(_user);
            newAccommodationWindow.Show();
            
        }
    }
}