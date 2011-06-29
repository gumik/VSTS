using System;
using Gtk;

namespace vsts
{
	class Test
	{
		static SimpleCar car = new SimpleCar() { Length = 1, MaxSpeed = 0, DecelerationDistance = 5 };
		
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
	
			var terminatorPath = new TerminatorPath();
			
			// Down
			
			//var sourceDown = new SourcePath(10, new SimpleCarFactory() { }) { AddTime = 2};
			var path = new SimplePath(50);
			path.AddVehicle(car, 30);
			path.AddVehicle(new SimpleCar() { Length = 1, MaxSpeed = 13 , DecelerationDistance = 5 }, 0);
			
			//sourceDown.OutputPaths[0] = path;
			path.OutputPaths[0] = terminatorPath;
			
			/////////////////////////////////
			var th = new UpdateThread() { SleepTime = 32 };
			//th.AddPath(sourceDown);
			th.AddPath(path);
			
			//win.TrafficControl.AddPath(sourceDown, 10, 10, 100, 10);
			win.TrafficControl.AddPath(path, 100, 10, 100, 510);
			
			th.Tick += delegate
			{ 
				Gtk.Application.Invoke(delegate
				{
					Gdk.Rectangle r = new Gdk.Rectangle(0, 0, 1500, 1500);
					win.GdkWindow.InvalidateRect(r, true);
				});
			};
			
			win.DeleteEvent += delegate { th.Stop(); };
			win.Show ();
			th.Start();
			Application.Run ();
		}
	}
}
	
	
	


