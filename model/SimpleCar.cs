using System;
namespace vsts
{
	public class SimpleCar : IVehicle
	{
		public SimpleCar ()
		{
		}
		
		public double Length { get; set; }
		public double MaxSpeed { get; set; }
		public double Acceleration { get; set; }
		public double DecelerationDistance { get; set; }		
		public string Name { get; set; }
		
		public double LookAhead 
		{ 
			get { return DecelerationDistance; }
		}
		
		public void SetRunning()
		{
			actSpeed = MaxSpeed;
		}
		
		virtual public double Drive(double time, double obstacleDistance)
		{	
			var newSpeed = Math.Min((obstacleDistance / DecelerationDistance) * MaxSpeed, MaxSpeed);
			if (newSpeed > actSpeed)
			{
				newSpeed = actSpeed + time * Acceleration;
			}
			
			actSpeed = newSpeed;
			
			return actSpeed * time;
		}
		
		public bool CanStop(double obstacleDistance)
		{
			return true;
		}
		
		private double actSpeed;
	}
}

