using System;


//Later we can get more advanced by using this as a abstract class for each datatype and attribute type and each type has unique interactions
public class Attrib
{
	public string type;
	public string name;
	public string modf;
	public Attrib(string modf, string type, string name) 

	{
		this.type = type;
		this.name = name;
		this.modf = modf;
	}
}
