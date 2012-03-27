using System;
using Gtk;
using KeyKeeper;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	
	private Journal journal = new Journal();
	private Gtk.TreeModelFilter filterWorkersOnWork;
	private Gtk.TreeModelFilter filterAllWorkers;
	
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
		helperTreeview.Model = new ListStore(typeof(string));
		
		notebook1.CurrentPage = 0;
		
		searchentry1.changed += OnFilterEntryChanged;
	}
	
	#region создание модели для триивью
	private Gtk.TreeModelFilter getWorkerOnWork()
	{
		Gtk.ListStore worker = new Gtk.ListStore (typeof (Worker),typeof (string), typeof (string));
		String listWorkerKey = "";
		foreach(Worker work in Journal.getWorkerOnWork())
		{
			listWorkerKey = "";
			foreach(KeyKeeper.Item item in Journal.getWorkerItems(work.id()))
				listWorkerKey+="["+item.getName()+"] ";
				
			worker.AppendValues(work,work.ToString(),listWorkerKey);
		}
		filterWorkersOnWork = new Gtk.TreeModelFilter (worker, null);
		filterWorkersOnWork.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc (FilterTree);
		return filterWorkersOnWork;
	}
	
	private Gtk.TreeModelFilter getAllWorkers()
	{
		Gtk.ListStore worker = new Gtk.ListStore (typeof (Worker), typeof (string));
		foreach(Worker work in journal.getAllWorkers())
		{
			worker.AppendValues(work, work.getShortFIO());
		}
		filterAllWorkers = new Gtk.TreeModelFilter (worker, null);
		filterAllWorkers.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc (FilterTree2);
		return filterAllWorkers;
		
	}
	#endregion
	
	protected void OnNotebook1SwitchPage (object o, Gtk.SwitchPageArgs args)
	{
		CurrentPage = args.PageNum;
		
		switch (CurrentPage) {
		case 0:
			workerOnWork.Model = getWorkerOnWork();	
			break;
		case 3:
			helperTreeview.Model = getAllWorkers();	
			break;
		}
	}
	
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
 
		if (workerFIO.IndexOf (searchentry1.Text.ToLower()) > -1)
			return true;
		else
			return false;
	}
	
	private bool FilterTree2 (Gtk.TreeModel model, Gtk.TreeIter iter)
	{
		string workerFIO = model.GetValue (iter, 0).ToString ().ToLower();
 
		if (string.IsNullOrEmpty(entrySearch.Text))
			return true;
 
		if (workerFIO.IndexOf (entrySearch.Text.ToLower()) > -1)
			return true;
		else
			return false;
	}
	#endregion
	
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
	#endregion
	
	#region кнопочки отчистки
	protected void OnCleerEntryHelperClicked (object sender, System.EventArgs e)
	{
		entrySearch.Text="";
	}
	#endregion
	

	
}