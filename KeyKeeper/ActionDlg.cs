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
		}
		
		
		protected void OnButton11Clicked (object sender, System.EventArgs e)
		{
			onAction(this, new Action());
		}
		
		protected void onAction(object sender, Action ca)
		{
			if(actionSelectedIvent!=null)
				actionSelectedIvent(this, ca);
		}
	}
}

