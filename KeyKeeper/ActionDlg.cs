using System;

namespace KeyKeeper
{
	
	public partial class ActionDlg : Gtk.Dialog
	{
		public delegate void dlgActionSelectedIventHedler (object sender, Action ca);
		public event dlgActionSelectedIventHedler actionSelectedIvent;
		
		public delegate void clickHeader(object sender, object o);
		public event clickHeader clickEndStartWork;
		
		private Worker worker;
		
		public ActionDlg (Worker mworker)
		{
			this.Build();
			
			worker = mworker;
			labelName.Text = worker.getFIO();
			getWorkerOnWorkNow();
			
			for(int i = 0; i<4;i++)
				keykeeperwidgetBackItem.addButton("41"+i);
			
			for(int i = 0; i<4;i++)
				keykeeperwidgetPutItem.addButton("50"+i);
		}
		
		private void getWorkerOnWorkNow()
		{
			btnStartWork.Sensitive = worker.isOnWork() == 0;
			btnEndWork.Sensitive = !btnStartWork.Sensitive;
		}
		
		protected void onAction(object sender, Action ca)
		{
			if(actionSelectedIvent!=null)
				actionSelectedIvent(this, ca);
		}

		protected void OnButton3Clicked (object sender, System.EventArgs e)
		{
			this.Destroy();
		}

		protected void OnBtnEndWorkClicked (object sender, System.EventArgs e)
		{
			onAction(this, new EndWork(worker,Const.HAND_OPERATION));
			getWorkerOnWorkNow();
			clickEndStartWork(this,this);
		}

		protected void OnBtnStartWorkClicked (object sender, System.EventArgs e)
		{
			onAction(this, new StartWork(worker,Const.HAND_OPERATION));
			getWorkerOnWorkNow();
			clickEndStartWork(this,this);
		}
	}
}

