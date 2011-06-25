using System;
using System.Linq;

namespace vsts
{
	public class StandardOutChooser : IOutChooser
	{
		public StandardOutChooser (params double[] probs)
		{
			rand = new Random();
			range = new double[probs.Length];
			
			var sum = 0d;
			for (int i = 0; i < probs.Length; ++i)
			{
				sum += probs[i];
				range[i] = sum;
			}
		}
		
		public uint OutsNum { get { return (uint)range.Length; } }
		
		public uint Choose()
		{
			var r = rand.NextDouble();
			for (int i = 0; i < range.Length; ++i)
			{
				if (r < range[i])
				{
					return (uint)i;
				}
			}
			
			return (uint)(range.Length - 1);
		}
		
		double[] range;
		Random rand;
	}
}

