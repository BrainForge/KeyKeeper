
// This file has been generated by the GUI designer. Do not modify.
namespace KeyKeeper
{
	public partial class KeyKeeperWidget
	{
		private global::Gtk.Fixed fixed2;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget KeyKeeper.KeyKeeperWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "KeyKeeper.KeyKeeperWidget";
			// Container child KeyKeeper.KeyKeeperWidget.Gtk.Container+ContainerChild
			this.fixed2 = new global::Gtk.Fixed ();
			this.fixed2.Name = "fixed2";
			this.fixed2.HasWindow = false;
			this.Add (this.fixed2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}
