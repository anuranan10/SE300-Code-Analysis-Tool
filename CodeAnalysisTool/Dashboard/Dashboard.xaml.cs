using System.Windows;
using CodeAnalysisTool.WelcomeScreen;
using CodeAnalysisTool.ResultsScreen;
using Microsoft.Win32;
using CodeAnalysisToolLogic.Models;
using System.Collections.Generic;

namespace CodeAnalysisTool.Dashboard
{
    public partial class Dashboard : Window
    {
        private string selectedFilePath;
        public Dashboard()
        {
            InitializeComponent();
            AnalyzeButton.IsEnabled = false; //disabling analyze button initially
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //navigate back to welcome screen
            MainWindow welcomeScreen = new MainWindow();
            welcomeScreen.Show();
            this.Close(); //close dashboard
        }

        private void BrowseFile_Click(object sender, RoutedEventArgs e)
        {
            //open file dialog to select a file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Java Files (*.java)|*.java|All Files (*.*)|*.*",
                Title = "Select a Java File"
            };

            //check if the user selected a file
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                selectedFilePath = openFileDialog.FileName; //store file path
                AnalyzeButton.IsEnabled = true; //enabling the analyze button
            }
        }

        private void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedFilePath != null)
            {
                // Use CodeAnalyzer with the uploaded file
                CodeAnalyzer analyzer = new CodeAnalyzer(selectedFilePath);

                // Get analytics result (update this as per the format you want to display)
                string[] analysisReport = analyzer.getAnalytics();

                // Convert the string[] to List<string>
                List<string> reportDetails = new List<string>(analysisReport);

                // Pass the analysis result to the ResultsScreen
                AnalysisResult analysisResult = new AnalysisResult
                {
                    ReportDetails = reportDetails // Assign the List<string> instead of string[]
                };

                CodeAnalysisTool.ResultsScreen.ResultsScreen resultsScreen = new CodeAnalysisTool.ResultsScreen.ResultsScreen(analysisResult);
                resultsScreen.Show();
                this.Close();
            }
        }





    }
}