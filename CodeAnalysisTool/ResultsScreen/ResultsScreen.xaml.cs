using System.Windows;
using CodeAnalysisTool.Dashboard;
using CodeAnalysisToolLogic.Models;

namespace CodeAnalysisTool.ResultsScreen
{
    public partial class ResultsScreen : Window
    {
        private string analyzedFilePath;
        public ResultsScreen(AnalysisResult analysisResult)
        {
            InitializeComponent();
            DisplayResults(analysisResult);
        }

        private void DisplayResults(AnalysisResult result)
        {
            TotalLOCText.Text = $"Total LOC: {result.TotalLOC}";
            TotalELOCText.Text = $"Total ELOC: {result.TotalELOC}";
            ClassCountText.Text = $"Number of Classes: {result.ClassCount}";
            //add more details
        }
        private void DisplayAnalysisResults()
        {
            FilePathTextBlock.Text = $"Analyzed File: {analyzedFilePath}";
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