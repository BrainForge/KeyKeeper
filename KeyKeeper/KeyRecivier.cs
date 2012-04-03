using System;

namespace KeyKeeper
{
	public class KeyRecivier
	{
		MainWindow window;
		public KeyRecivier (SpecialKeys specKey, MainWindow win)
		{
			window = win;
			specKey.keyStringEnter += keyStringAccepted;
		}
		
		private void keyStringAccepted(object o, string keyString)
		{
			Console.WriteLine("получен код: {0}", keyString );
			
			string type = keyString.Substring(1,1);
			Console.WriteLine(type);
			switch(type)
			{
			case "1":
				window.showActionDialog(dbHelper.getWorkerByCode(keyString),Const.AUTO_OPERATION);
				//showActionDialog();
				break;
				
			case "2":
			
				break;
			}
			
		}
		private void showActionDialog(Worker work)
		{
			ActionCreater act = new ActionCreater(new dbHelper());
			act.updateTree += delegate(object sender, object sender2) 
			{
				//if(CurrentPage == 0)
				//	workerOnWork.Model = getWorkerOnWork();	
			};
			act.byWorker(work,Const.AUTO_OPERATION);
			
		}
	}
}

