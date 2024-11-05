using System;
using System.Collections;
using System.Collections.Generic;

public class KeyWord_Processor
{
    private string id;
    private string inputFile;
    //int currentIndex;
    char[] charFile;


    //int bracketLevel;
    //String currentMethod;
    //int 

    // each of these keywords imply a corresponding field where rules for scanning are modified, each field type will have a corresponding "end field" keyword eg. { => } or /* => */
    private string[] fieldKWS = { "/*", "//", "{", "(", ";", ")", "}", "["};

    private string[] dataTypeKWS = { "int", "char", "string", "long", "boolean", "double", "float", "scanner", "public", "private", "static", "class", "new", "import" }; //not just datatypes anymore, change name later



    private ArrayList keyLines = new ArrayList();



    private bool termInArray(string term, string[] target)
    {
        return Array.IndexOf(target, term) > -1;
    }


    //Later break this down into multiple smaller methods for organizational reasons
    private string executeParseTermsLoop()
    {
        //was for while loop //bool loopFinished = false;
        int currentIndex = 0;
        string currentTerm = "";
        bool inComment = false;
        bool inLongComment = false;
        bool inString = false;
        int bracketLevel = 0;
        int parenthesisLevel = 0;
        int curlyBracketLevel = 0;

        

        for (int i = 0; i < charFile.Length; i++)
        {

            if (inLongComment || inString)
            {
                if((inLongComment && currentTerm.Contains("*/") ) || (inString && currentTerm.Contains("\"")) )
                { 
                    if (inLongComment && currentTerm.Contains("*/"))
                    {
                        //Console.WriteLine(currentTerm + "!!!!!!!!!!!");
                        currentTerm = "";
                        inLongComment = false;
                    }

                    if (inString && currentTerm.Contains("\""))
                    {
                        keyLines.Add("\"" + currentTerm);
                        currentTerm = "";
                        inString = false;

                    }
                    switch (charFile[i])
                    {
                        case '£':
                            inComment = false;
                            break;
                        case '¢':
                            if (termInArray(currentTerm.ToLower(), dataTypeKWS) || termInArray(currentTerm, (string[])Globals.userMadeClasses.Cast<string>().ToArray()))
                            {
                                keyLines.Add(currentTerm);
                                currentTerm = "";
                            }
                            break;
                        case '(':
                            keyLines.Add(currentTerm);
                            keyLines.Add("(");
                            curlyBracketLevel += 1;
                            currentTerm = "";
                            break;
                        case '{':
                            keyLines.Add(currentTerm);
                            keyLines.Add("{");
                            curlyBracketLevel += 1;
                            currentTerm = "";
                            break;
                        case '[':
                            keyLines.Add(currentTerm);
                            keyLines.Add("[");
                            bracketLevel += 1;
                            currentTerm = "";
                            break;
                        case ')':
                            keyLines.Add(currentTerm);
                            keyLines.Add(")");
                            curlyBracketLevel -= 1;
                            currentTerm = "";
                            break;
                        case '}':
                            keyLines.Add(currentTerm);
                            keyLines.Add("}");
                            curlyBracketLevel -= 1;
                            currentTerm = "";
                            break;
                        case ']':
                            keyLines.Add(currentTerm);
                            keyLines.Add("]");
                            bracketLevel -= 1;
                            currentTerm = "";
                            break;
                        case '\"':
                            keyLines.Add(currentTerm);
                            currentTerm = "";
                            inString = true;
                            //currentTerm += charFile[i];
                            break;
                        case '=':
                            keyLines.Add(currentTerm);
                            keyLines.Add("=");
                            currentTerm = "";
                            break;
                        case '!':
                            keyLines.Add(currentTerm);
                            keyLines.Add("!");
                            currentTerm = "";
                            break;
                        case ';':
                            //Console.WriteLine("SEMISEMI");
                            currentTerm += charFile[i];
                            keyLines.Add(currentTerm);
                            currentTerm = "";
                            break;
                        default:
                            //if(!inComment && !inLongComment)

                            currentTerm += charFile[i];


                            break;
                    }  //SHAME SHAME SHAME SHAME
                }
                else
                {
                    currentTerm += charFile[i];
                }
                

            }
            else
            {


                if (termInArray(currentTerm, fieldKWS) ) //if the current term is found inside fieldKWS array
                {
                    switch (currentTerm)
                    {
                        case "/*":
                            //Console.WriteLine("FOUND");
                            inLongComment = true;
                            break;
                        case "//":
                            inComment = true;
                            break;
                        default:
                            //Console.WriteLine(currentTerm + "!>!>!");
                            break;


                    }




                    currentTerm = "";
                }
                //else 
                //{
                switch (charFile[i])
                {
                    case '£':
                        inComment = false;
                        break;
                    case '¢':
                        if (termInArray(currentTerm.ToLower(), dataTypeKWS) || termInArray(currentTerm, (string[])Globals.userMadeClasses.Cast<string>().ToArray()))
                        {
                            keyLines.Add(currentTerm);
                            currentTerm = "";
                        }
                        break;
                    case '(':
                        keyLines.Add(currentTerm);
                        keyLines.Add("(");
                        curlyBracketLevel += 1;
                        currentTerm = "";
                        break;
                    case '{':
                        keyLines.Add(currentTerm);
                        keyLines.Add("{");
                        curlyBracketLevel +=1;
                        currentTerm = "";
                        break;
                    case '[':
                        keyLines.Add(currentTerm);
                        keyLines.Add("[");
                        bracketLevel += 1;
                        currentTerm = "";
                        break;
                    case ')':
                        keyLines.Add(currentTerm);
                        keyLines.Add(")");
                        curlyBracketLevel -= 1;
                        currentTerm = "";
                        break;
                    case '}':
                        keyLines.Add(currentTerm);
                        keyLines.Add("}");
                        curlyBracketLevel -= 1;
                        currentTerm = "";
                        break;
                    case ']':
                        keyLines.Add(currentTerm);
                        keyLines.Add("]");
                        bracketLevel -= 1;
                        currentTerm = "";
                        break;
                    case '\"':
                        keyLines.Add(currentTerm);
                        currentTerm = "";
                        inString = true;
                        //currentTerm += charFile[i];
                        break;
                    case '=':
                        keyLines.Add(currentTerm);
                        keyLines.Add("=");
                        currentTerm = "";
                        break;
                    case '!':
                        keyLines.Add(currentTerm);
                        keyLines.Add("!");
                        currentTerm = "";
                        break;
                    case ';':
                        //Console.WriteLine("SEMISEMI");
                        keyLines.Add(currentTerm);
                        keyLines.Add(";");
                        currentTerm = "";
                        break;
                    default:
                        //if(!inComment && !inLongComment)

                        currentTerm += charFile[i];


                        break;
                }

            }

            //}
            //Console.WriteLine(i + " " + currentTerm + " " + (inComment||inLongComment) + Array.IndexOf(fieldKWS, currentTerm));
            
            
            
            currentIndex++;
        }
        for (int j = 0; j < keyLines.Count; j++)
        {
            Console.WriteLine(j + "-------" + keyLines[j]);
        }
        return "uwu";
    }


    public KeyWord_Processor(string id, string inputFile)
    {
        this.inputFile = inputFile;
        this.charFile = inputFile.ToCharArray();
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


    public ArrayList getFlaggedWords()
    {

        //initilaizeDictionary();
        //countKeywords(inputFile);

        //string loggedKWSToString = string.Join(Environment.NewLine, loggedKWS);
        //Console.WriteLine(loggedKWSToString);

        this.executeParseTermsLoop();

        return keyLines;
    }

}
