using System.Windows;
using HCI_big_project.model;

namespace HCI_big_project.view
{
    public partial class AdminMainWindow : Window
    {
        private User _user;
        public AdminMainWindow(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Menu.SetUserRole(_user.Role);
        }
    }
}