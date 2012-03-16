using System;


namespace KeyKeeper
{
	public class ActionCreater
	{
		ActionDlg dlg;
		IActionRegistrator registrator;
		
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
			dlg.Show();
		}
		
		public void byItem(Item item, uint regType)
		{
			
		}
	}
}

