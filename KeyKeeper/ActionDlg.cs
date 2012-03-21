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
			
			keykeeperwidgetGetItem.clickEvent += onClickGetButton;
			keykeeperwidgetBackItem.clickEvent += onClickPutButton;
			
			updateKey();
				
			searchentry2.changed += changedEvent;
			
		}
		
		private void updateKey()
		{
			keykeeperwidgetBackItem.removeButton();
			foreach(Item item in Journal.getWorkerItems(worker.id()))
				keykeeperwidgetBackItem.addButton(item.getName(), item);
		}
		
		private void onClickPutButton(object sender, Item item)
		{
			onAction(this, new PutItem(worker,Const.HAND_OPERATION,
			                           item,Const.HAND_OPERATION));
			updateKey();
		}
		
		private void onClickGetButton(object sender, Item item)
		{
			onAction(this, new GetItem(worker,Const.HAND_OPERATION,
			                           item,Const.HAND_OPERATION));
			updateKey();
		}
		
		
		
		private void changedEvent(object sender, EventArgs e)
		{
				keykeeperwidgetGetItem.removeButton();
				
				if(string.IsNullOrEmpty(searchentry2.Text))
					keykeeperwidgetGetItem.removeButton();	
				
				foreach(Item item in Journal.getItems())
				{
					if(item.getName().IndexOf (searchentry2.Text) > -1 && 
					   !string.IsNullOrEmpty(searchentry2.Text) && 
				   		searchentry2.Text.Length >= 2 &&
				   		item.isFree(worker.id())==0)
					{	
						keykeeperwidgetGetItem.addButton(item.getName(), item);
					}
				}
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

