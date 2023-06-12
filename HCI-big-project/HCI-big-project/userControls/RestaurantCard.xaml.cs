using System.Windows;
using System.Windows.Controls;
using HCI_big_project.model;
using HCI_big_project.view;

namespace HCI_big_project.userControls
{
    public partial class RestaurantCard : UserControl
    {
        private Restaurant _restaurant;
        private User _user;
        public RestaurantCard(Restaurant restaurant, User user)
        {
            _restaurant = restaurant;
            _user = user;
            this.DataContext = _restaurant;
            InitializeComponent();
        }
        
        private void Card_OnLoaded(object sender, RoutedEventArgs e)
        {
            NameLabel.Text += _restaurant.Name;
            DescriptionLabel.Text += _restaurant.Address.Address;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            RestaurantDetailsWindow restaurantDetails = new RestaurantDetailsWindow(_restaurant, _user);
            restaurantDetails.Show();
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null) parentWindow.Close();
        }
    }
}