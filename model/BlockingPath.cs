using System;
using System.Collections.Generic;

namespace vsts
{
	public class BlockingPath : SimplePath
	{
		public BlockingPath (double length) : base(length)
		{
		}
		
		public bool IsBlocked { get; set; }
		
		public override double ObstacleDistance(double lookAhead)
		{
			if (vehicles.Count != 0)
			{
				var dist = vehiclePosition[vehicles.Last.Value];
				return dist - vehicles.Last.Value.Length;
			}
			else if (lookAhead > length)
			{
				if (IsBlocked)
				{
					return length;
				}
				else
				{					
					return outputPaths[0].ObstacleDistance(lookAhead - length);
				}
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
					else if (IsBlocked)
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
	}
}

