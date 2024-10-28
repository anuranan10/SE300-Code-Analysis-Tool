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


    //using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))






}


    

