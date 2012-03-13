using System;
using System.Collections.Generic;
using KeyKeeper;

namespace KeyKeeper
{
	public class Worker
	{
		private uint mid;
		public string FIO = null;
		public string shortFIO = null;
		public string phone = null;
		public uint code = 0;
		
		public Worker (uint workerID)
		{
			mid = workerID;
		}
		
		public string getFIO()
		{
			if(FIO == null)
				FIO = dbHelper.getFIO(mid);
			return FIO;
		}
		
		public string getShortFIO()
		{
			if(shortFIO == null)
				shortFIO = dbHelper.getShortFIO(mid);
			return shortFIO;
		}
		
		public string getPhone()
		{
			if(phone == null)
				phone = dbHelper.getPhone(mid);
			return phone;
		}
		
		public uint getCode()
		{
			if(code == 0)
				code = dbHelper.getCode(mid);
			return code;
		}
		
		public List<Item> getItems()
		{return null;}
		
		
		public uint id()
		{
			return mid;
		}
		
	}
}

