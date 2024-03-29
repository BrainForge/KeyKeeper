using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace KeyKeeper
{
	/// <summary>
	/// forevel alone db connector
	/// </summary>
	public class dbConnector
	{
		private static dbConnector mdb;
		private MySqlConnection dbcon;
		private Configuration conf;
		
		private dbConnector ()
		{
		
		System.Reflection.Assembly a = System.Reflection.Assembly.GetEntryAssembly();
		string baseDir = System.IO.Path.GetDirectoryName(a.Location);
		conf = Configuration.Deserialize(baseDir+"/config.xml");
			
			string connectionString = string.Format(@"Server={0}; Database={1}; User ID={2}; Password={3}; 
									charset=utf8; Pooling=false",conf.server,conf.db,conf.user,conf.password);
			
			try
			{
      			dbcon = new MySqlConnection(connectionString);
       			dbcon.Open();
			}
			catch
			{
				Utils.showMessageError("что-то пошло не так(");
			}
		}
		
		public static dbConnector getdbAcces()
		{
			if(mdb == null)
				mdb = new dbConnector();
			return mdb;
		}
		
		public void close()
		{
			dbcon.Close();
		}
		
		private bool getConnectionState()
		{
			return (dbcon.State == ConnectionState.Open);
		}
		
		public void querydb(string com)
		{
			if(getConnectionState())
			{
				MySqlCommand myCommand = new MySqlCommand(com);
				myCommand.Connection = dbcon;
				if(myCommand.ExecuteNonQuery()==0)
					Utils.showMessageError("что-то пошло не так");
				myCommand = null;
			}
		}
		
		public IDataReader readbd(string com)
		{
			IDataReader reader = null;
			if(getConnectionState())
			{
				MySqlCommand myCommand = new MySqlCommand(com);
				myCommand.Connection = dbcon;
				reader = myCommand.ExecuteReader();
			}
			return reader;
		}
		
		
	}
}

