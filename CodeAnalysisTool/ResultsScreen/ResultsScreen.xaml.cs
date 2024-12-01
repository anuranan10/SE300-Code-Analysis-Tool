using System.Collections.Generic;
using System.Linq;
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
            // Display file path (remove redundant "Analyzed File:")
            FilePathTextBlock.Text = result.ReportDetails.FirstOrDefault(); // Only display the file path

            // General summary
            TotalLOCText.Text = $"Total LOC: {result.TotalLOC}";
            TotalELOCText.Text = $"Total ELOC: {result.TotalELOC}";
            ClassCountText.Text = $"Number of Classes: {result.ClassCount}";
            InterfaceCountText.Text = $"Number of Interfaces: {result.InterfaceCount}";
            InheritancePresentText.Text = $"Inheritance Present: {(result.HasInheritance ? "Yes" : "No")}";
            AverageCouplingText.Text = $"Average Coupling: {result.AverageCoupling}";
            AverageCohesionText.Text = $"Average Cohesion: {result.AverageCohesion}";
            MaxNestingDepthText.Text = $"Maximum Nesting Depth: {result.MaxNestingDepth}";

            // Class-specific details
            if (result.ClassDetails != null && result.ClassDetails.Count > 0)
            {
                var firstClass = result.ClassDetails.First();
                ClassNameText.Text = $"Class Name: {firstClass.ClassName}";
                ParentClassText.Text = $"Parent Class: {firstClass.ParentClassName}";
                AttributesCountText.Text = $"Number of Attributes: {firstClass.AttributeCount}";
                MethodsCountText.Text = $"Number of Methods: {firstClass.MethodCount}";
                InnerClassText.Text = $"Inner Class Defined: {(firstClass.HasInnerClass ? "Yes" : "No")}";
                ELOCPerMethodText.Text = $"Average ELOC per Method: {firstClass.AverageELOCPerMethod}";
                MaxELOCText.Text = $"Maximum ELOC in Method: {firstClass.MaxELOCForMethod}";
                ExceededMALOCText.Text = $"Methods Exceeding MALOC: {string.Join(", ", firstClass.MethodsExceedingMALOC ?? new List<string>())}";
            }
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