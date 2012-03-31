using System;
using System.Collections.Generic;

namespace KeyKeeper
{
	public class Journal
	{
		#region структуры для удобства
		
		public struct journaStructur
		{
			public string FIO;
			public string item_name;
			public DateTime stamp;
			public uint operationID;
			public uint itemID;
		}
		
		public struct workerStruct
		{
			public Worker worker;
			public string key;
		}
		
		#endregion
		
		public List<workerStruct> getAllWorkers()
		{
			var listWorker = new List<workerStruct>();
			listWorker = dbHelper.getAllWorkers();	
			return listWorker;
		}
		
		public List<workerStruct> getWorkerOnWork()
		{
			var listWorker = new List<workerStruct>();
			listWorker = dbHelper.getWorkersOnWork();	
			return listWorker;
		}
		
		public static List<Item> getWorkerItems(uint id)
		{ 
			var listItems = new List<Item>();
			listItems = dbHelper.getAllItemByWorker(id);
			return listItems; 
		}
		
		public static List<Item> getItems()
		{
			var listItems = new List<Item>();
			listItems = dbHelper.getAllItem();
			return listItems; 
		}
		
		
		public List<journaStructur> getActionsByDate(string date)
		{
			var listAction = new List<journaStructur>();
			listAction = dbHelper.getActionsByDate(date);
			return listAction; 
		}
	}
}

