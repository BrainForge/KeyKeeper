using System;
using System.Data;
using MySql.Data.MySqlClient;
using KeyKeeper;
using System.Collections.Generic;

namespace KeyKeeper
{
	public class dbHelper : IActionRegistrator
	{
		//update journal set stamp_end=now(), operation_id = 2 where id = 1;
		
		public struct DateOrWorker
		{
			public DateTime dateTime;
			public Worker worker;
		}
			
		
		public dbHelper ()
		{}
		
		#region всякие операции с сотрудниками
		
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
		
		public static uint getWorkerOnWorkJournalID(uint workerID)
		{
			uint id = 0;
			IDataReader reader = dbConnector.getdbAcces().readbd(
			string.Format(@"select id from journal 
							where worker_id = {0} and isnull(stamp_end) and operation_id={1};",
							workerID,
							Const.OPERATION_WORK_IN));
			try
			{
				if(reader.Read())
				{
					if(reader.FieldCount==1)
						id = (uint)reader["id"];
					else
					{
						Utils.showMessageError("Что-то пошло не так...");
					}
				}
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
		
			reader.Close();
       		reader = null;
			Console.WriteLine("id in journal - "+id);
			return id;
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
					list.Add(new Worker((uint)reader["id"], 
										(string)reader["fio"],
				                        (string)reader["shortfio"],
										(string)reader["phone"],
										(uint)reader["code"])
										);
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
				where isnull(j.stamp_end) and j.operation_id={0}",Const.OPERATION_WORK_IN));
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
		
		#endregion
		
		#region экшены
		public int registerAction( 
		                   string stamp_end, 
		                   string operation_id, 
		                   string worker_id, 
		                   string worker_reg_type,
		                   string item_id,
		                   string item_reg_type)
		{

			dbConnector.getdbAcces().querydb(string.Format(@"insert into journal 
															(`stamp_end`,`operation_id`,`worker_id`,`worker_reg_type`,`item_id`,`item_reg_type`) 
															values
															({0},{1},{2},{3},{4},{5})",
			                                               stamp_end,
			                                               operation_id,
			                                               worker_id,
			                                               worker_reg_type,
			                                               item_id,
			                                               item_reg_type));
			return 0; 
		}
		
		public int updateAction(uint journalID)
		{
			dbConnector.getdbAcces().querydb(string.Format(@"update journal
															set stamp_end=now() 
															where id = {0}", journalID));
			return 0;
		}
		#endregion
		
		#region всякие манипуляции с итемами
		
		public static Item getItemData(uint workerid)
		{
			Item tmpItem = null;
			IDataReader reader = dbConnector.getdbAcces().readbd(
				
				string.Format(@"select * 
								from items
								where id='{0}'",workerid));
			try
			{
				reader.Read();
				tmpItem= new Item((uint)reader["id"], (string)reader["name"],
					(uint)reader["type"], (uint)reader["code"]);	 
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
		
			reader.Close();
       		reader = null;
			return tmpItem;
		}
		
		public static List<Item> getAllItem()
		{
			var list = new List<Item>();
			
			IDataReader reader = dbConnector.getdbAcces().readbd(
				@"select *
				  from items;");
			try
			{
				while(reader.Read())
					list.Add(new Item((uint)reader["id"], 
										(string)reader["name"],
				                        (uint)reader["type"],
										(uint)reader["code"]));
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
		
			reader.Close();
       		reader = null;
	
			return list;	
		}
		
		public static List<Item> getAllItemByWorker(uint id)
		{
			var list = new List<Item>();
			
			IDataReader reader = dbConnector.getdbAcces().readbd(
				string.Format(@"SELECT i.* FROM items i 
								join journal j on i.id = j.item_id
         						where isnull(j.stamp_end) and j.operation_id = {0} and j.worker_id = {1};",
			              		Const.OPERATION_ITEM_GET,id));
			try
			{
				while(reader.Read())
					list.Add(new Item((uint)reader["id"], 
										(string)reader["name"],
				                        (uint)reader["type"],
										(uint)reader["code"]));
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
		
			reader.Close();
       		reader = null;
	
			return list;	
		}
		
		public static List<Item> getItemByType(uint type)
		{
			var list = new List<Item>();
			
			IDataReader reader = dbConnector.getdbAcces().readbd(
				string.Format(@"SELECT * FROM items i 
         						where type = {0}",
			              		type));
			try
			{
				while(reader.Read())
					list.Add(new Item((uint)reader["id"], 
										(string)reader["name"],
				                        (uint)reader["type"],
										(uint)reader["code"]));
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
		
			reader.Close();
       		reader = null;
	
			return list;	
		}
		
		public static uint getJournalID(uint itemId)
		{
			uint id = 0;
			IDataReader reader = dbConnector.getdbAcces().readbd(
			string.Format(@"SELECT id FROM journal
        	 				where isnull(stamp_end) and operation_id = {0} and item_id = {1};",
							Const.OPERATION_ITEM_GET
							,itemId));
			try
			{
				if(reader.Read())
				{
					if(reader.FieldCount==1)
						id = (uint)reader["id"];
					else
					{
						Utils.showMessageError("Что-то пошло не так...");
					}
				}
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
		
			reader.Close();
       		reader = null;
			Console.WriteLine("id in journal - "+id);
			return id;
		}
		
		public static DateOrWorker getWorkerOrStamp(uint itemID)
		{
			Worker worker;
			DateTime dateOrWorker;
			DateOrWorker dateTimeOrWorker = new DateOrWorker();
			
			IDataReader reader = dbConnector.getdbAcces().readbd(
				string.Format(@"select j.stamp, w.*, concat_ws(' ',f,i,o) as fio, concat(f,' ',left(i,1),'. ',left(o,1),'.') as shortfio from journal j
								join workers w on j.worker_id = w.id
								where isnull(stamp_end) and operation_id = {0} and item_id = {1};",
			              		Const.OPERATION_ITEM_GET, itemID)
								);
			try
			{
				reader.Read();
				
				worker = new Worker((uint)reader["id"], 
										(string)reader["fio"],
				                        (string)reader["shortfio"],
										(string)reader["phone"],
										(uint)reader["code"]);
				
				
				
				dateOrWorker = (DateTime)reader["stamp"];	
				
				dateTimeOrWorker.worker = worker;
				dateTimeOrWorker.dateTime = dateOrWorker;
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
		
			reader.Close();
       		reader = null;

			return dateTimeOrWorker;	
		}
		
		#endregion

		
	}
}

