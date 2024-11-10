using System.Windows;
using CodeAnalysisTool.WelcomeScreen;
using CodeAnalysisTool.ResultsScreen;
using Microsoft.Win32;

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
                //navigate to the results screen
                CodeAnalysisTool.ResultsScreen.ResultsScreen resultsScreen = new CodeAnalysisTool.ResultsScreen.ResultsScreen();
                resultsScreen.Show();
                this.Close(); //close the dashboard
            }
        }

    }
}