using System;
using System.Timers;

namespace KeyKeeper
{
	
	public partial class ActionDlg : Gtk.Dialog
	{
		public delegate void dlgActionSelectedIventHedler (object sender, Action ca);
		public event dlgActionSelectedIventHedler actionSelectedIvent;
		
		public event EventHandler updateTreeView;
		public event EventHandler onClose;
		
		private const int timeLeft = 5;
		private int time = timeLeft;
		
		System.Timers.Timer timer;
		
		private Worker worker;
		
		public ActionDlg (Worker mworker, uint regType)
		{
			this.Build();
			
			worker = mworker;
			
			labelName.Text = worker.getFIO();
			
			if(regType == Const.AUTO_OPERATION)
				if(worker.isOnWork() == 0)
				{
					autoStartWork();
				}
				else
				{
					autoEndWork();
				}
			
			
			getWorkerOnWorkNow();
			
			keykeeperwidgetGetItem.clickEvent += onClickGetButton;
			keykeeperwidgetBackItem.clickEvent += onClickPutButton;
			searchentry2.changed += changedEvent;
			
			updateKeyBack();
			displayPopKey();
			
		}
		
		private void autoStartWork()
		{
			closeAllTimer();
				
			timer = new System.Timers.Timer(1000);
			timer.AutoReset = true;
			timer.Elapsed += delegate(object sender, ElapsedEventArgs e)
			{	
				time--;
				Gtk.Application.Invoke(delegate {label4.Text = string.Format("Придти на\nработу\n{0}",time);});
				
				if(time<=0)
				{
					closeAllTimer();
					
					Gtk.Application.Invoke(delegate {label4.Text = "Придти на\nработу";});
					
					time = timeLeft;
					
					onAction(this, new StartWork(worker,Const.AUTO_OPERATION));
					
					if(updateTreeView != null)
						updateTreeView(this, null);
							//getWorkerOnWorkNow();
					
					Gtk.Application.Invoke(delegate {keykeeperwidgetBackItem.removeButton();});
					Gtk.Application.Invoke(delegate {keykeeperwidgetGetItem.removeButton();});
					
					closeAllTimer();
					Gtk.Application.Invoke(delegate {this.Destroy();});
					
				}
			};
			timer.Start();
		}
		
		private void autoEndWork()
		{
			closeAllTimer();
				
			timer = new System.Timers.Timer(1000);
			timer.AutoReset = true;
			timer.Elapsed += delegate(object sender, ElapsedEventArgs e)
			{
				time--;
				Gtk.Application.Invoke(delegate {label6.Text = string.Format("     Уйти с      \nработы\n{0}",time);});
				
						
				if(time<=0)
				{
					closeAllTimer();
					
					time = timeLeft;
					Gtk.Application.Invoke(delegate {label6.Text = "     Уйти с      \nработы";});
					
					onAction(this, new EndWork(worker,Const.AUTO_OPERATION));
					
					
					
					if(updateTreeView != null)
						updateTreeView(this, null);
					
					
					Gtk.Application.Invoke(delegate {keykeeperwidgetBackItem.removeButton();});
					Gtk.Application.Invoke(delegate {keykeeperwidgetGetItem.removeButton();});
					
					closeAllTimer();
					Gtk.Application.Invoke(delegate {this.Destroy();});
				}
						
			};
			timer.Start();
		}
		
		private void displayPopKey()
		{
			foreach(Item item in dbHelper.getPopItem(worker.id()))
				keykeeperwidgetGetItem.addButton(item.getName(), item);
			
			keykeeperwidgetGetItem.showAllButtons();
		}
		
		private void getWorkerOnWorkNow()
		{
			btnStartWork.Sensitive = worker.isOnWork() == 0;
			btnEndWork.Sensitive = !btnStartWork.Sensitive;
		}
		
		public void workAutoItem(Item item)
		{
			closeAllTimer();
			if(item.isFree() == 0)
			{
				onAction(this, new GetItem(worker,Const.AUTO_OPERATION,
			             	item,Const.AUTO_OPERATION));
			}
			else
			{
				if(dbHelper.isItemByWorker(worker,item))
					onAction(this, new PutItem(worker,Const.AUTO_OPERATION,
			                item,Const.AUTO_OPERATION));
			}
			
			updateKeyBack();
			updateKeyGet();
			updateTreeView(this, null);
			this.Destroy();
		}
		
		#region обновление ключей
		
		private void updateKeyBack()
		{
			keykeeperwidgetBackItem.removeButton();
			keykeeperwidgetGetItem.removeButton();
			
			foreach(Item item in Journal.getWorkerItems(worker.id()))
				keykeeperwidgetBackItem.addButton(item.getName(), item);
				
			keykeeperwidgetBackItem.showAllButtons();
		}
		
		private void updateKeyGet()
		{
			if(!string.IsNullOrEmpty(searchentry2.Text))
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
				
				keykeeperwidgetGetItem.showAllButtons();
			}
			else
				displayPopKey();
		}
		
		#endregion
		
		#region нажатие на кнопки взять/вернуть ключи
		
		private void onClickPutButton(object sender, Item item)
		{
			onAction(sender, new PutItem(worker,Const.HAND_OPERATION,
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
			{
				actionSelectedIvent(sender, ca);
			}
		}
		
		
		protected void OnCancelClicked (object sender, System.EventArgs e)
		{
			keykeeperwidgetBackItem.removeButton();
			keykeeperwidgetGetItem.removeButton();
			closeAllTimer();
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
		
		protected void OnClose (object sender, System.EventArgs e)
		{
			closeAllTimer();
		}
		
		private void closeAllTimer()
		{
			if(timer != null)
				timer.Stop();
			
			if(onClose != null)
				onClose(this,null);
		}
		
		protected void OnKeysChanged (object sender, System.EventArgs e)
		{
			
		}
	}
}

