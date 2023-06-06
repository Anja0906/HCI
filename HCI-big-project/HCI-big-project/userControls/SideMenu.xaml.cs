using System.Windows;
using System.Windows.Controls;
using HCI_big_project.model;
using HCI_big_project.view;

namespace HCI_big_project.userControls
{
    public partial class SideMenu : UserControl
    {
        private User _user;
        public SideMenu()
        {
            InitializeComponent();
        }
        
        public void SetUserRole(User user)
        {
            _user = user;
            if (user.Role == Role.Administrator)
            {
                AdminSideMenu.Visibility = Visibility.Visible;
                UserSideMenu.Visibility = Visibility.Collapsed;
            }
            else if (user.Role == Role.Client)
            {
                AdminSideMenu.Visibility = Visibility.Collapsed;
                UserSideMenu.Visibility = Visibility.Visible;
            }
        }

        private void ButtonTrips_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Map_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ButtonBook_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ButtonBought_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ButtonLogout_OnClick(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null) parentWindow.Close();
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
        }

        private void ButtonTripsAdmin_OnClick(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null) parentWindow.Close();
            TripsWindow newWindow = new TripsWindow(_user);
            newWindow.Show();
        }

        private void MapAdmin_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ButtonNewDestination_OnClick(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null) parentWindow.Close();
            RestaurantsWindow newWindow = new RestaurantsWindow(_user);
            newWindow.Show();
        }

        private void ButtonNewHotel_OnClick(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null) parentWindow.Close();
            AccomodationsWindow newWindow = new AccomodationsWindow(_user);
            newWindow.Show();
        }

        private void ButtonNewAttraction_OnClick(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null) parentWindow.Close();
            AttractionsWindow newWindow = new AttractionsWindow(_user);
            newWindow.Show();
        }

        private void ButtonLogoutAdmin_OnClick(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null) parentWindow.Close();
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
        }
        
    }
}