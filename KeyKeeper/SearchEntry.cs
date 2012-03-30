using System;

namespace KeyKeeper
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class SearchEntry : Gtk.Bin
	{
		public event EventHandler changed;
		
		public SearchEntry ()
		{
			this.Build ();
		}
		
		public string Text
		{
			get{return entry1.Text;}
			set{entry1.Text = value;}
		}
		
		public void ClearText()
		{
			Text = "";
		}
		
		protected void OnEntry1Changed (object sender, System.EventArgs e)
		{
			if(changed!=null)
				changed(this,e);
		}

		protected void OnClearEntry (object sender, System.EventArgs e)
		{
			ClearText();
		}
	}
}
	

