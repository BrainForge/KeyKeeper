using System;

namespace KeyKeeper
{
	public class Action : EventArgs
	{
		public Worker worker;
		public uint worker_reg_type;
		
		public Action(Worker worker, uint workerRegType)
		{}
		
		public Action()
		{}
		
		public virtual void Do(IActionRegistrator registrator) 
		{}
	}
}

