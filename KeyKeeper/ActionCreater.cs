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
			Console.WriteLine("reg action");
			a.Do(registrator);
		}
		
		public void byWorker(Worker worker, uint regType)
		{
			Console.WriteLine("action by worker");
			dlg = new ActionDlg(worker, regType);
			dlg.actionSelectedIvent += dlgActionSelectedIvent;
			dlg.updateTreeView += delegate(object sender, EventArgs e)
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

