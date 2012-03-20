using System;
using Gtk;

namespace KeyKeeper
{
	public class ActionCreater : EventArgs
	{
		ActionDlg dlg;
		IActionRegistrator registrator;
		
		public delegate void updateTreeHeadler(object sender, object o);
		public event updateTreeHeadler updateTree;
		
		public ActionCreater(IActionRegistrator actionRegistrator)
		{
			registrator = actionRegistrator;	
		}
		
		public void dlgActionSelectedIvent(object o, Action a) 
		{
			a.Do(registrator);
		}
		
		public void byWorker(Worker worker, uint regType)
		{
			dlg = new ActionDlg(worker);
			dlg.actionSelectedIvent += dlgActionSelectedIvent;
			dlg.clickEndStartWork += delegate(object sender, object o) 
			{
				if(updateTree!=null)
					updateTree(this,this);
			};
			dlg.Show();
		}
		
		
		
		
		public void byItem(Item item, uint regType)
		{
			
		}
	}
}

