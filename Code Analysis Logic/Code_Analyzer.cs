using System;
using System.Collections;

public class Code_Analyzer
{

	string id;
	ArrayList terms = new ArrayList();
    string[] report = { "" };

	string currentClass = "";
	
	int maxDepth = 0;
	int attributes = 0;

    public Code_Analyzer(string id, ArrayList keyLines)
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
            currentTerm = (string)terms[i];
			if (i > 0) {  lastTerm = (string)terms[i - 1]; } else {  lastTerm = "$!";  }
			if (i < terms.Count - 1) {  nextTerm = (string)terms[i + 1]; } else {  nextTerm = "$!"; }
            if (i < terms.Count - 2) { nextNextTerm = (string)terms[i + 2]; } else { nextNextTerm = "$!!"; }

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
						if	(curlyBracketLevel == 1)
						{
                            codeAttribs.Add(new Attrib("int", nextTerm));
                        }
							
							break;
						case "string":
						if (curlyBracketLevel == 1 && nextTerm != "[" && parenthesisLevel == 0)//inArguments == false)
                        {
							if(nextNextTerm != "(")
							{
                                codeAttribs.Add(new Attrib("string", nextTerm));
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
			
			Console.WriteLine(i +"-----" + terms[i] + " " + curlyBracketLevel); // the blank lines are "" empty strings
		}

		Console.WriteLine("*********");
		for(int i = 0; i < codeAttribs.Count; i++)
		{
            Console.WriteLine("\n" + codeAttribs[i].type + ", " + codeAttribs[i].name);
        }
		
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
