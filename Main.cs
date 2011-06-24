using System;
using Gtk;

namespace vsts
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			
			
			var path = new SimplePath(50);
			var path2 = new SimplePath(50);
			var path3 = new SimplePath(50);
			var path4 = new SimplePath(50);
			
			
			var rand = new Random();
			for (int i = 45; i >= 0; --i) 
			{
				path2.AddVehicle(new SimpleCar() { Acceleration = rand.NextDouble() * 5 + 1, Length = 1, MaxSpeed = rand.NextDouble() * 2 + 4, MinDistance = 2 }, i);
			}
			
			path4.AddVehicle(new SimpleCar(), 10);
			
			
			
			var termPath = new TerminatorPath();
			path.OutputPaths[0] = path2;
			path2.OutputPaths[0] = path3;
			path3.OutputPaths[0] = path4;
			path4.OutputPaths[0] = path;
			
			var th = new UpdateThread() { SleepTime = 32 };
			th.AddPath(path);
			th.AddPath(path2);
			th.AddPath(path3);
			th.AddPath(path4);
			
			win.TrafficControl.AddPath(path, 100, 100, 1000, 100);
			win.TrafficControl.AddPath(path2, 1000, 100, 1000, 1000);
			win.TrafficControl.AddPath(path3, 1000, 1000, 100, 1000);
			win.TrafficControl.AddPath(path4, 100, 1000, 100, 100);
			
			th.Tick += delegate
			{ 
				Gtk.Application.Invoke(delegate
				{
					Gdk.Rectangle r = new Gdk.Rectangle(0, 0, 1500, 1500);
					win.GdkWindow.InvalidateRect(r, true);
				});
			};
			
			win.KeyPressEvent += delegate 
			{
				//path.AddVehicle(new SimpleCar() { Acceleration = 5, Length = 1, MaxSpeed = 5, MinDistance = 1 }, 0);
				//th.TickMethod(0.16);
				//th.Start();
			};
			
			win.DeleteEvent += delegate { th.Stop(); };
			win.Show ();
			th.Start();
			Application.Run ();
		}
	}
}

