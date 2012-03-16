using System;
using System.Data;
using MySql.Data.MySqlClient;
using KeyKeeper;
using System.Collections.Generic;

namespace KeyKeeper
{
	public class dbHelper : IActionRegistrator
	{
		public dbHelper ()
		{}
		
		public static Worker getWorkerData(uint workerid)
		{
			Worker tmpWorker = null;
			IDataReader reader = dbConnector.getdbAcces().readbd(
				string.Format(@"select *, concat_ws(' ',f,i,o) as fio, concat(f,' ',left(i,1),'. ',left(o,1),'.') as shortfio 
								from workers 
								where id='{0}'",workerid));
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
				@"select *,concat_ws(' ',f,i,o) as fio, concat(f,' ',left(i,1),'. ',left(o,1),'.') as shortfio 
					from workers;");
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
				string.Format(@"select w.*,concat_ws(' ',f,i,o) as fio, concat(f,' ',left(i,1),'. ',left(o,1),'.') as shortfio
				from journal j join workers w on j.worker_id=w.id
				where isnull(j.stamp_end) and j.operation_id={0}",Const::OPERATION_WORK_IN));
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
		
		public int registerAction(Action action)
		{ 
			Utils.showMessageInfo("ee");
			return 0; 
		}
	}
}

