using System.Windows;

namespace HCI_big_project.view
{
    public partial class CustomDialogWindow : Window
    {
        public CustomDialogWindow()
        {
            InitializeComponent();
        }
        
        public static void Show(string message)
        {
            var msgBox = new CustomDialogWindow();
            msgBox.Message.Text = message;
            msgBox.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}