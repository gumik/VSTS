using System;
using System.Collections.Generic;

namespace vsts
{
	public abstract class Path
	{
		protected Path(int outputPathsNum, double length)
		{
			this.length = length;
			outputPaths = new Path[outputPathsNum];
			vehicles = new LinkedList<IVehicle>();
			vehiclePosition = new Dictionary<IVehicle, double>();
		}
		
		abstract public double ObstacleDistance(double lookAhead);
		abstract public void PreGo(double time);
		abstract public void Go();
		
		abstract public void AddVehicle(IVehicle vehicle, double position);
		abstract public void RemoveVehicle(uint output);
		
		public Path[] OutputPaths { get { return outputPaths; } }
		public ICollection<IVehicle> Vehicles { get { return vehicles; } }
		public IDictionary<IVehicle, double> VehiclePosition { get { return vehiclePosition; } }
		public double Length { get { return length; } }
		
		protected Path[] outputPaths;
		protected LinkedList<IVehicle> vehicles;
		protected Dictionary<IVehicle, double> vehiclePosition;
		protected double length;
	}
}
