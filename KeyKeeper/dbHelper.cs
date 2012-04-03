using System;
using System.Data;
using MySql.Data.MySqlClient;
using KeyKeeper;
using System.Collections.Generic;

namespace KeyKeeper
{
	public class dbHelper : IActionRegistrator
	{
		
		public struct DateOrWorker
		{
			public uint item_id;
			public uint worker_id;
			public string name;
			public uint item_tupe;
			public string FIO;
			public string time;
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
		
		public static List<Journal.workerStruct> getAllWorkers()
		{
			var list = new List<Journal.workerStruct>();
			
			IDataReader reader = dbConnector.getdbAcces().readbd(
				@"SELECT w.*, concat_ws(' ',w.f,w.i,w.o) as fio, concat(w.f,' ',left(w.i,1),'. ',left(w.o,1),'.') as shortfio,
					GROUP_CONCAT('[',i.name,']' SEPARATOR ' ') items FROM workers w
					left join journal j on w.id=j.worker_id and j.operation_id=3 and isnull(j.stamp_end)
					left join items i on j.item_id = i.id
					GROUP BY w.id
					order by f;");
			try
			{
				while(reader.Read())
				{
					Journal.workerStruct workerStruct = new Journal.workerStruct();
					workerStruct.worker = new Worker((uint)reader["id"], 
										(string)reader["fio"],
				                        (string)reader["shortfio"],
										(string)reader["phone"],
										(uint)reader["code"]);
					if(reader["items"] != DBNull.Value)
						workerStruct.key = (string) reader["items"];
					else
						workerStruct.key = "";
					list.Add(workerStruct);
				}

										
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
		
			reader.Close();
       		reader = null;
	
			return list;	
		}
		
		public static List<Journal.workerStruct> getWorkersOnWork()
		{
			var list = new List<Journal.workerStruct>();
			
			IDataReader reader = dbConnector.getdbAcces().readbd(
				string.Format(@"select w.*,concat_ws(' ',f,i,o) as fio, concat(f,' ',left(i,1),'. ',left(o,1),'.') as shortfio
								,GROUP_CONCAT('[',i.name,']' SEPARATOR ' ') items
								from journal j 
								join workers w on j.worker_id=w.id
								left join journal jj on w.id=jj.worker_id and jj.operation_id={1} and isnull(jj.stamp_end)
								left join items i on jj.item_id = i.id 
								where isnull(j.stamp_end) and j.operation_id={0}
								GROUP BY w.id
								ORDER BY f;",Const.OPERATION_WORK_IN, Const.OPERATION_ITEM_GET));
			try
			{
				while(reader.Read())
				{
					Journal.workerStruct workerStruct = new Journal.workerStruct();
					workerStruct.worker = new Worker((uint)reader["id"], 
										(string)reader["fio"],
				                        (string)reader["shortfio"],
										(string)reader["phone"],
										(uint)reader["code"]);
					
					if(reader["items"] != DBNull.Value)
					{
						workerStruct.key = (string) reader["items"];
					}
					else
						workerStruct.key = "";
					list.Add(workerStruct);
				}
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
		
			reader.Close();
       		reader = null;
			
			
			return list;
			
		}
		
		public static Worker getWorkerByCode(string code)
		{
			Worker tmpWorker = null;
			IDataReader reader = dbConnector.getdbAcces().readbd(
				
				string.Format(@"SELECT w.*, 
								concat_ws(' ',f,i,o) as fio, 
								concat(f,' ',left(i,1),'. ',left(o,1),'.') as shortfio, cw.description
								FROM code2worker cw
								join workers w on w.id = cw.worker_id
								where cw.code = '{0}'",code));
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
		
		public static Item getItemData(uint id)
		{
			Item tmpItem = null;
			IDataReader reader = dbConnector.getdbAcces().readbd(
				
				string.Format(@"select * 
								from items
								where id='{0}'",id));
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
		
		public static List<DateOrWorker> getWorkerOrStamp()
		{
			List<DateOrWorker> list = new List<DateOrWorker>();

			IDataReader reader = dbConnector.getdbAcces().readbd(
				string.Format(@"SELECT i.id item_id, w.id worker_id, i.name item_name, i.type item_type, 
								concat(f,' ',left(i,1),'. ',left(o,1),'.') as shortfio,
								stamp `time`
								FROM items i 
								left join journal j on i.id=j.item_id and j.operation_id={0} and isnull(j.stamp_end)
								left join workers w on w.id=j.worker_id
								ORDER BY i.name;",
			              		Const.OPERATION_ITEM_GET)
								);
			try
			{
				while(reader.Read())
				{
					DateOrWorker dateTimeOrWorker = new DateOrWorker();
					
					dateTimeOrWorker.item_id = (uint)reader["item_id"];
					dateTimeOrWorker.name = (string)reader["item_name"];
					dateTimeOrWorker.item_tupe = (uint)reader["item_type"];
					
					if(reader["worker_id"] != DBNull.Value)
					{
						dateTimeOrWorker.worker_id = (uint)reader["worker_id"];
						dateTimeOrWorker.FIO = (string)reader["shortfio"];
						dateTimeOrWorker.time = ((DateTime)reader["time"]).TimeOfDay.ToString();
					}
					else
					{
						dateTimeOrWorker.worker_id = 0;
						dateTimeOrWorker.FIO = "";
						dateTimeOrWorker.time = "";
					}

					list.Add(dateTimeOrWorker);
					
				}
			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
		
			reader.Close();
       		reader = null;

			return list;	
		}
		
		public static List<Item> getPopItem(uint id)
		{
			List<Item> list = new List<Item>();
			
			IDataReader reader = dbConnector.getdbAcces().readbd(
				string.Format(@"select i.*, x.cnt from
								(
								SELECT item_id, count(*) cnt
								FROM journal
								WHERE stamp > now() - INTERVAL 1 MONTH 
								and operation_id={0} 
								and worker_id={1} 
								and item_id not in (
								select item_id 
								from journal 
								where operation_id={0} and isnull(stamp_end)
								)
								GROUP BY item_id
								ORDER BY count(*) desc
								limit 0,5
								) x
								JOIN items i on x.item_id=i.id
								ORDER BY i.name;",Const.OPERATION_ITEM_GET, id)
				);
			
			try
			{
				while(reader.Read())
				{	
					list.Add(new Item((uint)reader["id"],(string)reader["name"],(uint)reader["type"],(uint)reader["code"]));
				}
				

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
		
		#region журнальные манипуляции
		
		public static List<Journal.journaStructur> getActionsByDate(string dateTime)
		{
			List<Journal.journaStructur> journal = new List<Journal.journaStructur>();

			
			IDataReader reader = dbConnector.getdbAcces().readbd(
				string.Format(@"select i.name, j.item_id, j.stamp, j.operation_id , concat(f,' ',left(i,1),'. ',left(o,1),'.') as shortfio from journal j
								left join workers w on j.worker_id = w.id 
								left join items i on j.item_id = i.id
								where date(j.stamp) = '{0}'
								order by stamp;",
			              		dateTime)
								);
			try
			{
				while(reader.Read())
				{
					Journal.journaStructur journalStruct = new Journal.journaStructur();
					journalStruct.FIO = (string)reader["shortfio"];
					journalStruct.stamp = (DateTime)reader["stamp"];
					journalStruct.operationID = (uint)reader["operation_id"];				
					
					if(reader["item_id"] != DBNull.Value)
					{
						journalStruct.itemID = (uint)reader["item_id"];
						journalStruct.item_name = (string)reader["name"];
					}
					else
					{
						journalStruct.itemID = 0;
						journalStruct.item_name = "";
					}
					
					journal.Add(journalStruct);
				}
				

			}
			catch(MySqlException ex)
			{
				Utils.showMessageError(ex.ToString());
			}
		
			reader.Close();
       		reader = null;

			return journal;	
		}
		
		#endregion
		
	}
}

