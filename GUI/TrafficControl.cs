using System;
using System.Collections.Generic;
using System.Collections;
using Gtk;
using Gdk;

namespace vsts
{
	[System.ComponentModel.ToolboxItem(true)]
	public class TrafficControl : Gtk.DrawingArea
	{
		public TrafficControl ()
		{
			pathPosition = new Dictionary<Path, Tuple<Point, Point>>();
		}
		
		public void AddPath(Path path, int x1, int y1, int x2, int y2) 
		{
			pathPosition[path] = new Tuple<Point, Point>(new Point(x1, y1), new Point(x2, y2));
		}
		
		protected override bool OnButtonPressEvent (Gdk.EventButton ev)
		{
			return base.OnButtonPressEvent (ev);
		}
				
		protected override bool OnExposeEvent (Gdk.EventExpose ev)
		{
			using (Cairo.Context cr = Gdk.CairoHelper.Create (ev.Window)) {
				int w, h;
				ev.Window.GetSize (out w, out h);
				Draw (cr, w, h);
			}
			
			return true;
		}
		
		private void Draw(Cairo.Context cr, int width, int heigth)
		{
			foreach (var path in pathPosition.Keys)
			{
				var pPosition = pathPosition[path];
				var begin = pPosition.Item1;
				var end = pPosition.Item2;
				
				foreach (var vehicle in path.VehiclePosition.Keys)
				{
					var position = path.VehiclePosition[vehicle];
					var r = position / path.Length;
					var x = begin.X + (end.X - begin.X) * r;
					var y = begin.Y + (end.Y - begin.Y) * r;
					
					cr.Arc(x, y, 5, 0, 2 * Math.PI);
					cr.Fill();
				}
			}
			
			cr.Stroke();
		}
		
		private double Distance(Point p1, Point p2)
		{
			var x1 = p1.X;
			var y1 = p1.Y;
			var x2 = p2.X;
			var y2 = p2.Y;
			
			var x = x2 - x1;
			var y = y2 - y1;
			return Math.Sqrt(x*x + y*y);
		}
		
		protected override void OnSizeAllocated (Gdk.Rectangle allocation)
		{
			base.OnSizeAllocated (allocation);
		}
		protected override void OnSizeRequested (ref Gtk.Requisition requisition)
		{
			requisition.Height = 500;
			requisition.Width = 500;
		}
		
		private Dictionary<Path, Tuple<Point, Point>> pathPosition;
	}
}

