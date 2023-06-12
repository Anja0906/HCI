using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using HCI_big_project.model;
using HCI_big_project.view;

namespace HCI_big_project.userControls
{
    public partial class TripsCount : UserControl
    {
        private int _count;
        public TripsCount(int count)
        {
            _count = count;
            InitializeComponent();
        }

        private void Card_OnLoaded(object sender, RoutedEventArgs e)
        {
            DescriptionLabel.Text += _count;
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