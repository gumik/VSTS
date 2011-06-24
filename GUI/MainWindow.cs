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
//		
//		public event ButtonPressEventHandler ButtonPressed
//		{
//			add	{ button1.ButtonPressEvent += value; }
//			remove { button1.ButtonPressEvent -= value; }
//		}
			
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}
	}

}