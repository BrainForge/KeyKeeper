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
		
		List<Button> buttonList = new List<Button>();
		List<Button> buttonList2stroka = new List<Button>();
		
		public KeyKeeperWidget()
		{
			this.Build ();
			
		}

		public void addButton(string text, Item item)
		{
			WidgetButton btn = new WidgetButton(text, item);
			btn.clickEvent += onClickEvent;
			
			if(buttonList.Count < 5)
				buttonList.Add(btn);
			else
				buttonList2stroka.Add(btn);
		}
		
		public void showAllButtons()
		{

			foreach(WidgetButton button in buttonList)
			{
				hbuttonbox2.Add(button);
				button.Show();
			}
			
			foreach(WidgetButton button in buttonList2stroka)
			{
				hbuttonbox3.Add(button);
				button.Show();
			}
			
			hbuttonbox2.Show();
			hbuttonbox3.Show();
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
				hbuttonbox2.Remove(but);
				but.Destroy();
			}
			
			foreach(Button but in buttonList2stroka)
			{
				hbuttonbox2.Remove(but);
				but.Destroy();
			}
			
			buttonList.Clear();
			buttonList2stroka.Clear();
		}
	}
}

