using System;
using Gtk;

namespace KeyKeeper
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class KeyKeeperWidget : Gtk.Bin
	{
		int x = 0;
		public KeyKeeperWidget ()
		{
			this.Build ();
		}

		public void addButton(string text)
		{
			Button btn = new Button(text);
			btn.Show();
			fixed2.Add(btn);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [btn]));
			w1.X = x;
			w1.Y = 0;
			x += 50;
			fixed2.ShowAll();
		}
	}
}

