using System;
using Gtk;
using System.Collections.Generic;

namespace KeyKeeper
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class KeyKeeperWidget : Gtk.Bin
	{
		int x = 0;
		int y = 0;
		
		List<Button> buttonList = new List<Button>();
		
		public KeyKeeperWidget ()
		{
			this.Build ();
		}

		public void addButton(string text)
		{
			if(x>250)
			{
				y += 35;
				x = 0;
			}
			
			Button btn = new Button(text);
			btn.Show();
			fixed2.Add(btn);

			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [btn]));
			w1.X = x;
			w1.Y = y;
			x += 50;
			fixed2.ShowAll();
			buttonList.Add(btn);
		}
		
		public void removeButton()
		{
			foreach(Button but in buttonList)
			{
				but.Destroy();
			}
			
			buttonList.Clear();
			
			x = 0;
			y = 0;
		}
	}
}

