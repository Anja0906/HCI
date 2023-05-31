using System.Windows;
using System.Windows.Controls;
using HCI_big_project.model;

namespace HCI_big_project.userControls
{
    public partial class SideMenu : UserControl
    {
        public SideMenu()
        {
            InitializeComponent();
        }
        
        public void SetUserRole(Role role)
        {
            if (role == Role.Administrator)
            {
                AdminSideMenu.Visibility = Visibility.Visible;
                UserSideMenu.Visibility = Visibility.Collapsed;
            }
            else if (role == Role.Client)
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
            throw new System.NotImplementedException();
        }

        private void MapAdmin_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ButtonNewDestination_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ButtonNewHotel_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ButtonNewAttraction_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
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