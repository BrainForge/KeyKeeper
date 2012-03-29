
// This file has been generated by the GUI designer. Do not modify.
namespace KeyKeeper
{
	public partial class ActionDlg
	{
		private global::Gtk.Label labelName;
		private global::Gtk.VBox vbox2;
		private global::Gtk.HSeparator hseparator2;
		private global::Gtk.VBox vbox3;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Button btnStartWork;
		private global::Gtk.VBox vbox4;
		private global::Gtk.Label label3;
		private global::Gtk.Label label4;
		private global::Gtk.Button btnEndWork;
		private global::Gtk.VBox vbox5;
		private global::Gtk.Label label5;
		private global::Gtk.Label label6;
		private global::Gtk.HSeparator hseparator1;
		private global::Gtk.Label label7;
		private global::KeyKeeper.KeyKeeperWidget keykeeperwidgetBackItem;
		private global::Gtk.HSeparator hseparator3;
		private global::Gtk.Label label8;
		private global::KeyKeeper.SearchEntry searchentry2;
		private global::KeyKeeper.KeyKeeperWidget keykeeperwidgetGetItem;
		private global::Gtk.Button cancel;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget KeyKeeper.ActionDlg
			this.Name = "KeyKeeper.ActionDlg";
			this.Title = global::Mono.Unix.Catalog.GetString ("Действия");
			this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-about", global::Gtk.IconSize.Menu);
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child KeyKeeper.ActionDlg.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.labelName = new global::Gtk.Label ();
			this.labelName.Name = "labelName";
			this.labelName.LabelProp = global::Mono.Unix.Catalog.GetString ("label1");
			w1.Add (this.labelName);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(w1 [this.labelName]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hseparator2 = new global::Gtk.HSeparator ();
			this.hseparator2.Name = "hseparator2";
			this.vbox2.Add (this.hseparator2);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hseparator2]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnStartWork = new global::Gtk.Button ();
			this.btnStartWork.CanFocus = true;
			this.btnStartWork.Name = "btnStartWork";
			this.btnStartWork.FocusOnClick = false;
			// Container child btnStartWork.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("1");
			this.vbox4.Add (this.label3);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.label3]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Придти на\nработу");
			this.label4.Justify = ((global::Gtk.Justification)(2));
			this.vbox4.Add (this.label4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.label4]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.btnStartWork.Add (this.vbox4);
			this.btnStartWork.Label = null;
			this.hbox1.Add (this.btnStartWork);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnStartWork]));
			w7.Position = 0;
			w7.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnEndWork = new global::Gtk.Button ();
			this.btnEndWork.CanFocus = true;
			this.btnEndWork.Name = "btnEndWork";
			// Container child btnEndWork.Gtk.Container+ContainerChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("2");
			this.vbox5.Add (this.label5);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.label5]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("     Уйти с      \nработы");
			this.label6.Justify = ((global::Gtk.Justification)(2));
			this.vbox5.Add (this.label6);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.label6]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			this.btnEndWork.Add (this.vbox5);
			this.btnEndWork.Label = null;
			this.hbox1.Add (this.btnEndWork);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnEndWork]));
			w11.Position = 1;
			w11.Fill = false;
			this.vbox3.Add (this.hbox1);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox1]));
			w12.Position = 0;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator ();
			this.hseparator1.Name = "hseparator1";
			this.vbox3.Add (this.hseparator1);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hseparator1]));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.Xalign = 0F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Вернуть ключ");
			this.vbox3.Add (this.label7);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label7]));
			w14.Position = 2;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.keykeeperwidgetBackItem = new global::KeyKeeper.KeyKeeperWidget ();
			this.keykeeperwidgetBackItem.Events = ((global::Gdk.EventMask)(256));
			this.keykeeperwidgetBackItem.Name = "keykeeperwidgetBackItem";
			this.vbox3.Add (this.keykeeperwidgetBackItem);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.keykeeperwidgetBackItem]));
			w15.Position = 3;
			w15.Expand = false;
			w15.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hseparator3 = new global::Gtk.HSeparator ();
			this.hseparator3.Name = "hseparator3";
			this.vbox3.Add (this.hseparator3);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hseparator3]));
			w16.Position = 4;
			w16.Expand = false;
			w16.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label8 = new global::Gtk.Label ();
			this.label8.Name = "label8";
			this.label8.Xalign = 0F;
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString ("Взять ключ");
			this.vbox3.Add (this.label8);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label8]));
			w17.Position = 5;
			w17.Expand = false;
			w17.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.searchentry2 = new global::KeyKeeper.SearchEntry ();
			this.searchentry2.Events = ((global::Gdk.EventMask)(256));
			this.searchentry2.Name = "searchentry2";
			this.vbox3.Add (this.searchentry2);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.searchentry2]));
			w18.Position = 6;
			w18.Expand = false;
			w18.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.keykeeperwidgetGetItem = new global::KeyKeeper.KeyKeeperWidget ();
			this.keykeeperwidgetGetItem.Events = ((global::Gdk.EventMask)(256));
			this.keykeeperwidgetGetItem.Name = "keykeeperwidgetGetItem";
			this.vbox3.Add (this.keykeeperwidgetGetItem);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.keykeeperwidgetGetItem]));
			w19.Position = 7;
			w19.Expand = false;
			w19.Fill = false;
			this.vbox2.Add (this.vbox3);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.vbox3]));
			w20.Position = 1;
			w20.Expand = false;
			w20.Fill = false;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox2]));
			w21.Position = 1;
			w21.Expand = false;
			w21.Fill = false;
			// Internal child KeyKeeper.ActionDlg.ActionArea
			global::Gtk.HButtonBox w22 = this.ActionArea;
			w22.Name = "__gtksharp_70_Stetic_TopLevelDialog_ActionArea";
			// Container child __gtksharp_70_Stetic_TopLevelDialog_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.cancel = new global::Gtk.Button ();
			this.cancel.CanFocus = true;
			this.cancel.Name = "cancel";
			this.cancel.UseUnderline = true;
			this.cancel.Label = global::Mono.Unix.Catalog.GetString ("0 - Отмена");
			this.AddActionWidget (this.cancel, 0);
			global::Gtk.ButtonBox.ButtonBoxChild w23 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w22 [this.cancel]));
			w23.Expand = false;
			w23.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 291;
			this.DefaultHeight = 268;
			this.Show ();
			this.btnStartWork.Clicked += new global::System.EventHandler (this.OnBtnStartWorkClicked);
			this.btnEndWork.Clicked += new global::System.EventHandler (this.OnBtnEndWorkClicked);
			this.cancel.Clicked += new global::System.EventHandler (this.OnCancelClicked);
		}
	}
}
