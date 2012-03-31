using System;
using System.Collections.Generic;

namespace KeyKeeper
{
	public class Journal
	{
		public struct journaStructur
		{
			public string FIO;
			public string item_name;
			public DateTime stamp;
			public uint operationID;
			public uint itemID;
		}
		
		public List<Worker> getAllWorkers()
		{
			var listWorker = new List<Worker>();
			listWorker = dbHelper.getAllWorkers();	
			return listWorker;
		}
		
		public static List<Worker> getWorkerOnWork()
		{
			var listWorker = new List<Worker>();
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

