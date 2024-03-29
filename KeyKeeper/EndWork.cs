using System;

namespace KeyKeeper
{
	public class EndWork : Action
	{
		public EndWork(Worker worker, uint worker_reg_type) {
			base.worker = worker;
			base.worker_reg_type = worker_reg_type;
		}
		
		public override void Do(IActionRegistrator registrator)
		{
			Console.WriteLine("{0} ушел с работы", worker.getShortFIO());
			foreach(KeyKeeper.Item item in Journal.getWorkerItems(worker.id()))
				new PutItem(worker,Const.HAND_OPERATION,
			                           item,Const.HAND_OPERATION).Do(registrator);
				
			registrator.updateAction(worker.isOnWork());
			registrator.registerAction("now()", 
			                           Const.OPERATION_WORK_OUT.ToString(),
			                           base.worker.id().ToString(),
			                           base.worker_reg_type.ToString(),
			                           "null",
			                           "null");
		}
	}
}

