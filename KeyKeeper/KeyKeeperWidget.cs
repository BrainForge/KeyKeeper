using System;
using Gtk;
using System.Collections.Generic;

namespace KeyKeeper
{
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class KeyKeeperWidget : Gtk.Bin
	{
		public delegate void ClickEventHeader(object sender, Item ca);
		public event ClickEventHeader clickEvent;
		
		int x = 0;
		int y = 0;
		
		List<Button> buttonList = new List<Button>();
		
		public KeyKeeperWidget ()
		{
			this.Build ();
		}

		public void addButton(string text, Item item)
		{
			if(x>250)
			{
				y += 35;
				x = 0;
			}
			WidgetButton btn = new WidgetButton(text, item,fixed2, x, y);
			btn.clickEvent += onClickEvent;
			
			fixed2.Add(btn);	
			x += 50;
			fixed2.ShowAll();
			buttonList.Add(btn);
		}
		
		public void onClickEvent(object sender, Item ca)
		{
			if(clickEvent!=null)
				clickEvent(this, ca);
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

