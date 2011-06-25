using System;
using Gtk;

namespace vsts
{
	class MainClass
	{
		private static SimpleCar car;
		
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			
			
			var path = new BlockingPath(50);
			var path1 = new SimplePath(50);
			//var path2 = new SimplePath(50);
			//var path3 = new SimplePath(50);
			//var path4 = new SimplePath(50);
			var sp = new SourcePath(10, new SimpleCarFactory() { }) { AddTime = 1 };
			var termPath = new TerminatorPath();
			
			//car = new SimpleCar() { Acceleration = 1, Length = 1, MaxSpeed = 0, MinDistance = 1 };
			//path.AddVehicle(car, 10);
			
			sp.OutputPaths[0] = path;
			path.OutputPaths[0] = path1;
			path1.OutputPaths[0] = termPath;
//			path2.OutputPaths[0] = termPath;
//			path3.OutputPaths[0] = termPath;
			
			var group = new LightGroup(true, 5, 5);
			group.AddPath(path);
			var system = new LightSystem(10, group);
			
			var th = new UpdateThread() { SleepTime = 32 };
			th.AddPath(sp);
			th.AddPath(path);
			th.AddPath(path1);
//			th.AddPath(path2);
//			th.AddPath(path3);
			th.AddPath(termPath);
			
			th.AddLightSystem(system);
			
			win.TrafficControl.AddPath(path, 100, 100, 500, 100);
			win.TrafficControl.AddPath(path1, 500, 100, 900, 100);
//			win.TrafficControl.AddPath(path2, 500, 100, 1000, 100);
//			win.TrafficControl.AddPath(path3, 500, 100, 800, 800);
			win.TrafficControl.AddPath(sp, 0, 0, 100, 100);
			
			th.Tick += delegate
			{ 
				Gtk.Application.Invoke(delegate
				{
					Gdk.Rectangle r = new Gdk.Rectangle(0, 0, 1500, 1500);
					win.GdkWindow.InvalidateRect(r, true);
				});
			};
			
			win.ButtonClicked += delegate {
				path.IsBlocked = !path.IsBlocked;
			};
			
			win.DeleteEvent += delegate { th.Stop(); };
			win.Show ();
			th.Start();
			Application.Run ();
		}
	}
}
	
	
	


