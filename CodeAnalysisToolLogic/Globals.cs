using System;
using System.Collections;

public static class Globals
{
    //public const Int32 BUFFER_SIZE = 512; // Unmodifiable
    //public static String FILE_NAME = "Output.txt"; // Modifiable
    //public static readonly String CODE_PREFIX = "US-"; // Unmodifiable

    public static ArrayList userMadeClasses = new ArrayList();

    //EXTREMELY IMPORTANT FIND A WAY TO SHIFT FROM GLOBAL HANDLING TO LOCAL PER STUDENT SO CAN HANDLE BULK STUDENTS
    //ALTERNATIVELY, THIS CAN BE HANDLED ON THE USER INTERFACE APP BY HAVING MULTIPLE INSTANCES OF THIS PROJECT OPENED (one for each student)
}