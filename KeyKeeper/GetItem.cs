using System;

namespace KeyKeeper
{
	public class GetItem : Action
	{
		public GetItem (Worker worker, 
		     uint worker_reg_type, Item item, uint itemRegType)
		{
			base.worker = worker;
			base.worker_reg_type = worker_reg_type;
			
			base.item = item;
			base.item_reg_type = itemRegType;
		}
		
		public override void Do (IActionRegistrator registrator)
		{
			
			registrator.registerAction("null",
			                           Const.OPERATION_ITEM_GET.ToString(),
			                           worker.id().ToString(),
			                           worker_reg_type.ToString(),
			                           item.id().ToString(),
			                           item_reg_type.ToString());
	
		}
	}
}

