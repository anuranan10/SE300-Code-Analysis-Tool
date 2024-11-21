using System;
using System.Collections;
using System.Collections.Generic;


public class Process_Manager
{

	int stage = 0;
	string status = "";
    


    Java_File[] allInputFiles;

	public Process_Manager(Java_File[] allInputFiles)
	{
        this.allInputFiles = allInputFiles;
	}
    public Process_Manager(Java_File onlyFile)
    {
        Java_File[] tempFile = { onlyFile };
        this.allInputFiles = tempFile;
    }

    private void setData()
    {
        //establish processes for each file

        //first do a dry run for our terrible way of setting classes.
        foreach(Java_File i in allInputFiles)
        {

            TextFormatter localTF = new TextFormatter(i.id, i.fileStringArray);
            string localTFSTRING = localTF.formatFile();
            KeyWord_Processor localKWP = new KeyWord_Processor(i.id, localTFSTRING);
            Code_Analyzer localCA = new Code_Analyzer(i.id, localKWP.getFlaggedWords());


            string[] testResults = localCA.getAnalytics();
            for (int j = 0; j < testResults.Length;j++)
            {
                Console.WriteLine(testResults[j]);
            }

        }



    }



    public void printFinalData()
    {
        setData();



    }

    //using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))






}


    

