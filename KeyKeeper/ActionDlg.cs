using System;

namespace KeyKeeper
{
	
	public partial class ActionDlg : Gtk.Dialog
	{
		public delegate void dlgActionSelectedIventHedler (object sender, Action ca);
		public event dlgActionSelectedIventHedler actionSelectedIvent;
		
		private Worker worker;
		
		public ActionDlg (Worker mworker)
		{
			this.Build();
			
			worker = mworker;
			labelName.Text = worker.getFIO();
			getWorkerOnWorkNow();
		}
		
		
		protected void OnButton11Clicked (object sender, System.EventArgs e)
		{
			onAction(this, new StartWork(worker,Const.HAND_OPERATION));
			getWorkerOnWorkNow();
		}
		
		private void getWorkerOnWorkNow()
		{
			btnStartWork.Sensitive = worker.isOnWork() == 0;
			btnEndWork.Sensitive = !btnStartWork.Sensitive;
			
			/*
			if(worker.isOnWork() != 0)
			{
				btnStartWork.Sensitive = false;
				btnEndWork.Sensitive = true;
			}
			else
			{
				btnStartWork.Sensitive = true;
				btnEndWork.Sensitive = false;
			}
			*/
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

		protected void OnButton12Clicked (object sender, System.EventArgs e)
		{
			onAction(this, new EndWork(worker,Const.HAND_OPERATION));
			getWorkerOnWorkNow();
		}
	}
}

