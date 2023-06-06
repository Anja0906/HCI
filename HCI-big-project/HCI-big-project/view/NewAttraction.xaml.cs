using System.Windows;
using System.Windows.Input;
using HCI_big_project.model;

namespace HCI_big_project.view
{
    public partial class NewAttraction : Window
    {
        private User _user;
        public NewAttraction(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Menu.SetUserRole(_user);
        }

        private void map_load(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void MapControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}