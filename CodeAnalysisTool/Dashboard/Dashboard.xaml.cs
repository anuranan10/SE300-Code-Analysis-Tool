using System.Windows;
using CodeAnalysisTool.WelcomeScreen;

namespace CodeAnalysisTool.Dashboard
{
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //navigate back to welcome screen
            MainWindow welcomeScreen = new MainWindow();
            welcomeScreen.Show();
            this.Close(); //close dashboard
        }
    }
}