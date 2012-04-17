using System;

namespace KeyKeeper
{
	public class KeyRecivier
	{
		MainWindow window;
		
		private string keyCode = "";
		
		ActionDlg dlg = null;
			
		public KeyRecivier (SpecialKeys specKey, MainWindow win)
		{
			window = win;
			specKey.keyStringEnter += keyStringAccepted;
		}
		
		private void keyStringAccepted(object o, string keyString)
		{
			string type = keyString.Substring(1,1);
			
			switch(type)
			{
			case "1":
				Console.WriteLine("получен код сотрудника: {0}", keyString );
				
				if(!keyString.Equals(keyCode))
				{
					Worker work = dbHelper.getWorkerByCode(keyString);
					if(work != null)
					{
						dlg = window.showActionDialog(work,Const.AUTO_OPERATION);
						
						keyCode = keyString;
		
						dlg.onClose += delegate(object sender, EventArgs e)
						{
							keyCode = "";
							
							Console.WriteLine("del()");
							dlg = null;
						};
					}
				}

				break;
				
			case "2":
				Console.WriteLine("получен код предмета: {0}", keyString );
				
				Item item = dbHelper.getItemByCode(keyString);
				
				if(dlg != null && item != null)
					dlg.workAutoItem(item);
				else
				{
					if(item.isFree() != 0)
					{
						Worker tmpWorker = dbHelper.getWorkerByItem(item.id ());
						if(tmpWorker != null)
						{
							dlg = window.showActionDialog(tmpWorker, Const.AUTO_OPERATION);
							dlg.workAutoItem(item);
							dlg = null;
						}
						else
							Console.WriteLine("null workera");
					}
				}
					
				break;
			}
			
		}
		
		
	}
}

