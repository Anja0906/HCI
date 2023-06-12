using System;
using System.Windows;
using System.Windows.Input;
using HCI_big_project.model;
using HCI_big_project.repository;
using HCI_big_project.service;

namespace HCI_big_project.view
{
    public partial class RegistrationWindow : Window
    {
        private UserService _userService = new UserService(new UserRepository());
        private User User { get; set; }
        public RegistrationWindow()
        {
            User = new User();
            InitializeComponent();
        }
        
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(User.ToString());
        }
    }
}