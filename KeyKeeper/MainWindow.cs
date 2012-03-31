using System;
using Gtk;
using KeyKeeper;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	
	private Journal journal = new Journal();
	private Gtk.TreeModelFilter filterWorkersOnWork;
	private Gtk.TreeModelFilter filterAllWorkers;
	
	private Gtk.TreeModelFilter filterOfficialKey;
	private Gtk.TreeModelFilter filterBasicKey;
	
	
	uint CurrentPage;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{	
		Build ();
		initGui();
		KeyKeeper.dbConnector.getdbAcces();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
		
		KeyKeeper.dbConnector.getdbAcces().close();
	}
	
	private void initGui()
	{
		workerOnWork.AppendColumn("Сейчас на работе", new CellRendererText(), "text", 1);
		workerOnWork.AppendColumn("Аудитории", new CellRendererText(), "text", 2);
		workerOnWork.Model = new ListStore(typeof(string));
		
		helperTreeview.AppendColumn("Сотрудники", new CellRendererText(), "text", 1);
		helperTreeview.AppendColumn("Аудитории", new CellRendererText(), "text", 2);
		helperTreeview.Model = new ListStore(typeof(string));
		
		generalKeyTreeview.AppendColumn("Ключ", new CellRendererText(), "text", 0);
		generalKeyTreeview.AppendColumn("Сотрудник", new CellRendererText(), "text", 1);
		generalKeyTreeview.AppendColumn("Время", new CellRendererText(), "text", 2);
		generalKeyTreeview.Model = new ListStore(typeof(string));
		
		officialTreeview.AppendColumn("Ключ", new CellRendererText(), "text", 0);
		officialTreeview.AppendColumn("Сотрудник", new CellRendererText(), "text", 1);
		officialTreeview.AppendColumn("Время", new CellRendererText(), "text", 2);
		officialTreeview.Model = new ListStore(typeof(string));
		
		JournalTreeView.AppendColumn("Время", new CellRendererText(), "text", 0);
		JournalTreeView.AppendColumn("Действие", new CellRendererText(), "text", 1);
		JournalTreeView.AppendColumn("Сотрудник", new CellRendererText(), "text", 2);
		JournalTreeView.Model = new ListStore(typeof(string));
		
		
		//notebook1.CurrentPage = 0;
		workerOnWork.Model = getWorkerOnWork();	
		
		searchentry1.changed += OnFilterEntryChanged;
		searchentry2.changed += OnEntrySearchChanged;
		
		
		
	}
	
	#region всяко для работы с treeview
	
	private Gtk.TreeModelFilter getWorkerOnWork()
	{
		Gtk.ListStore worker = new Gtk.ListStore (typeof (Worker),typeof (string), typeof (string));
		
		foreach(Journal.workerStruct work in journal.getWorkerOnWork())
		{	
			worker.AppendValues(work.worker, work.worker.getShortFIO(), work.key);
		}
		
		filterWorkersOnWork = new Gtk.TreeModelFilter (worker, null);
		filterWorkersOnWork.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc (FilterTree);
		return filterWorkersOnWork;
	}
	
	private Gtk.TreeModelFilter getAllWorkers()
	{
		Gtk.ListStore worker = new Gtk.ListStore (typeof (Worker), typeof (string), typeof (string));

		foreach(Journal.workerStruct work in journal.getAllWorkers())
		{	
			worker.AppendValues(work.worker, work.worker.getShortFIO(), work.key);
		}
		filterAllWorkers = new Gtk.TreeModelFilter (worker, null);
		filterAllWorkers.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc (FilterTree2);
		return filterAllWorkers;
		
	}
	
	private void getKey()
	{
		Gtk.ListStore officialKey = new Gtk.ListStore (typeof (string), typeof (string), typeof (string));
		Gtk.ListStore basicKeys = new Gtk.ListStore (typeof (string), typeof (string), typeof (string));
		
		foreach(dbHelper.DateOrWorker itemWorkerDate in dbHelper.getWorkerOrStamp())
		{
			if(itemWorkerDate.item_tupe == Const.GENERAL_KEY)
				basicKeys.AppendValues("["+itemWorkerDate.name+"]",itemWorkerDate.FIO, itemWorkerDate.time);
			else
				officialKey.AppendValues("["+itemWorkerDate.name+"]",itemWorkerDate.FIO, itemWorkerDate.time);
		}
		
		filterBasicKey = new Gtk.TreeModelFilter (basicKeys, null);
		filterBasicKey.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc (FilterTree);
		
		filterOfficialKey = new Gtk.TreeModelFilter (officialKey, null);
		filterOfficialKey.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc (FilterTree);
	}
	
	private Gtk.TreeModelFilter getAction(string date)
	{
		Gtk.ListStore worker = new Gtk.ListStore (typeof (string),typeof (string), typeof (string));
		
		Console.WriteLine(calendar1.GetDate ().ToString ("yyyy.MM.dd"));
		
		foreach(Journal.journaStructur journal in dbHelper.getActionsByDate(date))
		{
			string textOperation = "";
			switch(journal.operationID)
			{
				case Const.OPERATION_WORK_IN:
					textOperation = "Приход на работу";
				break;
				
				case Const.OPERATION_WORK_OUT:
					textOperation = "Уход с работы";
				break;
				
				case Const.OPERATION_ITEM_GET:
					textOperation = "Взятие ключа: ["+ journal.item_name +"]";
				break;
				
				case Const.OPERATION_ITEM_PUT:
					textOperation = "Возврат ключа: ["+ journal.item_name +"]";
				break;
				
			}
			worker.AppendValues(journal.stamp.TimeOfDay.ToString(), textOperation, journal.FIO);
		}
		
		filterWorkersOnWork = new Gtk.TreeModelFilter (worker, null);
		filterWorkersOnWork.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc (FilterTree);
		return filterWorkersOnWork;
	}
	
	protected void OnNotebook1SwitchPage (object o, Gtk.SwitchPageArgs args)
	{
		CurrentPage = args.PageNum;
		
		switch (CurrentPage) {
		case 0:
			workerOnWork.Model = getWorkerOnWork();	
			break;
		case 1:
			getKey();
			generalKeyTreeview.Model = filterBasicKey;
			officialTreeview.Model = filterOfficialKey;
			break;
		case 2:
			JournalTreeView.Model = getAction(calendar1.GetDate ().ToString ("yyyy.MM.dd"));
			break;
		case 3:
			helperTreeview.Model = getAllWorkers();	
			break;
		}
	}
	
	#endregion
	
	#region реализация поиска
	
	protected void OnFilterEntryChanged (object sender, System.EventArgs e)
	{
		filterWorkersOnWork.Refilter();
	}
	
	protected void OnEntrySearchChanged (object sender, System.EventArgs e)
	{
		filterAllWorkers.Refilter();
	}
	
	private bool FilterTree (Gtk.TreeModel model, Gtk.TreeIter iter)
	{
		string workerFIO = model.GetValue (iter, 1).ToString ().ToLower();
 
		if (string.IsNullOrEmpty(searchentry1.Text))
			return true;

		return workerFIO.IndexOf (searchentry1.Text.ToLower()) > -1;

	}
	
	private bool FilterTree2 (Gtk.TreeModel model, Gtk.TreeIter iter)
	{
		string workerFIO = model.GetValue (iter, 0).ToString ().ToLower();
 
		if (string.IsNullOrEmpty(searchentry2.Text))
			return true;
 
		return workerFIO.IndexOf (searchentry2.Text.ToLower()) > -1;

	}
	
	#endregion
	
	#region обработка нажатий по триивью
	
	protected void OnHelperTreeviewRowActivated (object o, Gtk.RowActivatedArgs args)
	{
		TreeSelection select = helperTreeview.Selection;
		TreeIter iter;
		TreeModel model;
		select.GetSelected(out model, out iter);
		showActionDialog((Worker)model.GetValue (iter, 0));
	}
	
	protected void OnWorkerOnWorkRowActivated (object o, Gtk.RowActivatedArgs args)
	{
		TreeSelection select = workerOnWork.Selection;
		TreeIter iter;
		TreeModel model;
		select.GetSelected(out model, out iter);
		showActionDialog((Worker)model.GetValue (iter, 0));
	}
	
	private void showActionDialog(Worker work)
	{
		ActionCreater act = new ActionCreater(new dbHelper());
		act.updateTree += delegate(object sender, object sender2) 
		{
			if(CurrentPage == 0)
				workerOnWork.Model = getWorkerOnWork();	
		};
		act.byWorker(work,Const.HAND_OPERATION);
	}
	
	#endregion
	
	protected void OnCalendar1DaySelected (object sender, System.EventArgs e)
	{
    	JournalTreeView.Model = getAction(calendar1.GetDate ().ToString ("yyyy.MM.dd"));
	}

	
}