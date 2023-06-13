using System.Windows;
using HCI_big_project.model;
using HCI_big_project.repository;
using HCI_big_project.service;

namespace HCI_big_project.view
{
    public partial class RegistrationWindow : Window
    {
        public User User { get; set; }
        public RegistrationWindow()
        {
            User = new User();
            DataContext = this;
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                UserService userService = new UserService(new UserRepository());
                userService.AddNewUser(new User(NameInput.Text, SurnameInput.Text, EmailInput.Text, PasswordBox.Password, BirthDateInput.SelectedDate.Value, Role.Client));
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            
        }

        private bool Validate()
        {
            if (NameInput.Text.Length==0)
            {
                CustomDialogWindow.Show("Polje za unos imena nije popunjeno! Sva polja su obavezna!");
                return false;
            }
            if (SurnameInput.Text.Length==0)
            {
                CustomDialogWindow.Show("Polje za unos prezimena nije popunjeno! Sva polja su obavezna!");
                return false;
            }
            if (EmailInput.Text.Length==0)
            {
                CustomDialogWindow.Show("Polje za unos emaila nije popunjeno! Sva polja su obavezna!");
                return false;
            }
            if (PasswordBox.Password.Length==0)
            {
                CustomDialogWindow.Show("Polje za unos lozinke nije popunjeno! Sva polja su obavezna!");
                return false;
            }

            if (BirthDateInput.SelectedDate == null)
            {
                CustomDialogWindow.Show("Polje za unos datuma rodjenja nije popunjeno! Sva polja su obavezna!");
                return false;
            }

            return true;
        }

    }
}