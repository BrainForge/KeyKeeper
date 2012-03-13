using System;
using Gtk;
using KeyKeeper;

public partial class MainWindow: Gtk.Window
{	
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{	
		Build ();
		KeyKeeper.dbConnector.getdbAcces();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
		
		KeyKeeper.dbConnector.getdbAcces().close();
	}

	protected void OnButton1Clicked (object sender, System.EventArgs e)
	{
		Utils.showMessageInfo(new Worker(2).getShortFIO());
	}
}
