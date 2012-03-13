using System;
using System.Data;
using MySql.Data.MySqlClient;
using KeyKeeper;

namespace KeyKeeper
{
	public class dbHelper
	{	
		public dbHelper ()
		{}
		
		public static string getFIO(uint workerid)
		{

			string fio = null;
			IDataReader reader = dbConnector.getdbAcces().readbd(
				"select concat_ws(' ',f,i,o) as fio from workers where id='"+workerid+"';");
			try
			{
				reader.Read();
				fio = (string) reader["fio"];
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
		
			reader.Close();
       		reader = null;
		
			return fio;	
		}
		
		public static string getShortFIO(uint workerid)
		{
			string shortFIO = null;
			IDataReader reader = dbConnector.getdbAcces().readbd(
				"select concat(f,' ',left(i,1),'. ',left(o,1),'.') as fio from workers where id='"+workerid+"';");
			try
			{
				reader.Read();
				shortFIO = (string) reader["fio"];
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
			
			reader.Close();
       		reader = null;
			
			return shortFIO;
		}
		
		public static string getPhone(uint workerid)
		{
			string phone = null;
			IDataReader reader = dbConnector.getdbAcces().readbd(
				"SELECT phone FROM keykeeper.workers where id='"+workerid+"';");
			try
			{
				reader.Read();
				phone = (string) reader["phone"];
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
			
			reader.Close();
       		reader = null;
			
			return phone;
			
		}
		
		public static uint getCode(uint workerid)
		{
			uint code = 0;
			IDataReader reader = dbConnector.getdbAcces().readbd(
				"SELECT code FROM keykeeper.workers where id='"+workerid+"';");
			try
			{
				reader.Read();
				code = (uint) reader["code"];
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
			
			reader.Close();
       		reader = null;
			
			return code;
			
			
		}
		
		
	}
}

