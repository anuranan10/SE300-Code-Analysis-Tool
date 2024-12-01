using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeAnalysisToolLogic.Models
{
    public class CodeAnalyzer
    {

        string id;
        List<string> terms = new List<string>();
        string[] report = { "" };

        string currentClass = "";

        int maxDepth = 0;
        int attributes = 0;

        public CodeAnalyzer(string filePath)
        {
            this.id = Guid.NewGuid().ToString();
            this.terms = new List<string>(System.IO.File.ReadAllLines(filePath));
        }

        public CodeAnalyzer(string id, List<string> keyLines)
        {
            this.id = id;
            this.terms = keyLines;
        }

        private void scanTerms()
        {
            bool skippingLine = false;
            bool inArguments = false; //are we currently reading arguments for a specific constructor or method??

            int bracketLevel = 0;
            int parenthesisLevel = 0;
            int curlyBracketLevel = 0; // when curly bracket level is 1, you should be inside the primary class

            string currentTerm;
            string nextTerm;
            string nextNextTerm;
            string lastTerm;


            List<Attrib> codeAttribs = new List<Attrib>();
            for (int i = 0; i < terms.Count; i++)
            {
                currentTerm = terms[i];
                if (i > 0) { lastTerm = terms[i - 1]; } else { lastTerm = "$!"; }
                if (i < terms.Count - 1) { nextTerm = terms[i + 1]; } else { nextTerm = "$!"; }
                if (i < terms.Count - 2) { nextNextTerm = terms[i + 2]; } else { nextNextTerm = "$!!"; }

                currentTerm = currentTerm.Trim();
                nextTerm = nextTerm.Trim();
                lastTerm = lastTerm.Trim();


                if (!skippingLine)
                {

                    if (currentTerm.Contains("\""))
                    {
                        currentTerm = "SOMESTRING$!";
                    }


                    //if(termInArray(currentTerm, (string[])Globals.userMadeClasses.ToArray())){

                    //}

                    switch (currentTerm.ToLower())
                    {
                        case "import":
                            skippingLine = true;
                            break;
                        case "class":
                            Globals.userMadeClasses.Add(nextTerm);
                            break;
                        case "int":
                            if (curlyBracketLevel == 1 && nextTerm != "[" && parenthesisLevel == 0)//inArguments == false)
                            {
                                if (nextNextTerm != "(")
                                {
                                    codeAttribs.Add(new Attrib(getModf(lastTerm), "int", nextTerm));
                                }
                                else
                                {
                                    // codeMthds.Add(new Mthd("int", nextTerm));
                                }

                            }
                            break;
                        case "double":
                            if (curlyBracketLevel == 1 && nextTerm != "[" && parenthesisLevel == 0)//inArguments == false)
                            {
                                if (nextNextTerm != "(")
                                {
                                    codeAttribs.Add(new Attrib(getModf(lastTerm), "double", nextTerm));
                                }
                                else
                                {
                                    // codeMthds.Add(new Mthd("double", nextTerm));
                                }

                            }
                            break;
                        case "string":
                            if (curlyBracketLevel == 1 && nextTerm != "[" && parenthesisLevel == 0)//inArguments == false)
                            {
                                if (nextNextTerm != "(")
                                {
                                    codeAttribs.Add(new Attrib(getModf(lastTerm), "string", nextTerm));
                                }
                                else
                                {
                                    // codeMthds.Add(new Mthd("string", nextTerm));
                                }

                            }


                            break;
                        case "{":
                            curlyBracketLevel += 1;
                            //Console.WriteLine("RHAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA " +curlyBracketLevel);
                            break;
                        case "}":
                            curlyBracketLevel -= 1;
                            break;
                        case "(":
                            parenthesisLevel += 1;
                            break;
                        case ")":
                            parenthesisLevel -= 1;
                            break;
                        default:
                            break;

                    }



                }


                else
                {
                    skippingLine = !(currentTerm.Contains(";"));

                }

                Console.WriteLine(i + "-----" + terms[i] + " " + curlyBracketLevel); // the blank lines are "" empty strings
            }

            Console.WriteLine("*********");
            for (int i = 0; i < codeAttribs.Count; i++)
            {
                Console.WriteLine("\n" + codeAttribs[i].type + ", " + codeAttribs[i].name);
            }

        }



        private string getModf(string last)
        {
            if (last == "")
            {

            }
            return last;
        }

        private bool termInArray(string term, string[] target)
        {
            return Array.IndexOf(target, term) > -1;
        }

        public string[] getAnalytics()
        {


            scanTerms();

            return this.report;
        }
    }
}