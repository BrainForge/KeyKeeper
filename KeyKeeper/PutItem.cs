using System;

namespace KeyKeeper
{
	public class PutItem : Action
	{
		Item item;
		int itemRegType;
		
		public PutItem (Worker worker, 
		     int workerRegType, Item item, int itemRegType)
		{
			this.item = item;
			this.itemRegType = itemRegType;
		}
		
		public override void Do (IActionRegistrator registrator)
		{
			registrator.registerAction("now()", 
			                           Const.OPERATION_ITEM_PUT.ToString(),
			                           worker.id().ToString(),
			                           worker_reg_type.ToString(),
			                           item.id().ToString(),
			                           itemRegType.ToString());
		}
	}
}

