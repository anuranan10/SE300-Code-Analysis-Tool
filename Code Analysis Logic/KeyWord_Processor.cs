using System;
using System.Collections;
using System.Collections.Generic;

public class KeyWord_Processor
{
    private string id;
    private string[][] inputFile;


    // each of these keywords imply a corresponding field where rules for scanning are modified, each field type will have a corresponding "end field" keyword eg. { => } or /* => */
    private string[] fieldKWS = { "/*", "//", "{", "(" };

    private string[] dataTypeKWS = { "int", "char", "string", "long", "boolean", "double", "float, " };

    private ArrayList keyLines = new ArrayList();

    public KeyWord_Processor(string id, string[][] inputFile)
    {
        this.inputFile = inputFile;
        this.id = id;

    }
    
    //this will be used to count occurances of each specified keyword
    private Dictionary<string, int> loggedKWS = new Dictionary<string, int>();
    //maybe create a switch and for every case of a keyword that is being counted, loggedKWS.Add("keyword");



    //add items to dictionary and set the count to 0
    private void initilaizeDictionary()
    {
        for (int i = 0; i < dataTypeKWS.Length; i++)
        {
            loggedKWS.Add(dataTypeKWS[i], 0);
        }
    }
    private void countKeywords(string[][] target)
    {
        for (int i = 0; i < target.Length; i++)
        {
            for (int j = 0; j < target[i].Length; j++)
            {
                //Console.Write(target[i][j].ToLower());
                //Console.WriteLine("   ====> " + checkContains((target[i][j] + " "), "string "));
                // FOR DEBUGGING ^^^^^^^^^^^^^^^^^^
                switch (true)
                {
                    //LATER FIND WAY TO ELIMINATE DUPLICATE target[i]s triggered by multiple keywords in one line
                    case bool findInts when checkContains((string)(target[i][j] + " "), "int "):
                        loggedKWS["int"] += 1; // add one to the count and then below will add the line to list of lines containing keywords
                        keyLines.Add("" + target[i]);
                        break;
                    case bool findStrings when checkContains((string)(target[i][j] + " "), "string "):
                        loggedKWS["string"] += 1;
                        keyLines.Add("" + target[i]);
                        break;
                    case bool findLongs when checkContains((string)(target[i][j] + " "), "long "):
                        loggedKWS["long"] += 1;
                        keyLines.Add("" + target[i]);
                        break;
                    case bool findBools when checkContains((string)(target[i][j] + " "), "boolean "):
                        loggedKWS["boolean"] += 1;
                        keyLines.Add("" + target[i]);
                        break;
                    case bool findDoubles when checkContains((string)(target[i][j] + " "), "double "):
                        loggedKWS["double"] += 1;
                        keyLines.Add("" + target[i]);
                        break;
                    case bool findFloats when checkContains((string)(target[i][j] + " "), "float "):
                        loggedKWS["float"] += 1;
                        keyLines.Add("" + target[i]);
                        break;

                    default:
                        break;
                }

            }

        }
    }

    private bool checkContains(string lineToCheck, string wordToLookFor)
    {
        bool found = lineToCheck.ToLower().IndexOf(wordToLookFor.ToLower(), 0, lineToCheck.Length) != -1;
        return found;
        
    }


    public string[] getFlaggedWords()
    {

        initilaizeDictionary();
        countKeywords(inputFile);

        string loggedKWSToString = string.Join(Environment.NewLine, loggedKWS);
        Console.WriteLine(loggedKWSToString);

        
 
       return (string[])keyLines.ToArray(typeof(string));
    }

}
