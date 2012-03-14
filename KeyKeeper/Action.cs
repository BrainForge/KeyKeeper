using System;

namespace KeyKeeper
{
	public abstract class Action
	{
		private Worker worker;
		private int worker_reg_type;
		private DateTime stamp = DateTime.Now;
		private int type;
		
		public Action(Worker worker, uint workerRegType)
		{}
		
		public Action()
		{}
		
		public abstract void _do();
	}
}

