using System;

namespace KeyKeeper
{
	
	public partial class ActionDlg : Gtk.Dialog
	{
		public delegate void dlgActionSelectedIventHedler (object sender, Action ca);
		public event dlgActionSelectedIventHedler actionSelectedIvent;
		
		public event EventHandler updateTreeView;
		
		private Worker worker;
		
		public ActionDlg (Worker mworker)
		{
			this.Build();
			
			worker = mworker;
			labelName.Text = worker.getFIO();
			getWorkerOnWorkNow();
			
			keykeeperwidgetGetItem.clickEvent += onClickGetButton;
			keykeeperwidgetBackItem.clickEvent += onClickPutButton;
			searchentry2.changed += changedEvent;
			
			updateKeyBack();	
		}
		
		private void getWorkerOnWorkNow()
		{
			btnStartWork.Sensitive = worker.isOnWork() == 0;
			btnEndWork.Sensitive = !btnStartWork.Sensitive;
		}
		
		#region обновление ключей
		private void updateKeyBack()
		{
			keykeeperwidgetBackItem.removeButton();
			keykeeperwidgetGetItem.removeButton();
			
			foreach(Item item in Journal.getWorkerItems(worker.id()))
				keykeeperwidgetBackItem.addButton(item.getName(), item);
		}
		
		private void updateKeyGet()
		{
			foreach(Item item in Journal.getItems())
			{
				if(item.getName().IndexOf (searchentry2.Text) > -1 && 
				   !string.IsNullOrEmpty(searchentry2.Text) && 
						searchentry2.Text.Length >= 2 &&
				  		item.isFree()==0)
				{	
					keykeeperwidgetGetItem.addButton(item.getName(), item);
				}
			}
		}
		#endregion
		
		#region нажатие на кнопки взять/вернуть ключи
		private void onClickPutButton(object sender, Item item)
		{
			onAction(this, new PutItem(worker,Const.HAND_OPERATION,
			                           item,Const.HAND_OPERATION));
			updateKeyBack();
			updateKeyGet();
			updateTreeView(this, null);
		}
		
		private void onClickGetButton(object sender, Item item)
		{
			onAction(this, new GetItem(worker,Const.HAND_OPERATION,
			                           item,Const.HAND_OPERATION));
			updateKeyBack();
			updateKeyGet();
			getWorkerOnWorkNow();
			updateTreeView(this, null);
		}
		#endregion
		
		
		private void changedEvent(object sender, EventArgs e)
		{
				keykeeperwidgetGetItem.removeButton();
				
				if(string.IsNullOrEmpty(searchentry2.Text))
					keykeeperwidgetGetItem.removeButton();	
				
				updateKeyGet();
		}
		
		protected void onAction(object sender, Action ca)
		{
			if(actionSelectedIvent!=null)
				actionSelectedIvent(this, ca);
		}
		
		
		protected void OnCancelClicked (object sender, System.EventArgs e)
		{
			keykeeperwidgetBackItem.removeButton();
			keykeeperwidgetGetItem.removeButton();
			this.Destroy();
		}
		
		#region нажатие на кнопки придти/уйти с работы
		protected void OnBtnEndWorkClicked (object sender, System.EventArgs e)
		{
			onAction(this, new EndWork(worker,Const.HAND_OPERATION));
			getWorkerOnWorkNow();
			updateKeyBack();
			updateTreeView(this,e);
		}

		protected void OnBtnStartWorkClicked (object sender, System.EventArgs e)
		{
			onAction(this, new StartWork(worker,Const.HAND_OPERATION));
			getWorkerOnWorkNow();
			updateTreeView(this,e);
		}
		#endregion
	}
}

