using System;
using Gtk;

namespace vsts
{

	public partial class MainWindow : Gtk.Window
	{
		public MainWindow () : base(Gtk.WindowType.Toplevel)
		{
			Build ();
		}
		
		public TrafficControl TrafficControl 
		{ 
			get { return trafficcontrol1; } 
		}
		
		public event EventHandler ButtonClicked
		{
			add	{ button1.Clicked += value; }
			remove { button1.Clicked -= value; }
		}
			
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}		
	}

}