using System;

namespace KeyKeeper
{
	public class Item
	{
		private string name;
		private uint type = 0;
		private uint code = 0;
		private uint item_id = 0;
		
		public Item (uint id)
		{	
			this.item_id = id;
		}
		
		public Item(uint id, string name, uint type, uint code)
		{
			this.item_id = id;
			this.name = name;
			this.type = type;
			this.code = code;
		}
		
		private void getItem()
		{
			this.name = getName();
			this.type = getType();
			this.code = getCode();
		}
		
		public uint id()
		{
			return this.item_id;
		}

		public string getName()
		{
			if(string.IsNullOrEmpty(name))
				getItem();
			return name;
		}
		
		public uint getType()
		{
			if(type == 0)
				getItem();
			return type;
		}
		
		public uint getCode()
		{
			if(code == 0)
				getItem();
			return code;
		}
		
		public uint isFree()
		{
			return dbHelper.getJournalID(id());
		}
		
	}
}

