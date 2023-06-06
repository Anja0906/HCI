using System.Windows;
using System.Windows.Controls;
using HCI_big_project.model;
using HCI_big_project.view;

namespace HCI_big_project.userControls
{
    public partial class AttractionCard : UserControl
    {
        private Attraction _attraction;
        private User _user;
        public AttractionCard(Attraction attraction, User user)
        {
            _attraction = attraction;
            _user = user;
            this.DataContext = _attraction;
            InitializeComponent();
        }
        
        private void Card_OnLoaded(object sender, RoutedEventArgs e)
        {
            NameLabel.Text += _attraction.Name;
            DescriptionLabel.Text += _attraction.Caption;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            AttractionDetailsWindow attractionDetailsWindow = new AttractionDetailsWindow(_attraction, _user);
            attractionDetailsWindow.Show();
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null) parentWindow.Close();
        }
    }
}