using System;

namespace KeyKeeper
{
	public class Item
	{
		private string name;
		private uint type;
		private uint code;
		private uint item_id;
		
		public Item (uint id)
		{	
			this.item_id = id;
		}
		
		public uint id() {
			return this.item_id;
		}

		public string getName()
		{return null;}
		
		public int getType()
		{return 0;}
		
		public int getCode()
		{return 0;}
		
		public int owner()
		{return 0;}
		
	}
}

