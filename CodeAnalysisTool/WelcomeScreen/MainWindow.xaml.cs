using System.Windows;
using CodeAnalysisTool.Dashboard;

namespace CodeAnalysisTool.WelcomeScreen
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetStarted_Click(object sender, RoutedEventArgs e)
        {
            //navigate to dashboard
            CodeAnalysisTool.Dashboard.Dashboard dashboard = new CodeAnalysisTool.Dashboard.Dashboard();
            dashboard.Show();
            this.Close(); //close the welcome screen
        }
    }
}