using System;

namespace KeyKeeper
{
	public class EndWork : Action
	{
		public EndWork(Worker worker, uint worker_reg_type) {
			base.worker = worker;
			base.worker_reg_type = worker_reg_type;
		}
		public void Do (IActionRegistrator registrator)
		{
						registrator.registerAction("now()", 
			                           Const.OPERATION_WORK_OUT.ToString(),
			                           base.worker.id().ToString(),
			                           base.worker_reg_type.ToString(),
			                           "null",
			                           "null");

		}
	}
}

