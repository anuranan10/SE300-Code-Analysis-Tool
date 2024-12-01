using System.Windows;
using CodeAnalysisTool.WelcomeScreen;
using CodeAnalysisTool.ResultsScreen;
using Microsoft.Win32;
using CodeAnalysisToolLogic.Models;
using System.Collections.Generic;
using System.Linq;

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
                // Step 1: Analyze the file
                Java_File javaFile = new Java_File("File1", selectedFilePath);
                Process_Manager processManager = new Process_Manager(javaFile);
                processManager.printFinalData();

                // Step 2: Build AnalysisResult
                AnalysisResult analysisResult = new AnalysisResult
                {
                    ReportDetails = new List<string> { selectedFilePath }, // Pass the file path
                    TotalLOC = javaFile.toArray().Length,
                    TotalELOC = CalculateELOC(javaFile.toArray()),
                    ClassCount = Globals.userMadeClasses.Count,
                    InterfaceCount = 0, // Update based on analysis
                    HasInheritance = CheckInheritance(javaFile.toArray()),
                    AverageCoupling = 0, // Update based on analysis
                    AverageCohesion = 0, // Update based on analysis
                    MaxNestingDepth = 0, // Update based on analysis
                    ClassDetails = GenerateClassDetails(javaFile)
                };

                // Step 3: Open ResultsScreen and pass AnalysisResult
                CodeAnalysisTool.ResultsScreen.ResultsScreen resultsScreen = new CodeAnalysisTool.ResultsScreen.ResultsScreen(analysisResult);
                resultsScreen.Show();
                this.Close();
            }
        }

        // Example helper functions
        private int CalculateELOC(string[] lines)
        {
            return lines.Count(line => !string.IsNullOrWhiteSpace(line) && !line.Trim().StartsWith("//"));
        }

        private bool CheckInheritance(string[] lines)
        {
            return lines.Any(line => line.Contains("extends"));
        }

        private List<ClassDetails> GenerateClassDetails(Java_File javaFile)
        {
            // Use logic from CodeAnalyzer and other components to populate ClassDetails
            return new List<ClassDetails>(); // Replace with actual logic
        }






    }
}