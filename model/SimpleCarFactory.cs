using System;
namespace vsts
{
	public class SimpleCarFactory : IVehicleFactory
	{
		public SimpleCarFactory ()
		{
			DecelerationDistance = 2;
			Length = 1;
			MaxSpeed = 13;
			Acceleration = 8;
		}
		
		public double Length { get; set; }
		public double MaxSpeed { get; set; }
		public double DecelerationDistance { get; set; }
		public double Acceleration { get; set; }
		
		public IVehicle CreateVehicle()
		{
			var car = new SimpleCar() 
			{ 
				DecelerationDistance = DecelerationDistance,
				Length = Length, 
				MaxSpeed = MaxSpeed, 
				Acceleration = Acceleration
			};
			
			car.SetRunning();
			return car;
		}
	}
}

