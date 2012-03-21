using System;
using Gtk;

namespace KeyKeeper
{
	public class WidgetButton : Button
	{
		private Item item;
		
		public delegate void ClickEventHeader(object sender, Item ca);
		public event ClickEventHeader clickEvent;
		
		public WidgetButton (string text, Item item, Fixed fix, int x, int y) : base(text)
		{
			this.item = item;
			this.Show();
			fix.Add(this);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(fix [this]));
			w1.X = x;
			w1.Y = y;
			fix.ShowAll();
		}
		
		protected override void OnClicked ()
		{
			if(clickEvent!=null)
				clickEvent(this,item);
		}
	}
}

