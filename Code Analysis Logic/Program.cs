// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
// C# program to print Hello World! 
using System;
using System.IO;
using System.Reflection;
using System.Text;

// namespace declaration 
namespace HelloWorldApp
{
    // Class declaration 
    class Geeks
    {

        // Main Method 
        public static void Main()
        {
            Console.InputEncoding = Encoding.GetEncoding(1200);
            //old method is commented out, new method should properly call the file properly regardless of your PC or user account
            //string path = @"C:\Users\Tatum Kelley\source\repos\Code Analysis Logic\Code Analysis Logic\javatestfiles\Lab01_Kelley.java";
            string path = @"../../../javatestfiles/Lab05_ConstantRacer_Kelley.java";


            Java_File testFile = new Java_File("testFile", path);
            testFile.printFile();

            //funny thing i learned, if i dont clone here, it will modify the reference and therefore change testFile.filestringarray

            /*
            TextFormatter testTF = new TextFormatter("testTF", (string[])testFile.toArray().Clone());
            string displayTest = testTF.formatFile();

            
            
            
            Console.WriteLine("----------------------------------------------------------------------------------------------------------\n");
            KeyWord_Processor testKWP = new KeyWord_Processor("testKWP",displayTest);



            Code_Analyzer testCA = new Code_Analyzer("testCA", testKWP.getFlaggedWords());
            

            Console.WriteLine("----------------------------------------------------------------------------------------------------------\n");
            string[] testResults = testCA.getAnalytics();
            for (int i = 0; i < testResults.Length; i++)
            {
                Console.WriteLine(  testResults[i]);
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine(Globals.userMadeClasses[0]);
            */

            Process_Manager testPM = new Process_Manager(testFile);
            testPM.printFinalData();


            //stops console app from closing immediately after running
            Console.ReadKey();

            


        }
    }
}