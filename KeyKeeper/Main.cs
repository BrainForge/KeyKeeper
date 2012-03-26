using System;
using Gtk;

namespace KeyKeeper
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			
			new SpecialKeys();
			
			Application.Run ();
		}
	}
}
