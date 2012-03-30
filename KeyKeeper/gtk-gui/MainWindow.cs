public partial class MainWindow
{
	private global::Gtk.Notebook notebook1;
	private global::Gtk.VBox vbox1;
	private global::Gtk.HBox hbox1;
	private global::KeyKeeper.SearchEntry searchentry1;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::Gtk.TreeView workerOnWork;
	private global::Gtk.Label label1;
	private global::Gtk.HBox hbox4;
	private global::Gtk.VBox vbox2;
	private global::Gtk.ScrolledWindow GtkScrolledWindow2;
	private global::Gtk.TreeView generalKeyTreeview;
	private global::Gtk.VBox vbox4;
	private global::Gtk.ScrolledWindow GtkScrolledWindow3;
	private global::Gtk.TreeView officialTreeview;
	private global::Gtk.Label label3;
	private global::Gtk.VBox vbox5;
	private global::Gtk.Calendar calendar1;
	private global::Gtk.ScrolledWindow GtkScrolledWindow4;
	private global::Gtk.TreeView JournalTreeView;
	private global::Gtk.Label label4;
	private global::Gtk.VBox vbox3;
	private global::KeyKeeper.SearchEntry searchentry2;
	private global::Gtk.ScrolledWindow GtkScrolledWindow1;
	private global::Gtk.TreeView helperTreeview;
	private global::Gtk.Label label5;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("KeyKeeper");
		this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-about", global::Gtk.IconSize.Menu);
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.notebook1 = new global::Gtk.Notebook ();
		this.notebook1.CanFocus = true;
		this.notebook1.Name = "notebook1";
		this.notebook1.CurrentPage = 2;
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.searchentry1 = new global::KeyKeeper.SearchEntry ();
		this.searchentry1.Events = ((global::Gdk.EventMask)(256));
		this.searchentry1.Name = "searchentry1";
		this.hbox1.Add (this.searchentry1);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.searchentry1]));
		w1.Position = 0;
		this.vbox1.Add (this.hbox1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.workerOnWork = new global::Gtk.TreeView ();
		this.workerOnWork.CanFocus = true;
		this.workerOnWork.Name = "workerOnWork";
		this.GtkScrolledWindow.Add (this.workerOnWork);
		this.vbox1.Add (this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
		w4.Position = 1;
		this.notebook1.Add (this.vbox1);
		// Notebook tab
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("На работе");
		this.notebook1.SetTabLabel (this.vbox1, this.label1);
		this.label1.ShowAll ();
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.hbox4 = new global::Gtk.HBox ();
		this.hbox4.Name = "hbox4";
		this.hbox4.Spacing = 6;
		// Container child hbox4.Gtk.Box+BoxChild
		this.vbox2 = new global::Gtk.VBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.GtkScrolledWindow2 = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
		this.GtkScrolledWindow2.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
		this.generalKeyTreeview = new global::Gtk.TreeView ();
		this.generalKeyTreeview.CanFocus = true;
		this.generalKeyTreeview.Name = "generalKeyTreeview";
		this.GtkScrolledWindow2.Add (this.generalKeyTreeview);
		this.vbox2.Add (this.GtkScrolledWindow2);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.GtkScrolledWindow2]));
		w7.Position = 0;
		this.hbox4.Add (this.vbox2);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.vbox2]));
		w8.Position = 0;
		// Container child hbox4.Gtk.Box+BoxChild
		this.vbox4 = new global::Gtk.VBox ();
		this.vbox4.Name = "vbox4";
		this.vbox4.Spacing = 6;
		// Container child vbox4.Gtk.Box+BoxChild
		this.GtkScrolledWindow3 = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow3.Name = "GtkScrolledWindow3";
		this.GtkScrolledWindow3.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow3.Gtk.Container+ContainerChild
		this.officialTreeview = new global::Gtk.TreeView ();
		this.officialTreeview.CanFocus = true;
		this.officialTreeview.Name = "officialTreeview";
		this.GtkScrolledWindow3.Add (this.officialTreeview);
		this.vbox4.Add (this.GtkScrolledWindow3);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.GtkScrolledWindow3]));
		w10.Position = 0;
		this.hbox4.Add (this.vbox4);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.vbox4]));
		w11.Position = 1;
		this.notebook1.Add (this.hbox4);
		global::Gtk.Notebook.NotebookChild w12 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.hbox4]));
		w12.Position = 1;
		// Notebook tab
		this.label3 = new global::Gtk.Label ();
		this.label3.Name = "label3";
		this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Ключи");
		this.notebook1.SetTabLabel (this.hbox4, this.label3);
		this.label3.ShowAll ();
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.vbox5 = new global::Gtk.VBox ();
		this.vbox5.Name = "vbox5";
		this.vbox5.Spacing = 6;
		// Container child vbox5.Gtk.Box+BoxChild
		this.calendar1 = new global::Gtk.Calendar ();
		this.calendar1.CanFocus = true;
		this.calendar1.Name = "calendar1";
		this.calendar1.DisplayOptions = ((global::Gtk.CalendarDisplayOptions)(35));
		this.vbox5.Add (this.calendar1);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.calendar1]));
		w13.Position = 0;
		w13.Expand = false;
		w13.Fill = false;
		// Container child vbox5.Gtk.Box+BoxChild
		this.GtkScrolledWindow4 = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow4.Name = "GtkScrolledWindow4";
		this.GtkScrolledWindow4.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow4.Gtk.Container+ContainerChild
		this.JournalTreeView = new global::Gtk.TreeView ();
		this.JournalTreeView.CanFocus = true;
		this.JournalTreeView.Name = "JournalTreeView";
		this.GtkScrolledWindow4.Add (this.JournalTreeView);
		this.vbox5.Add (this.GtkScrolledWindow4);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.GtkScrolledWindow4]));
		w15.Position = 1;
		this.notebook1.Add (this.vbox5);
		global::Gtk.Notebook.NotebookChild w16 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.vbox5]));
		w16.Position = 2;
		// Notebook tab
		this.label4 = new global::Gtk.Label ();
		this.label4.Name = "label4";
		this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Журнал");
		this.notebook1.SetTabLabel (this.vbox5, this.label4);
		this.label4.ShowAll ();
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.vbox3 = new global::Gtk.VBox ();
		this.vbox3.Name = "vbox3";
		this.vbox3.Spacing = 6;
		// Container child vbox3.Gtk.Box+BoxChild
		this.searchentry2 = new global::KeyKeeper.SearchEntry ();
		this.searchentry2.Events = ((global::Gdk.EventMask)(256));
		this.searchentry2.Name = "searchentry2";
		this.vbox3.Add (this.searchentry2);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.searchentry2]));
		w17.Position = 0;
		w17.Expand = false;
		w17.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
		this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
		this.helperTreeview = new global::Gtk.TreeView ();
		this.helperTreeview.CanFocus = true;
		this.helperTreeview.Name = "helperTreeview";
		this.GtkScrolledWindow1.Add (this.helperTreeview);
		this.vbox3.Add (this.GtkScrolledWindow1);
		global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.GtkScrolledWindow1]));
		w19.Position = 1;
		this.notebook1.Add (this.vbox3);
		global::Gtk.Notebook.NotebookChild w20 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.vbox3]));
		w20.Position = 3;
		// Notebook tab
		this.label5 = new global::Gtk.Label ();
		this.label5.Name = "label5";
		this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Справочник");
		this.notebook1.SetTabLabel (this.vbox3, this.label5);
		this.label5.ShowAll ();
		this.Add (this.notebook1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 469;
		this.DefaultHeight = 483;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.notebook1.SwitchPage += new global::Gtk.SwitchPageHandler (this.OnNotebook1SwitchPage);
		this.workerOnWork.RowActivated += new global::Gtk.RowActivatedHandler (this.OnWorkerOnWorkRowActivated);
		this.calendar1.DaySelected += new global::System.EventHandler (this.OnCalendar1DaySelected);
		this.helperTreeview.RowActivated += new global::Gtk.RowActivatedHandler (this.OnHelperTreeviewRowActivated);
	}
}