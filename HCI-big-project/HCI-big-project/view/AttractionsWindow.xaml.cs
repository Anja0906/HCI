using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using HCI_big_project.model;
using HCI_big_project.repository;
using HCI_big_project.service;
using HCI_big_project.userControls;
using HelpSistem;

namespace HCI_big_project.view
{
    public partial class AttractionsWindow : Window
    {
        private User _user;
        public List<Attraction> Attractions { get; set; }
        private AttractionService _attractionService;
        public AttractionsWindow(User user)
        {
            _user = user;
            _attractionService = new AttractionService(new AttractionRepository());
            Attractions = _attractionService.GetAll();
            InitializeComponent();
        }

        private void Window_OnLoaded(object sender, RoutedEventArgs e)
        {
            Menu.SetUserRole(_user);
            if (_user.Role == Role.Client)
            {
                Grid1.Visibility = Visibility.Hidden;
            }
            foreach (Attraction attraction in Attractions)
            {
                Panel.Children.Add(new AttractionCard(attraction, _user));
            }
        }
        
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string helpKey = "PregledAtrakcija";
            HelpProvider.ShowHelp(helpKey, this);
        }

        private void AddAttraction_OnClick(object sender, RoutedEventArgs e)
        {
            NewAttractionWindow newAttractionWindow = new NewAttractionWindow(_user);
            newAttractionWindow.Show();
            this.Hide();
        }
    }
}