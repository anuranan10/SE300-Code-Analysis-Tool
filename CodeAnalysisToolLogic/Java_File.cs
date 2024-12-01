using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Java_File
{
	//relevant information for the file itself
	string filePath;
	public string[] fileStringArray;


	//what attributes does a java file have that the program or user would want to know?
	public string id;
	int linesTotal;
	int linesExecutable;

	int deepestCodeDepth;

	int amountOfAttributes;
	int amountOfMethods;
    int amountOfStaticAttributes;
    int amountOfStaticMethods;


    int amountOfForLoops;
	int amountOfWhileLoops;
	int amountOfIfstatements;

	string[] idsOfAssociated;

	Dictionary<string, int> keywordCounter; // assign loggedkws from text formatter to this;
	List<Mthd> mthds = new List<Mthd>();
	List<Attrib> attribs = new List<Attrib>();

    public Java_File(string id, string filePath)
	{
		this.id = id;
		this.filePath = filePath;
        this.fileStringArray = File.ReadAllLines(filePath);
    }

	public void printFile()
	{
        
		for(int i = 0; i < fileStringArray.Length; i++)
		{
			Console.WriteLine(fileStringArray[i]);
		}
    }

	public string[] toArray() //WILL NOT RETURN VOID LATER
	{
		return fileStringArray;
	}
}