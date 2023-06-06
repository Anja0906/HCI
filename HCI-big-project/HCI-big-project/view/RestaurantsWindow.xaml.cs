using System.Collections.Generic;
using System.Windows;
using HCI_big_project.model;
using HCI_big_project.repository;
using HCI_big_project.service;
using HCI_big_project.userControls;

namespace HCI_big_project.view
{
    public partial class RestaurantsWindow : Window
    {
        private User _user;
        public List<Restaurant> Restaurants { get; set; }
        private RestaurantService _restaurantService;
        public RestaurantsWindow(User user)
        {
            _user = user;
            _restaurantService = new RestaurantService(new RestaurantRepository());
            Restaurants = _restaurantService.GetAll();
            InitializeComponent();
        }

        private void Window_OnLoaded(object sender, RoutedEventArgs e)
        {
            Menu.SetUserRole(_user);
            foreach (Restaurant restaurant in Restaurants)
            {
                Panel.Children.Add(new RestaurantCard(restaurant, _user));
            }
        }
    }
}