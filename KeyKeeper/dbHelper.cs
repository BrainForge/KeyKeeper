using System;
using System.Data;
using MySql.Data.MySqlClient;
using KeyKeeper;
using System.Collections.Generic;

namespace KeyKeeper
{
	public class dbHelper
	{
		public dbHelper ()
		{}
		
		public static Worker getWorkerData(uint workerid)
		{
			Worker tmpWorker = null;
			IDataReader reader = dbConnector.getdbAcces().readbd(
				"select *, concat_ws(' ',f,i,o) as fio, concat(f,' ',left(i,1),'. ',left(o,1),'.') as shortfio from workers where id='"+workerid+"';");
			try
			{
				reader.Read();
				tmpWorker= new Worker((uint)reader["id"], (string)reader["fio"],
				                          (string)reader["shortfio"],(string)reader["phone"],(uint)reader["code"]);
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
		
			reader.Close();
       		reader = null;
			return tmpWorker;
		}
		
		public static List<Worker> getAllWorkers()
		{
			var list = new List<Worker>();
			
			IDataReader reader = dbConnector.getdbAcces().readbd(
				"select *,concat_ws(' ',f,i,o) as fio, concat(f,' ',left(i,1),'. ',left(o,1),'.') as shortfio from workers;");
			try
			{
				while(reader.Read())
					list.Add(new Worker((uint)reader["id"], (string)reader["fio"],
				                          (string)reader["shortfio"],(string)reader["phone"],(uint)reader["code"]));
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
		
			reader.Close();
       		reader = null;
			
			
			return list;
			
		}
		
		public static List<Worker> getWorkersOnWork()
		{
			var list = new List<Worker>();
			
			IDataReader reader = dbConnector.getdbAcces().readbd(
				@"select w.*,concat_ws(' ',f,i,o) as fio, concat(f,' ',left(i,1),'. ',left(o,1),'.') as shortfio
				from journal j join workers w on j.worker_id=w.id
				where isnull(j.stamp_end) and j.operation_id=1");
			try
			{
				while(reader.Read())
					list.Add(new Worker((uint)reader["id"], (string)reader["fio"],
				                          (string)reader["shortfio"],(string)reader["phone"],(uint)reader["code"]));
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
		
			reader.Close();
       		reader = null;
			
			
			return list;
			
		}
		
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

