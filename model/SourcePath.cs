using System;
namespace vsts
{
	public class SourcePath : SimplePath
	{
		public SourcePath (double length, IVehicleFactory factory) : base(length)
		{
			lastAddTime = 0;
			this.factory = factory;
		}
		
		public double AddTime { get; set; }
		
		public override void PreGo(double time) 
		{
			base.PreGo(time);
			lastAddTime += time;
			if (lastAddTime >= AddTime) 
			{
				lastAddTime = 0;
			}
		}
		
		public override void Go ()
		{
			base.Go();
			if (lastAddTime == 0)
			{
				var vehicle = factory.CreateVehicle();
				AddVehicle(vehicle, 0);
			}
		}
		
		private double lastAddTime;
		private IVehicleFactory factory;
	}
}

