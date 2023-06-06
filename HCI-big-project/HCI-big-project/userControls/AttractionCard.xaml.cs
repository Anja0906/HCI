using System.Windows;
using System.Windows.Controls;
using HCI_big_project.model;

namespace HCI_big_project.userControls
{
    public partial class AttractionCard : UserControl
    {
        private Attraction _attraction;
        public AttractionCard(Attraction attraction)
        {
            _attraction = attraction;
            this.DataContext = _attraction;
            InitializeComponent();
        }
        
        private void Card_OnLoaded(object sender, RoutedEventArgs e)
        {
            NameLabel.Text += _attraction.Name;
            DescriptionLabel.Text += _attraction.Caption;
        }
    }
}