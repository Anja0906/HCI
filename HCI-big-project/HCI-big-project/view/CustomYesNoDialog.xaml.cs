using System.Windows;

namespace HCI_big_project.view
{
    public partial class CustomYesNoDialog : Window
    {
        public CustomYesNoDialog(string message)
        {
            InitializeComponent();
            Message.Text = message;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}