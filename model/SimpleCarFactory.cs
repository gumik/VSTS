using System;
namespace vsts
{
	public class SimpleCarFactory : IVehicleFactory
	{
		public SimpleCarFactory ()
		{
			rand = new Random();
			AccelerationMin = 1;
			AccelerationMax = 3;
			Length = 1;
			MaxSpeed = 13;
			MinDistance = 10;
		}
		
		public double AccelerationMin { get; set; }
		public double AccelerationMax { get; set; }
		public double Length { get; set; }
		public double MaxSpeed { get; set; }
		public double MinDistance { get; set; }
		
		public IVehicle CreateVehicle()
		{
			var car = new SimpleCar() 
			{ 
				Acceleration = rand.NextDouble() * (AccelerationMax - AccelerationMin) + AccelerationMin, 
				Length = Length, 
				MaxSpeed = MaxSpeed, 
				MinDistance = MinDistance 
			};
			
			car.SetRunning();
			return car;
		}
		
		private Random rand;
	}
}

