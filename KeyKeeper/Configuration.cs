using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace KeyKeeper
{
	public class Configuration
	{
		private string mserver;
		private string mdb;
		private string muser;
		private string mpassword;
		
		public string server{get {return mserver;} set{mserver = value;}}
		public string db{get {return mdb;} set{mdb = value;}}
		public string user{get {return muser;} set{muser = value;}}
		public string password{get {return mpassword;} set{mpassword = value;}}
		
		public Configuration (){}
		
		public static void Serialize(string file, Configuration c)
      	{
         	System.Xml.Serialization.XmlSerializer xs 
            	= new System.Xml.Serialization.XmlSerializer(c.GetType());
         	StreamWriter writer = File.CreateText(file);
         	xs.Serialize(writer, c);
         	writer.Flush();
         	writer.Close();
      	}
		
		public static Configuration Deserialize(string file)
      	{
         	System.Xml.Serialization.XmlSerializer xs 
            	= new System.Xml.Serialization.XmlSerializer(
               	typeof(Configuration));
         	StreamReader reader = File.OpenText(file);
         	Configuration c = (Configuration)xs.Deserialize(reader);
         	reader.Close();
         	return c;
      	}
	}
}

