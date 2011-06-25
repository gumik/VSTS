using System;
namespace vsts
{
	public class TerminatorPath : Path
	{
		public TerminatorPath () : base(0, 0)
		{
		}
		
		public override double ObstacleDistance(double lookAhead)
		{
			return lookAhead;
		}
		
		public override void PreGo(double time)
		{
		}
		
		public override void Go()
		{
			
		}
		
		public override void AddVehicle (IVehicle vehicle, double position)
		{
			
		}
		
		public override void RemoveVehicle(uint output)
		{
			
		}
	}
}

