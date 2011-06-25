using System;
using System.Collections.Generic;

namespace vsts
{
	public class MultiOutPath : Path
	{
		public MultiOutPath (double length, IOutChooser outChooser) : base(outChooser.OutsNum, length)
		{
			this.outChooser = outChooser;
			nextOut = outChooser.Choose();
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
				return outputPaths[nextOut].ObstacleDistance(lookAhead - length);
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
						toGo.AddLast(length - position + outputPaths[nextOut].ObstacleDistance(lookAhead - (length - position)));
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
			IEnumerator<IVehicle> vehicleEn = vehicles.GetEnumerator();
			IEnumerator<double> toGoEn = toGo.GetEnumerator();
			
			var toOut = new List<Tuple<IVehicle, double, uint>>();
			while (vehicleEn.MoveNext() && toGoEn.MoveNext())
			{
				var vehicle = vehicleEn.Current;
				var obstacleDistance = toGoEn.Current;
				
				var newPosition = vehiclePosition[vehicle] + vehicle.Drive(toGoTime, obstacleDistance);
				if (newPosition <= length)
				{
					vehiclePosition[vehicle] = newPosition;
				}
				else 
				{
					toOut.Add(new Tuple<IVehicle, double, uint>(vehicle, newPosition - length, nextOut));
					nextOut = outChooser.Choose();
				}
			}
			
			toGoEn = null;
			
			foreach (var t in toOut)
			{
				var vehicle = t.Item1;
				var position = t.Item2;
				var output = t.Item3;
				
				RemoveVehicle(output);
				outputPaths[output].AddVehicle(vehicle, position);
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
		private uint nextOut;
		private IOutChooser outChooser;
	}
}

