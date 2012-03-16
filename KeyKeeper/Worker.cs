using System;
using System.Collections.Generic;
using KeyKeeper;

namespace KeyKeeper
{
	public class Worker
	{
		private uint mid;
		private string FIO = null;
		private string shortFIO = null;
		private string phone = null;
		private uint code = 0;
		private int idWorkerOnWork = 0;
		
		public Worker(uint workerID)
		{
			mid = workerID;	
		}
		
		public Worker(uint _id, string FIO, string shortFIO, string phone, uint code)
		{
			this.mid = _id;
			this.FIO = FIO;
			this.shortFIO = shortFIO;
			this.phone = phone;
			this.code = code;
		}
		
		private void getWorker()
		{
			var tmpWorker = dbHelper.getWorkerData(mid);
			
			//this.mid = tmpWorker.id();
			this.FIO = tmpWorker.getFIO();
			this.shortFIO = tmpWorker.getShortFIO();
			this.phone = tmpWorker.getPhone();
			this.code = tmpWorker.getCode();
		}
		
		public string getFIO()
		{
			if(FIO == null)
				getWorker();
			return FIO;
		}
		
		public string getShortFIO()
		{
			if(shortFIO == null)
				getWorker();
			return shortFIO;
		}
		
		public string getPhone()
		{
			if(phone == null)
				getWorker();
			return phone;
		}
		
		public uint getCode()
		{
			if(code == 0)
				getWorker();
			return code;
		}
		
		public uint isOnWork()
		{
			return dbHelper.getWorkerOnWorkJournalID(mid);
		}
		
		public List<Item> getItems()
		{return null;}
			
		public uint id()
		{
			return mid;
		}
		
		public override string ToString ()
		{
			return getShortFIO();
		}
		
	}
}

