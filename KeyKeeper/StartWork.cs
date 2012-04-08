using System;

namespace KeyKeeper
{
	public class StartWork : Action
	{
		public StartWork(Worker worker, uint worker_reg_type) {
			base.worker = worker;
			base.worker_reg_type = worker_reg_type;
		}

		public override void Do (IActionRegistrator registrator)
		{
			Console.WriteLine("{0} Пришел на работу", worker.getShortFIO());
			
			if(worker.isOnWork() == 0)
				   registrator.registerAction("null", 
			                      	   Const.OPERATION_WORK_IN.ToString(),
			                           base.worker.id().ToString(),
			                           base.worker_reg_type.ToString(),
			                           "null",
			                           "null");
			else
				Console.WriteLine("Уже на работе!!!1");
		}
		
		
		
		
		
	}
}

