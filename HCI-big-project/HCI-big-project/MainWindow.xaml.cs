using System;
using HCI_big_project.model;
using HCI_big_project.Repository;
using System.Windows;

namespace HCI_big_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserRepository userRepository = new UserRepository();
            var users = userRepository.GetAllUsers();
            
            foreach (var user in users)
            {
                outputTextBlock.Text += $"Username: {user.Name}, Email: {user.Email}\n";
            }
        }
    }
}
            //outputTextBlock.Text += $"Username: {users[0].Name}, Email: {users[0].Email}\n";
