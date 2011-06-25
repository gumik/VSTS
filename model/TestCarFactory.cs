using System;
namespace vsts
{
	public class TestCarFactory : IVehicleFactory
	{
		public TestCarFactory ()
		{
		}
		
		public IVehicle CreateVehicle()
		{
			return new TestCar();
		}
	}
	
	class TestCar : IVehicle
	{
		#region IVehicle implementation
		public double Drive (double time, double obstacleDistance)
		{
			if (obstacleDistance > 13 * time)
				return 13 * time;
			else return 0;
		}

		public bool CanStop (double obstacleDistance)
		{
			return true;
		}

		public double Length {
			get {
				return 1;
			}
		}

		public double LookAhead {
			get {
				return 1;
			}
		}

		public string Name {get; set;}
		#endregion		
	}
}

