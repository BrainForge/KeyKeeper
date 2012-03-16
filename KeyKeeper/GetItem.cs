using System;

namespace KeyKeeper
{
	public class GetItem : Action
	{
		private Item item;
		private uint itemRegType;

		
		public GetItem (Worker worker, 
		     uint worker_reg_type, Item item, uint itemRegType)
		{
			base.worker = worker;
			base.worker_reg_type = worker_reg_type;
			this.item = item;
			this.itemRegType = itemRegType;
		}
		
		public override void Do (IActionRegistrator registrator)
		{
					registrator.registerAction("now()", 
			                           Const.OPERATION_ITEM_GET.ToString(),
			                           base.worker.id().ToString(),
			                           base.worker_reg_type.ToString(),
			                           item.id().ToString(),
			                           itemRegType.ToString());
	
		}
	}
}

