
// This file has been generated by the GUI designer. Do not modify.
namespace vsts
{
	public partial class SourcePathControl
	{
		private global::Gtk.SpinButton spinbutton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget vsts.SourcePathControl
			global::Stetic.BinContainer.Attach (this);
			this.Name = "vsts.SourcePathControl";
			// Container child vsts.SourcePathControl.Gtk.Container+ContainerChild
			this.spinbutton = new global::Gtk.SpinButton (0, 100, 0.01);
			this.spinbutton.CanFocus = true;
			this.spinbutton.Name = "spinbutton";
			this.spinbutton.Adjustment.PageIncrement = 10;
			this.spinbutton.ClimbRate = 1;
			this.spinbutton.Numeric = true;
			this.Add (this.spinbutton);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.spinbutton.ValueChanged += new global::System.EventHandler (this.OnSpinbuttonValueChanged);
		}
	}
}
