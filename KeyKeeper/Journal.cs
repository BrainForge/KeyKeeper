using System;
using System.Collections.Generic;

namespace KeyKeeper
{
	public class Journal
	{
		
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
		
		public List<Item> getWorkerItems()
		{ 
			return null; 
		}
		
		public List<Item> getItem()
		{
			return null; 
		}
		
		
		public List<Worker> getActionsByDate(DateTime date)
		{ 
			return null; 
		}
	}
}

