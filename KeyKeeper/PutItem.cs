using System;

namespace KeyKeeper
{
	public class PutItem : Action
	{
	
		public PutItem (Worker worker, 
		     uint workerRegType, Item item, uint itemRegType)
		{
			base.worker = worker;
			base.worker_reg_type = workerRegType;
			
			base.item = item;
			base.item_reg_type = itemRegType;
		}
		
		public override void Do (IActionRegistrator registrator)
		{
			registrator.updateAction(item.isFree(worker.id()));
			registrator.registerAction("now()",
			                           Const.OPERATION_ITEM_PUT.ToString(),
			                           worker.id().ToString(),
			                           worker_reg_type.ToString(),
			                           item.id().ToString(),
			                           item_reg_type.ToString());
		}
	}
}

