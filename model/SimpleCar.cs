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
		public double MinDistance { get; set; }
		public double Acceleration { get; set; }
		
		public string Name { get; set; }
		
		public double LookAhead { get { return MinDistance; } }
		
		public void SetRunning()
		{
			actSpeed = MaxSpeed;
		}
		
		public double Drive(double time, double obstacleDistance)
		{
			if (obstacleDistance > MinDistance) 
			{
				Accelerate(time);
			}
			else
			{
				Decelerate(obstacleDistance / MinDistance);
			}
			
			return Drive(time);
		}
		
		public bool CanStop(double obstacleDistance)
		{
			return obstacleDistance >= MinDistance;
		}
		
		private double Drive(double time)
		{
			return actSpeed * time;
		}
		
		private void Accelerate(double time)
		{
			actSpeed = Math.Min(actSpeed + Acceleration * time, MaxSpeed);
		}
		
		private void Decelerate(double obstacleDistance)
		{
			actSpeed = MaxSpeed * obstacleDistance;
		}
		
		private double actSpeed;
	}
}

