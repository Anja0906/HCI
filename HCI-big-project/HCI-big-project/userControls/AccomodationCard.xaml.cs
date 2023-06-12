using System.Windows;
using System.Windows.Controls;
using HCI_big_project.model;
using HCI_big_project.view;

namespace HCI_big_project.userControls
{
    public partial class AccomodationCard : UserControl
    {
        private Accommodation _accommodation;
        private User _user;
        public AccomodationCard(Accommodation accommodation, User user)
        {
            _accommodation = accommodation;
            _user = user;
            this.DataContext = _accommodation;
            InitializeComponent();
        }

        private void Card_OnLoaded(object sender, RoutedEventArgs e)
        {
            NameLabel.Text += _accommodation.Name;
            DescriptionLabel.Text += _accommodation.Caption;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            AccomodationDetailsWidow accomodationDetailsWidow = new AccomodationDetailsWidow(_accommodation, _user);
            accomodationDetailsWidow.Show();
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null) parentWindow.Close();
        }
    }
}