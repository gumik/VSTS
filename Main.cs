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
			
			
			var path = new SimplePath(50);
			var path2 = new SimplePath(50);
			var path3 = new SimplePath(50);
			var path4 = new SimplePath(50);
			var sp = new SourcePath(10, new SimpleCarFactory() { }) { AddTime = 1 };
			
//			var rand = new Random();
//			for (int i = 45; i >= 0; --i) 
//			{
//				path2.AddVehicle(new SimpleCar() { Acceleration = rand.NextDouble() * 5 + 1, Length = 1, MaxSpeed = rand.NextDouble() * 2 + 4, MinDistance = 2 }, i);
//			}
			
			car = new SimpleCar() { Acceleration = 1, Length = 1, MaxSpeed = 0, MinDistance = 1 };
			path.AddVehicle(car, 10);
			
			//var termPath = new TerminatorPath();
			sp.OutputPaths[0] = path;
			path.OutputPaths[0] = path2;
			path2.OutputPaths[0] = path3;
			path3.OutputPaths[0] = path4;
			path4.OutputPaths[0] = path;
			
			var th = new UpdateThread() { SleepTime = 32 };
			th.AddPath(sp);
			th.AddPath(path);
			th.AddPath(path2);
			th.AddPath(path3);
			th.AddPath(path4);
			
			win.TrafficControl.AddPath(path, 100, 100, 1000, 100);
			win.TrafficControl.AddPath(path2, 1000, 100, 1000, 1000);
			win.TrafficControl.AddPath(path3, 1000, 1000, 100, 1000);
			win.TrafficControl.AddPath(path4, 100, 1000, 100, 100);
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
				Console.WriteLine("delegate");
				if (car.MaxSpeed > 0)
				{
					car.MaxSpeed = 0;
					Console.WriteLine("0");
				}
				else
				{
					car.MaxSpeed = 15;
					Console.WriteLine("15");
				}
			};
			
			win.DeleteEvent += delegate { th.Stop(); };
			win.Show ();
			th.Start();
			Application.Run ();
		}
	}
}
	
	
	


