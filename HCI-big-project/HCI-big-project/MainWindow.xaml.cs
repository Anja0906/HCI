using System;
using HCI_big_project.model;
using HCI_big_project.repository;
using HCI_big_project.service;
using System.Windows;
using HCI_big_project.view;

namespace HCI_big_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
                Window adminMainWindow = new AdminMainWindow(user);
                adminMainWindow.Show();
                this.Hide();
            }
            else if (user.Role == Role.Client)
            {
                Window userMainWindow = new UserMainWindow(user);
                userMainWindow.Show();
                this.Hide();
            }
            else
            {
                CustomDialogWindow.Show("Pogrešno uneti kredencijali!");
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
