using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using HCI_big_project.model;
using HCI_big_project.view;

namespace HCI_big_project.userControls
{
    public partial class TripsOverviewCard : UserControl
    {
        private Trip _trip;
        private User _user;
        public TripsOverviewCard(Trip trip, User user)
        {
            _trip = trip;
            _user = user;
            this.DataContext = _trip;
            InitializeComponent();
        }

        private void Card_OnLoaded(object sender, RoutedEventArgs e)
        {
            NameLabel.Text += _trip.Name;
            DescriptionLabel.Text += _trip.Caption;
        }

        private void Card_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null) parentWindow.Close();
            TripDetailsWindow newWindow = new TripDetailsWindow(_trip, _user);
            newWindow.Show();
        }

        private void TripsOverviewCard_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            Border.Background = new SolidColorBrush(Color.FromRgb(78, 190, 96));
            NameLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            DescriptionLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void TripsOverviewCard_OnMouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            Border.Background = new SolidColorBrush(Color.FromRgb(217, 217, 217));
            NameLabel.Foreground = new SolidColorBrush(Color.FromRgb(78, 190, 96));
            DescriptionLabel.Foreground = new SolidColorBrush(Color.FromRgb(78, 190, 96));
        }
    }
}