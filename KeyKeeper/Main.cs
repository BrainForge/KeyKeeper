using System;
using Gtk;

namespace KeyKeeper
{
	class MainClass
	{
		
		public static SpecialKeys specKey;
		
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			
			specKey = new SpecialKeys();
			new KeyRecivier(specKey, win);

			Application.Run ();
		}
		

	}
}
