using System.Windows;
using System.Windows.Controls;
using HCI_big_project.model;

namespace HCI_big_project.userControls
{
    public partial class RestaurantCard : UserControl
    {
        private Restaurant _restaurant;
        public RestaurantCard(Restaurant restaurant)
        {
            _restaurant = restaurant;
            this.DataContext = _restaurant;
            InitializeComponent();
        }
        
        private void Card_OnLoaded(object sender, RoutedEventArgs e)
        {
            NameLabel.Text += _restaurant.Name;
            DescriptionLabel.Text += _restaurant.Address.Address;
        }
    }
}