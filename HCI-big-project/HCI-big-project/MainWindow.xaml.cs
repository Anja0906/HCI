using System;
using HCI_big_project.model;
using HCI_big_project.repository;
using HCI_big_project.service;
using System.Windows;
using System.Windows.Input;
using HCI_big_project.view;

namespace HCI_big_project
{
    public partial class MainWindow : Window
    {
        private UserService _userService = new UserService(new UserRepository());
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ButtonSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;
            try
            {
                User user = _userService.Login(username, password);
                OpenWindow(user);
            }
            catch (NullReferenceException nullReferenceException)
            {
                CustomDialogWindow.Show(nullReferenceException.Message);
            }
        }

        private void OpenWindow(User user)
        {
            if (user.Role == Role.Administrator)
            {
                Window adminMainWindow = new TripsMapWindow(user);
                adminMainWindow.Show();
                this.Hide();
            }
            else if (user.Role == Role.Client)
            {
                Window userMainWindow = new TripsMapWindow(user);
                userMainWindow.Show();
                this.Hide();
            }
            else
            {
                CustomDialogWindow.Show("Pogrešno uneti kredencijali!");
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void RegistrationButton_OnClick(object sender, RoutedEventArgs e)
        {
            RegistrationWindow userMainWindow = new RegistrationWindow();
            userMainWindow.Show();
            this.Hide();
        }
    }
}
