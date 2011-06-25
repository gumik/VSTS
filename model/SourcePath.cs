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
				++toAdd;
			}
		}
		
		public override void Go ()
		{
			base.Go();
			if (toAdd > 0)
			{
				var vehicle = null as IVehicle;
				if (toAddVehicle == null)
				{
					vehicle = factory.CreateVehicle();
				}
				else
				{
					vehicle = toAddVehicle;
				}
				
				if (vehicles.Count == 0 
				    || vehiclePosition[vehicles.Last.Value] - vehicles.Last.Value.Length >= 0)
				{
					AddVehicle(vehicle, 0);
					toAddVehicle = null;
					--toAdd;
				}
			}
		}
		
		private double lastAddTime;
		private uint toAdd;
		private IVehicle toAddVehicle;
		private IVehicleFactory factory;
	}
}

