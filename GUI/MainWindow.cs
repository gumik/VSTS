using System;
using Gtk;

namespace vsts
{

	public partial class MainWindow : Gtk.Window
	{
		public MainWindow () : base(Gtk.WindowType.Toplevel)
		{
			Build ();
			InitTraffic();
		}
		
		public TrafficControl TrafficControl 
		{ 
			get { return trafficcontrol1; } 
		}
			
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}	
		
		#region InitTraffic
		
		private void InitTraffic()
		{
			var unit = 1d;
			var sqrt5 = Math.Sqrt(5);
			var sqrt8 = Math.Sqrt(8);
			//var sqrt18 = Math.Sqrt(18);
	
			var terminatorPath = new TerminatorPath();
			
			/////////////////////////////////////////////////////////////////////////
			// Down
			
			var chooserDown = new StandardOutChooser(0.1, 0.5, 0.4);			
			var sourceDown = new SourcePath(3 * unit, new SimpleCarFactory() { }) { AddTime = 0.3 };
			var multiDown = new MultiOutPath(2 * unit, chooserDown);
			var preLeftDown = new SimplePath(sqrt5 * unit);
			var preRightDown = new SimplePath(sqrt5 * unit);
			var leftDown = new BlockingPath(6 * unit);
			var middleDown = new BlockingPath(7 * unit);
			var rightDown = new BlockingPath(5 * unit);
			var post1LeftDown = new SimplePath(2 * unit);
			var post2LeftDown = new SimplePath(sqrt8 * unit);
			var post1MiddleDown = new SimplePath(5 * unit);
			var post2MiddleDown = new SimplePath(2 * unit);
			var post3MiddleDown = new SimplePath(11 * unit);
			var postRightDown = new SimplePath(sqrt8 * unit);
			
			sourceDown.OutputPaths[0] = multiDown;
			multiDown.OutputPaths[0] = preLeftDown;
			multiDown.OutputPaths[1] = middleDown;
			multiDown.OutputPaths[2] = preRightDown;
			preLeftDown.OutputPaths[0] = leftDown;
			preRightDown.OutputPaths[0] = rightDown;
			leftDown.OutputPaths[0] = post1LeftDown;
			middleDown.OutputPaths[0] = post1MiddleDown;
			rightDown.OutputPaths[0] = postRightDown;
			post1LeftDown.OutputPaths[0] = post2LeftDown;
			post1MiddleDown.OutputPaths[0] = post2MiddleDown;
			post2MiddleDown.OutputPaths[0] = post3MiddleDown;
			
			post2LeftDown.OutputPaths[0] = terminatorPath;
			post3MiddleDown.OutputPaths[0] = terminatorPath;
			postRightDown.OutputPaths[0] = terminatorPath;
			
			// Up
			
			var chooserUp = new StandardOutChooser(0.2, 0.5, 0.3);			
			var sourceUp = new SourcePath(3 * unit, new SimpleCarFactory() { }) { AddTime = 0.3 };
			var multiUp = new MultiOutPath(2 * unit, chooserUp);
			var preLeftUp = new SimplePath(sqrt5 * unit);
			var preRightUp = new SimplePath(sqrt5 * unit);
			var leftUp = new BlockingPath(6 * unit);
			var middleUp = new BlockingPath(7 * unit);
			var rightUp = new BlockingPath(5 * unit);
			var post1LeftUp = new SimplePath(2 * unit);
			var post2LeftUp = new SimplePath(sqrt8 * unit);
			var post1MiddleUp = new SimplePath(5 * unit);
			var post2MiddleUp = new SimplePath(2 * unit);
			var post3MiddleUp = new SimplePath(11 * unit);
			var postRightUp = new SimplePath(sqrt8 * unit);
			
			sourceUp.OutputPaths[0] = multiUp;
			multiUp.OutputPaths[0] = preLeftUp;
			multiUp.OutputPaths[1] = middleUp;
			multiUp.OutputPaths[2] = preRightUp;
			preLeftUp.OutputPaths[0] = leftUp;
			preRightUp.OutputPaths[0] = rightUp;
			leftUp.OutputPaths[0] = post1LeftUp;
			middleUp.OutputPaths[0] = post1MiddleUp;
			rightUp.OutputPaths[0] = postRightUp;
			post1LeftUp.OutputPaths[0] = post2LeftUp;
			post1MiddleUp.OutputPaths[0] = post2MiddleUp;
			post2MiddleUp.OutputPaths[0] = post3MiddleUp;
			
			post2LeftUp.OutputPaths[0] = terminatorPath;
			post3MiddleUp.OutputPaths[0] = terminatorPath;
			postRightUp.OutputPaths[0] = terminatorPath;
			
			// Left
			
			var chooserLeft = new StandardOutChooser(0.4, 0.1, 0.5);			
			var sourceLeft = new SourcePath(3 * unit, new SimpleCarFactory() { }) { AddTime = 0.3 };
			var multiLeft = new MultiOutPath(2 * unit, chooserLeft);
			var preLeftLeft = new SimplePath(sqrt5 * unit);
			var preRightLeft = new SimplePath(sqrt5 * unit);
			var leftLeft = new BlockingPath(6 * unit);
			var middleLeft = new BlockingPath(7 * unit);
			var rightLeft = new BlockingPath(5 * unit);
			var post1LeftLeft = new SimplePath(2 * unit);
			var post2LeftLeft = new SimplePath(sqrt8 * unit);
			var post1MiddleLeft = new SimplePath(5 * unit);
			var post2MiddleLeft = new SimplePath(2 * unit);
			var post3MiddleLeft = new SimplePath(11 * unit);
			var postRightLeft = new SimplePath(sqrt8 * unit);
			
			sourceLeft.OutputPaths[0] = multiLeft;
			multiLeft.OutputPaths[0] = preLeftLeft;
			multiLeft.OutputPaths[1] = middleLeft;
			multiLeft.OutputPaths[2] = preRightLeft;
			preLeftLeft.OutputPaths[0] = leftLeft;
			preRightLeft.OutputPaths[0] = rightLeft;
			leftLeft.OutputPaths[0] = post1LeftLeft;
			middleLeft.OutputPaths[0] = post1MiddleLeft;
			rightLeft.OutputPaths[0] = postRightLeft;
			post1LeftLeft.OutputPaths[0] = post2LeftLeft;
			post1MiddleLeft.OutputPaths[0] = post2MiddleLeft;
			post2MiddleLeft.OutputPaths[0] = post3MiddleLeft;
			
			post2LeftLeft.OutputPaths[0] = terminatorPath;
			post3MiddleLeft.OutputPaths[0] = terminatorPath;
			postRightLeft.OutputPaths[0] = terminatorPath;
			
			// Right
			
			var chooserRight = new StandardOutChooser(0.2, 0.3, 0.5);			
			var sourceRight = new SourcePath(3 * unit, new SimpleCarFactory() { }) { AddTime = 0.3 };
			var multiRight = new MultiOutPath(2 * unit, chooserRight);
			var preLeftRight = new SimplePath(sqrt5 * unit);
			var preRightRight = new SimplePath(sqrt5 * unit);
			var leftRight = new BlockingPath(6 * unit);
			var middleRight = new BlockingPath(7 * unit);
			var rightRight = new BlockingPath(5 * unit);
			var post1LeftRight = new SimplePath(2 * unit);
			var post2LeftRight = new SimplePath(sqrt8 * unit);
			var post1MiddleRight = new SimplePath(5 * unit);
			var post2MiddleRight = new SimplePath(2 * unit);
			var post3MiddleRight = new SimplePath(11 * unit);
			var postRightRight = new SimplePath(sqrt8 * unit);
			
			sourceRight.OutputPaths[0] = multiRight;
			multiRight.OutputPaths[0] = preLeftRight;
			multiRight.OutputPaths[1] = middleRight;
			multiRight.OutputPaths[2] = preRightRight;
			preLeftRight.OutputPaths[0] = leftRight;
			preRightRight.OutputPaths[0] = rightRight;
			leftRight.OutputPaths[0] = post1LeftRight;
			middleRight.OutputPaths[0] = post1MiddleRight;
			rightRight.OutputPaths[0] = postRightRight;
			post1LeftRight.OutputPaths[0] = post2LeftRight;
			post1MiddleRight.OutputPaths[0] = post2MiddleRight;
			post2MiddleRight.OutputPaths[0] = post3MiddleRight;
			
			post2LeftRight.OutputPaths[0] = terminatorPath;
			post3MiddleRight.OutputPaths[0] = terminatorPath;
			postRightRight.OutputPaths[0] = terminatorPath;
			
			// Inter connections
			
			post2LeftDown.OutputPaths[0] = post2MiddleRight;
			post2LeftUp.OutputPaths[0] = post2MiddleLeft;
			post2LeftLeft.OutputPaths[0] = post2MiddleDown;
			post2LeftRight.OutputPaths[0] = post2MiddleUp;
			
			postRightDown.OutputPaths[0] = post3MiddleLeft;
			postRightUp.OutputPaths[0] = post3MiddleRight;
			postRightLeft.OutputPaths[0] = post3MiddleUp;
			postRightRight.OutputPaths[0] = post3MiddleDown;
			
			/////////////////////////////////////////////////////////////////////////////
						
			var groupUD = new LightGroup(false, 3, 9);
			var groupUDL = new LightGroup(true, 6, 3, 3);
			var groupLR = new LightGroup(true, 3, 3, 6);
			var groupLRL = new LightGroup(true, 9, 3);
			
			groupUD.AddPath(rightDown);
			groupUD.AddPath(rightUp);
			groupUD.AddPath(middleDown);
			groupUD.AddPath(middleUp);
			
			groupUDL.AddPath(leftDown);
			groupUDL.AddPath(leftUp);
			
			groupLR.AddPath(rightRight);
			groupLR.AddPath(rightLeft);
			groupLR.AddPath(middleRight);
			groupLR.AddPath(middleLeft);
			
			groupLRL.AddPath(leftRight);
			groupLRL.AddPath(leftLeft);
			
			var system = new LightSystem(12 
			                             ,groupUD
			                             ,groupUDL
			                             ,groupLR 
			                             ,groupLRL
			                             );
			
			th = new UpdateThread() { SleepTime = 33 };
			// Down
			th.AddPath(sourceDown);
			th.AddPath(multiDown);
			th.AddPath(preLeftDown);
			th.AddPath(preRightDown);
			th.AddPath(leftDown);
			th.AddPath(middleDown);
			th.AddPath(rightDown);
			th.AddPath(post1LeftDown);
			th.AddPath(post2LeftDown);
			th.AddPath(post1MiddleDown);
			th.AddPath(post2MiddleDown);
			th.AddPath(post3MiddleDown);
			th.AddPath(postRightDown);
			
			// Up
			th.AddPath(sourceUp);
			th.AddPath(multiUp);
			th.AddPath(preLeftUp);
			th.AddPath(preRightUp);
			th.AddPath(leftUp);
			th.AddPath(middleUp);
			th.AddPath(rightUp);
			th.AddPath(post1LeftUp);
			th.AddPath(post2LeftUp);
			th.AddPath(post1MiddleUp);
			th.AddPath(post2MiddleUp);
			th.AddPath(post3MiddleUp);
			th.AddPath(postRightUp);
			
			// Left
			th.AddPath(sourceLeft);
			th.AddPath(multiLeft);
			th.AddPath(preLeftLeft);
			th.AddPath(preRightLeft);
			th.AddPath(leftLeft);
			th.AddPath(middleLeft);
			th.AddPath(rightLeft);
			th.AddPath(post1LeftLeft);
			th.AddPath(post2LeftLeft);
			th.AddPath(post1MiddleLeft);
			th.AddPath(post2MiddleLeft);
			th.AddPath(post3MiddleLeft);
			th.AddPath(postRightLeft);
			
			// Right
			th.AddPath(sourceRight);
			th.AddPath(multiRight);
			th.AddPath(preLeftRight);
			th.AddPath(preRightRight);
			th.AddPath(leftRight);
			th.AddPath(middleRight);
			th.AddPath(rightRight);
			th.AddPath(post1LeftRight);
			th.AddPath(post2LeftRight);
			th.AddPath(post1MiddleRight);
			th.AddPath(post2MiddleRight);
			th.AddPath(post3MiddleRight);
			th.AddPath(postRightRight);
			
			th.AddLightSystem(system);
			
			var x = 300;
			var y = 500;
			var gunit = 15;
			
			// Down
			 TrafficControl.AddPath(sourceDown, x + 1 * gunit, y + 15 * gunit, x + 1 * gunit, y + 12 * gunit);
			 TrafficControl.AddPath(multiDown, x + 1 * gunit, y + 12 * gunit, x + 1 * gunit, y + 10 * gunit);
			 TrafficControl.AddPath(preLeftDown, x + 1 * gunit, y + 10 * gunit, x + 0 * gunit, y + 8 * gunit);
			 TrafficControl.AddPath(preRightDown, x + 1 * gunit, y + 10 * gunit, x + 2 * gunit, y + 8 * gunit);
			 TrafficControl.AddPath(leftDown, x + 0 * gunit, y + 8 * gunit, x + 0 * gunit, y + 3 * gunit);
			 TrafficControl.AddPath(middleDown, x + 1 * gunit, y + 10 * gunit, x + 1 * gunit, y + 3 * gunit);
			 TrafficControl.AddPath(rightDown, x + 2 * gunit, y + 8 * gunit, x + 2 * gunit, y + 3 * gunit);
			 TrafficControl.AddPath(post1LeftDown, x + 0 * gunit, y + 3 * gunit, x + 0 * gunit, y + 1 * gunit);
			 TrafficControl.AddPath(post2LeftDown, x + 0 * gunit, y + 1 * gunit, x + -2 * gunit, y + -1 * gunit);
			 TrafficControl.AddPath(post1MiddleDown, x + 1 * gunit, y + 3 * gunit, x + 1 * gunit, y + -2 * gunit);
			 TrafficControl.AddPath(post2MiddleDown, x + 1 * gunit, y + -2 * gunit, x + 1 * gunit, y + -4 * gunit);
			 TrafficControl.AddPath(post3MiddleDown, x + 1 * gunit, y + -4 * gunit, x + 1 * gunit, y + -15 * gunit);
			 TrafficControl.AddPath(postRightDown, x + 2 * gunit, y + 3 * gunit, x + 4 * gunit, y + 1 * gunit);
			
			// Up
			 TrafficControl.AddPath(sourceUp, x + -1 * gunit, y + -15 * gunit, x + -1 * gunit, y + -12 * gunit);
			 TrafficControl.AddPath(multiUp, x + -1 * gunit, y + -12 * gunit, x + -1 * gunit, y + -10 * gunit);
			 TrafficControl.AddPath(preLeftUp, x + -1 * gunit, y + -10 * gunit, x + 0 * gunit, y + -8 * gunit);
			 TrafficControl.AddPath(preRightUp, x + -1 * gunit, y + -10 * gunit, x + -2 * gunit, y + -8 * gunit);
			 TrafficControl.AddPath(leftUp, x + 0 * gunit, y + -8 * gunit, x + 0 * gunit, y + -3 * gunit);
			 TrafficControl.AddPath(middleUp, x + -1 * gunit, y + -10 * gunit, x + -1 * gunit, y + -3 * gunit);
			 TrafficControl.AddPath(rightUp, x + -2 * gunit, y + -8 * gunit, x + -2 * gunit, y + -3 * gunit);
			 TrafficControl.AddPath(post1LeftUp, x + 0 * gunit, y + -3 * gunit, x + 0 * gunit, y + -1 * gunit);
			 TrafficControl.AddPath(post2LeftUp, x + 0 * gunit, y + -1 * gunit, x + 2 * gunit, y + 1 * gunit);
			 TrafficControl.AddPath(post1MiddleUp, x + -1 * gunit, y + -3 * gunit, x + -1 * gunit, y + 2 * gunit);
			 TrafficControl.AddPath(post2MiddleUp, x + -1 * gunit, y + 2 * gunit, x + -1 * gunit, y + 4 * gunit);
			 TrafficControl.AddPath(post3MiddleUp, x + -1 * gunit, y + 4 * gunit, x + -1 * gunit, y + 15 * gunit);
			 TrafficControl.AddPath(postRightUp, x + -2 * gunit, y + -3 * gunit, x + -4 * gunit, y + -1 * gunit);
			
			// Left
			 TrafficControl.AddPath(sourceLeft, x + -15 * gunit, y + 1 * gunit, x + -12 * gunit, y + 1 * gunit);
			 TrafficControl.AddPath(multiLeft, x + -12 * gunit, y + 1 * gunit, x + -10 * gunit, y + 1 * gunit);
			 TrafficControl.AddPath(preLeftLeft, x + -10 * gunit, y + 1 * gunit, x + -8 * gunit, y + 0 * gunit);
			 TrafficControl.AddPath(preRightLeft, x + -10 * gunit, y + 1 * gunit, x + -8 * gunit, y + 2 * gunit);
			 TrafficControl.AddPath(leftLeft, x + -8 * gunit, y + 0 * gunit, x + -3 * gunit, y + 0 * gunit);
			 TrafficControl.AddPath(middleLeft, x + -10 * gunit, y + 1 * gunit, x + -3 * gunit, y + 1 * gunit);
			 TrafficControl.AddPath(rightLeft, x + -8 * gunit, y + 2 * gunit, x + -3 * gunit, y + 2 * gunit);
			 TrafficControl.AddPath(post1LeftLeft, x + -3 * gunit, y + 0 * gunit, x + -1 * gunit, y + 0 * gunit);
			 TrafficControl.AddPath(post2LeftLeft, x + -1 * gunit, y + 0 * gunit, x + 1 * gunit, y + -2 * gunit);
			 TrafficControl.AddPath(post1MiddleLeft, x + -3 * gunit, y + 1 * gunit, x + 2 * gunit, y + 1 * gunit);
			 TrafficControl.AddPath(post2MiddleLeft, x + 2 * gunit, y + 1 * gunit, x + 4 * gunit, y + 1 * gunit);
			 TrafficControl.AddPath(post3MiddleLeft, x + 4 * gunit, y + 1 * gunit, x + 15 * gunit, y + 1 * gunit);
			 TrafficControl.AddPath(postRightLeft, x + -3 * gunit, y + 2 * gunit, x + -1 * gunit, y + 4 * gunit);
			
			// Right
			 TrafficControl.AddPath(sourceRight, x + 15 * gunit, y + -1 * gunit, x + 12 * gunit, y + -1 * gunit);
			 TrafficControl.AddPath(multiRight, x + 12 * gunit, y + -1 * gunit, x + 10 * gunit, y + -1 * gunit);
			 TrafficControl.AddPath(preLeftRight, x + 10 * gunit, y + -1 * gunit, x + 8 * gunit, y + 0 * gunit);
			 TrafficControl.AddPath(preRightRight, x + 10 * gunit, y + -1 * gunit, x + 8 * gunit, y + -2 * gunit);
			 TrafficControl.AddPath(leftRight, x + 8 * gunit, y + 0 * gunit, x + 3 * gunit, y + 0 * gunit);
			 TrafficControl.AddPath(middleRight, x + 10 * gunit, y + -1 * gunit, x + 3 * gunit, y + -1 * gunit);
			 TrafficControl.AddPath(rightRight, x + 8 * gunit, y + -2 * gunit, x + 3 * gunit, y + -2 * gunit);
			 TrafficControl.AddPath(post1LeftRight, x + 3 * gunit, y + 0 * gunit, x + 1 * gunit, y + 0 * gunit);
			 TrafficControl.AddPath(post2LeftRight, x + 1 * gunit, y + 0 * gunit, x + -1 * gunit, y + 2 * gunit);
			 TrafficControl.AddPath(post1MiddleRight, x + 3 * gunit, y + -1 * gunit, x + -2 * gunit, y + -1 * gunit);
			 TrafficControl.AddPath(post2MiddleRight, x + -2 * gunit, y + -1 * gunit, x + -4 * gunit, y + -1 * gunit);
			 TrafficControl.AddPath(post3MiddleRight, x + -4 * gunit, y + -1 * gunit, x + -15 * gunit, y + -1 * gunit);
			 TrafficControl.AddPath(postRightRight, x + 3 * gunit, y + -2 * gunit, x + 1 * gunit, y + -4 * gunit);
			
			
			sourcepathcontrolUp.SourcePath = sourceUp;
			sourcepathcontrolDown.SourcePath = sourceDown;
			sourcepathcontrolLeft.SourcePath = sourceLeft;
			sourcepathcontrolRight.SourcePath = sourceRight;
				
			standardchoosercontrolDown.Chooser = chooserDown;
			standardchoosercontrolUp.Chooser = chooserUp;
			standardchoosercontrolLeft.Chooser = chooserLeft;
			standardchoosercontrolRight.Chooser = chooserRight;
			
			th.Tick += trafficcontrol1.QueueDraw;
			
			DeleteEvent += delegate { th.Stop(); };
			Show ();	
		}
		
		#endregion
		
		protected virtual void OnButtonStartClicked (object sender, System.EventArgs e)
		{
			buttonStop.Sensitive = true;
			buttonStart.Sensitive = false;
			th.Start();
		}
		
		protected virtual void OnButtonStopClicked (object sender, System.EventArgs e)
		{			
			buttonStop.Sensitive = false;
			buttonStart.Sensitive = true;
			th.Stop();
		}
		
		
		private UpdateThread th;
	}

}