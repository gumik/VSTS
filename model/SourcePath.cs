using System;
namespace vsts
{
	public class SourcePath : Path
	{
		public SourcePath (double length) : base(1, 1)
		{
			lastAddTime = DateTime.Now;
		}
		
		public override void PreGo(double time) 
		{
			
		}
		
		public override void Go ()
		{
			
		}
		
		public override double ObstacleDistance (double lookAhead)
		{
			throw new NotImplementedException ();
		}
		
		public override void AddVehicle (IVehicle vehicle, double position)
		{
			
		}
		
		override public void RemoveVehicle(uint output)
		{
		}
		
		private DateTime lastAddTime;
	}
}

