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
			
			var unit = 1d;
			var sqrt5 = Math.Sqrt(5);
			var sqrt8 = Math.Sqrt(8);
			var sqrt18 = Math.Sqrt(18);
	
			var terminatorPath = new TerminatorPath();
			
			// Down
			
			var chooserDown = new StandardOutChooser(0.15, 0.6, 0.25);
			
			var sourceDown = new SourcePath(5 * unit, new TestCarFactory() { }) { AddTime = 0.3 };
			var multiDown = new MultiOutPath(5 * unit, chooserDown);
			var preLeftDown = new SimplePath(sqrt5 * unit);
			var preRightDown = new SimplePath(sqrt5 * unit);
			var leftDown = new BlockingPath(6 * unit);
			var middleDown = new BlockingPath(7 * unit);
			var rightDown = new BlockingPath(5 * unit);
			var postLeftDown = new SimplePath(sqrt18 * unit);
			var post1MiddleDown = new SimplePath(6 * unit);
			var post2MiddleDown = new SimplePath(1 * unit);
			var post3MiddleDown = new SimplePath(5 * unit);
			var postRightDown = new SimplePath(sqrt8 * unit);
			
			sourceDown.OutputPaths[0] = multiDown;
			multiDown.OutputPaths[0] = preLeftDown;
			multiDown.OutputPaths[1] = middleDown;
			multiDown.OutputPaths[2] = preRightDown;
			preLeftDown.OutputPaths[0] = leftDown;
			preRightDown.OutputPaths[0] = rightDown;
			leftDown.OutputPaths[0] = postLeftDown;
			middleDown.OutputPaths[0] = post1MiddleDown;
			rightDown.OutputPaths[0] = postRightDown;
			post1MiddleDown.OutputPaths[0] = post2MiddleDown;
			post2MiddleDown.OutputPaths[0] = post3MiddleDown;
			
			postLeftDown.OutputPaths[0] = terminatorPath;
			post3MiddleDown.OutputPaths[0] = terminatorPath;
			postRightDown.OutputPaths[0] = terminatorPath;
			
//			// Down
//			
//			var chooserDown = new StandardOutChooser(0.15, 0.6, 0.25);
//			var sourceDown = new SourcePath(5 * unit, new SimpleCarFactory() { }) { AddTime = 1 };
//			var multiDown = new MultiOutPath(5 * unit, chooserDown);
//			var preLeftDown = new SimplePath(sqrt3 * unit);
//			var preRightDown = new SimplePath(sqrt3 * unit);
//			var leftDown = new BlockingPath(6 * unit);
//			var middleDown = new BlockingPath(7 * unit);
//			var rightDown = new BlockingPath(5 * unit);
//			var postLeftDown = new SimplePath(sqrt18 * unit);
//			var post1MiddleDown = new SimplePath(6 * unit);
//			var post2MiddleDown = new SimplePath(1 * unit);
//			var post3MiddleDown = new SimplePath(5 * unit);
//			var postRightDown = new SimplePath(sqrt8 * unit);
//			
//			// Down
//			
//			var chooserDown = new StandardOutChooser(0.15, 0.6, 0.25);
//			var sourceDown = new SourcePath(5 * unit, new SimpleCarFactory() { }) { AddTime = 1 };
//			var multiDown = new MultiOutPath(5 * unit, chooserDown);
//			var preLeftDown = new SimplePath(sqrt3 * unit);
//			var preRightDown = new SimplePath(sqrt3 * unit);
//			var leftDown = new BlockingPath(6 * unit);
//			var middleDown = new BlockingPath(7 * unit);
//			var rightDown = new BlockingPath(5 * unit);
//			var postLeftDown = new SimplePath(sqrt18 * unit);
//			var post1MiddleDown = new SimplePath(6 * unit);
//			var post2MiddleDown = new SimplePath(1 * unit);
//			var post3MiddleDown = new SimplePath(5 * unit);
//			var postRightDown = new SimplePath(sqrt8 * unit);
//			
//			// Down
//			
//			var chooserDown = new StandardOutChooser(0.15, 0.6, 0.25);
//			var sourceDown = new SourcePath(5 * unit, new SimpleCarFactory() { }) { AddTime = 1 };
//			var multiDown = new MultiOutPath(5 * unit, chooserDown);
//			var preLeftDown = new SimplePath(sqrt3 * unit);
//			var preRightDown = new SimplePath(sqrt3 * unit);
//			var leftDown = new BlockingPath(6 * unit);
//			var middleDown = new BlockingPath(7 * unit);
//			var rightDown = new BlockingPath(5 * unit);
//			var postLeftDown = new SimplePath(sqrt18 * unit);
//			var post1MiddleDown = new SimplePath(6 * unit);
//			var post2MiddleDown = new SimplePath(1 * unit);
//			var post3MiddleDown = new SimplePath(5 * unit);
//			var postRightDown = new SimplePath(sqrt8 * unit);
			
			/////////////////////////////////
						
			var groupLeft = new LightGroup(true, 2, 6);
			var groupRight = new LightGroup(true, 2, 6);
			groupLeft.AddPath(leftDown);
			groupRight.AddPath(middleDown);
			groupRight.AddPath(rightDown);
			var system = new LightSystem(8, groupLeft, groupRight);
			
			var th = new UpdateThread() { SleepTime = 32 };
			th.AddPath(sourceDown);
			th.AddPath(multiDown);
			th.AddPath(preLeftDown);
			th.AddPath(preRightDown);
			th.AddPath(leftDown);
			th.AddPath(middleDown);
			th.AddPath(rightDown);
			th.AddPath(postLeftDown);
			th.AddPath(post1MiddleDown);
			th.AddPath(post2MiddleDown);
			th.AddPath(post3MiddleDown);
			th.AddPath(postRightDown);
			
			th.AddLightSystem(system);
			
			var x = 100;
			var y = 100;
			var gunit = 30;
			win.TrafficControl.AddPath(sourceDown, x + 0 * gunit, y + 0 * gunit, x + 0 * gunit, y + 5 * gunit);
			win.TrafficControl.AddPath(multiDown, x + 0 * gunit, y + 5 * gunit, x + 0 * gunit, y + 10 * gunit);
			win.TrafficControl.AddPath(preLeftDown, x + 0 * gunit, y + 10 * gunit, x -1 * gunit, y + 12 * gunit);
			win.TrafficControl.AddPath(preRightDown, x + 0 * gunit, y + 10 * gunit, x + 1 * gunit, y + 12 * gunit);
			win.TrafficControl.AddPath(leftDown, x - 1 * gunit, y + 12 * gunit, x + -1 * gunit, y + 18 * gunit);
			win.TrafficControl.AddPath(middleDown, x + 0 * gunit, y + 10 * gunit, x + 0 * gunit, y + 17 * gunit);
			win.TrafficControl.AddPath(rightDown, x + 1 * gunit, y + 12 * gunit, x + 1 * gunit, y + 17 * gunit);
//			win.TrafficControl.AddPath(sourceDown, x + 0 * gunit, y + 0 * gunit, x + 0 * gunit, y + 5 * gunit);
//			win.TrafficControl.AddPath(sourceDown, x + 0 * gunit, y + 0 * gunit, x + 0 * gunit, y + 5 * gunit);
//			win.TrafficControl.AddPath(sourceDown, x + 0 * gunit, y + 0 * gunit, x + 0 * gunit, y + 5 * gunit);
//			win.TrafficControl.AddPath(sourceDown, x + 0 * gunit, y + 0 * gunit, x + 0 * gunit, y + 5 * gunit);
			
			
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
	
	
	


