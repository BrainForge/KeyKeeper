using System;
using Gtk;
using KeyKeeper;

public partial class MainWindow: Gtk.Window
{	
	private Journal journal = new Journal();
	private Gtk.TreeModelFilter filterWorkersOnWork;
	private Gtk.TreeModelFilter filterAllWorkers;
	
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
		workerOnWork.AppendColumn("Сейчас на работе", new CellRendererText(), "text", 0);
		workerOnWork.Model = new ListStore(typeof(string));
		
		helperTreeview.AppendColumn("Сотрудники", new CellRendererText(), "text", 0);
		helperTreeview.Model = new ListStore(typeof(string));
		
		notebook1.CurrentPage = 0;
		
	}
	
	private Gtk.TreeModelFilter getWorkerOnWork()
	{
		Gtk.ListStore worker = new Gtk.ListStore (typeof (string));
		foreach(Worker work in journal.getWorkerOnWork())
		{
			worker.AppendValues(work.getShortFIO());
		}
		filterWorkersOnWork = new Gtk.TreeModelFilter (worker, null);
		filterWorkersOnWork.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc (FilterTree);
		return filterWorkersOnWork;
		
	}
	
	private Gtk.TreeModelFilter getAllWorkers()
	{
		Gtk.ListStore worker = new Gtk.ListStore (typeof (string));
		foreach(Worker work in journal.getAllWorkers())
		{
			worker.AppendValues(work.getShortFIO());
		}
		filterAllWorkers = new Gtk.TreeModelFilter (worker, null);
		filterAllWorkers.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc (FilterTree2);
		return filterAllWorkers;
		
	}
	
	protected void OnNotebook1SwitchPage (object o, Gtk.SwitchPageArgs args)
	{
		var CurrentPage = args.PageNum;
		
		switch (CurrentPage) {
		case 0:
			workerOnWork.Model = getWorkerOnWork();	
			break;
		case 3:
			helperTreeview.Model = getAllWorkers();	
			break;
		}
	}

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
		string workerFIO = model.GetValue (iter, 0).ToString ().ToLower();
 
		if (filterEntry.Text == "")
			return true;
 
		if (workerFIO.IndexOf (filterEntry.Text.ToLower()) > -1)
			return true;
		else
			return false;
	}
	
	private bool FilterTree2 (Gtk.TreeModel model, Gtk.TreeIter iter)
	{
		string workerFIO = model.GetValue (iter, 0).ToString ().ToLower();
 
		if (entrySearch.Text == "")
			return true;
 
		if (workerFIO.IndexOf (entrySearch.Text.ToLower()) > -1)
			return true;
		else
			return false;
	}

	protected void OnButton1Clicked (object sender, System.EventArgs e)
	{

	}
}