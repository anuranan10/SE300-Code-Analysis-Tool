using System.Windows;
using CodeAnalysisTool.Dashboard;

namespace CodeAnalysisTool.ResultsScreen
{
    public partial class ResultsScreen : Window
    {
        public ResultsScreen()
        {
            InitializeComponent();
        }

        private void ReturnToDashboard_Click(object sender, RoutedEventArgs e)
        {
            //back to the dashboard
            CodeAnalysisTool.Dashboard.Dashboard dashboard = new CodeAnalysisTool.Dashboard.Dashboard();
            dashboard.Show();

            //closing current screen
            this.Close();
        }
    }
}