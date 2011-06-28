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
			
			
			Application.Run ();
		}
	}
}
	
	
	


