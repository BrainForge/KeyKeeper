using System;

namespace KeyKeeper
{
	public class Action : EventArgs
	{
		public Worker worker;
		public uint worker_reg_type;
		private DateTime stamp = DateTime.Now;
		private uint type;
		
		public Action(Worker worker, uint workerRegType)
		{}
		
		public Action()
		{}
		
		public void Do(IActionRegistrator registrator) 
		{}
	}
}

