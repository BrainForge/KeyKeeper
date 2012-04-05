using System;
using Gtk;

namespace KeyKeeper
{
	public class WidgetButton : Button
	{
		private Item item;
		
		public delegate void ClickEventHeader(object sender, Item ca);
		public event ClickEventHeader clickEvent;
		
		public WidgetButton (string text, Item item) : base(text)
		{
			this.item = item;
			this.Show();
		}
		
		protected override void OnClicked ()
		{
			if(clickEvent!=null)
				clickEvent(this,item);
		}
	}
}

