using System;
using System.Collections.Generic;

namespace vsts
{
	public class SimplePath : Path
	{
		public SimplePath (double length) : base(1, length)
		{
			
		}
		
		public override double ObstacleDistance(double lookAhead)
		{
			if (vehicles.Count != 0)
			{
				var dist = vehiclePosition[vehicles.Last.Value];
				return dist - vehicles.Last.Value.Length;
			}
			else if (lookAhead > length)
			{
				return outputPaths[0].ObstacleDistance(lookAhead - length);
			}
			else
			{
				return lookAhead;
			}
		}
		
		public override void PreGo(double time)
		{
			toGo = new LinkedList<double>();
			toGoTime = time;
			IVehicle nextVehicle = null;
			foreach (var vehicle in vehicles) 
			{
				var lookAhead = vehicle.LookAhead;
				var position = vehiclePosition[vehicle];
				
				if (nextVehicle == null)
				{
					if (length - position > lookAhead)
					{
						toGo.AddLast(length - position);
					}
					else
					{
						toGo.AddLast(length - position + outputPaths[0].ObstacleDistance(lookAhead - (length - position)));
					}
				}
				else
				{
					toGo.AddLast(vehiclePosition[nextVehicle] - vehiclePosition[vehicle] - nextVehicle.Length);
				}
				
				nextVehicle = vehicle;
			}
		}
		
		public override void Go()
		{
			//Console.WriteLine("time: " + toGoTime);
			IEnumerator<IVehicle> vehicleEn = vehicles.GetEnumerator();
			IEnumerator<double> toGoEn = toGo.GetEnumerator();
			
			var toRemove = 0;
			while (vehicleEn.MoveNext() && toGoEn.MoveNext())
			{
				var vehicle = vehicleEn.Current;
				var obstacleDistance = toGoEn.Current;
				
				var newPosition = vehiclePosition[vehicle] + vehicle.Drive(toGoTime, obstacleDistance);
				if (newPosition <= length)
				{
					vehiclePosition[vehicle] = newPosition;
					//Console.WriteLine(vehicle + " " + newPosition);
				}
				else 
				{
					outputPaths[0].AddVehicle(vehicle, newPosition - length);
					++toRemove;
					//RemoveVehicle(0);
					//Console.WriteLine("end " + (newPosition - length));
				}
			}
			
			toGoEn = null;
			
			for (int i = 0; i < toRemove; ++i)
			{
				RemoveVehicle(0);
			}
		}
		
		public override void AddVehicle (IVehicle vehicle, double position)
		{
			vehicles.AddLast(vehicle);
			vehiclePosition[vehicle] = position;
		}
		
		public override void RemoveVehicle(uint output)
		{
			var vehicle = vehicles.First.Value;
			vehicles.RemoveFirst();
			vehiclePosition.Remove(vehicle);
		}
		
		private LinkedList<double> toGo;
		private double toGoTime;
	}
}
