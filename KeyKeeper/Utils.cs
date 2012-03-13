using System;
using Gtk;

namespace KeyKeeper
{
	public static class Utils
	{
		public static void showMessageError(string text)
		{
			MessageDialog glg = new MessageDialog (null, 
                  DialogFlags.DestroyWithParent,
	               MessageType.Error, 
                    ButtonsType.Ok, text);
			if((ResponseType)glg.Run() == ResponseType.Ok)
				glg.Destroy();
		}
		
		public static void showMessageInfo(string text)
		{
			MessageDialog glg = new MessageDialog (null, 
                  DialogFlags.DestroyWithParent,
	               MessageType.Info, 
                    ButtonsType.Ok, text);
			if((ResponseType)glg.Run() == ResponseType.Ok)
				glg.Destroy();
		}
	}
}

