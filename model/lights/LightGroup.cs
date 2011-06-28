using System;
using System.Collections.Generic;

namespace vsts
{
	public class LightGroup
	{
		public LightGroup (bool redFirst, params double[] times)
		{
			this.redFirst = redFirst;
			red = !redFirst;
			range = new double[times.Length];
			paths = new List<BlockingPath>();
			
			var sum = 0d;
			for (int i = 0; i < times.Length; ++i)
			{
				sum += times[i];
				range[i] = sum;
			}
			
			actual = -1;
		}
		
		public void AddPath(BlockingPath path)
		{
			paths.Add(path);
			actual++;
		}
		
		public void Tick(double time)
		{
			//Console.WriteLine(time);
			var newActual = actual;
			for (int i = 0; i < range.Length; ++i)
			{
				if (time <= range[i])
				{
					newActual = i;
					//Console.WriteLine(newActual);
					break;
				}
			}
			
			if (actual != newActual)
			{
				Console.WriteLine(newActual);
				red = newActual % 2 == (redFirst ? 0 : 1);
				foreach (var path in paths)
				{
					path.IsBlocked = red;
				}
				
				actual = newActual;
			}
		}
		
		private bool red;
		private bool redFirst;
		private List<BlockingPath> paths;
		private double[] range;
		private int actual;
	}
}

