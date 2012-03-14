using System;
using Gtk;
using KeyKeeper;

public partial class MainWindow: Gtk.Window
{	
	private Journal journal = new Journal();
	private Gtk.TreeModelFilter filter;
	
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
		notebook1.CurrentPage = 0;
		
	}
	
	private Gtk.ListStore getWorkerOnWork()
	{
		Gtk.ListStore worker = new Gtk.ListStore (typeof (string));
		foreach(Worker work in journal.getWorkerOnWork())
		{
			worker.AppendValues(work.getShortFIO());
		}
		filter = new Gtk.TreeModelFilter (worker, null);
		filter.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc (FilterTree);
		
		
		return worker;
	}
	
	protected void OnNotebook1SwitchPage (object o, Gtk.SwitchPageArgs args)
	{
		var CurrentPage = args.PageNum;
		
		switch (CurrentPage) {
		case 0:
			workerOnWork.Model = getWorkerOnWork();	
			break;
		}
	}

	protected void OnFilterEntryChanged (object sender, System.EventArgs e)
	{
		filter.Refilter();
	}
	
	private bool FilterTree (Gtk.TreeModel model, Gtk.TreeIter iter)
	{
		string artistName = model.GetValue (iter, 0).ToString ();
 
		if (filterEntry.Text == "")
			return true;
 
		if (artistName.IndexOf (filterEntry.Text) > -1)
			return true;
		else
			return false;
	}
}
