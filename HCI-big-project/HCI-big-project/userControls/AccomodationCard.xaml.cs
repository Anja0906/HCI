using System.Windows;
using System.Windows.Controls;
using HCI_big_project.model;

namespace HCI_big_project.userControls
{
    public partial class AccomodationCard : UserControl
    {
        private Accommodation _accommodation;
        public AccomodationCard(Accommodation accommodation)
        {
            _accommodation = accommodation;
            this.DataContext = _accommodation;
            InitializeComponent();
        }

        private void Card_OnLoaded(object sender, RoutedEventArgs e)
        {
            NameLabel.Text += _accommodation.Name;
            DescriptionLabel.Text += _accommodation.Caption;
        }

    }
}