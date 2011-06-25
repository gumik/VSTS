using System;
using System.Collections.Generic;

namespace vsts
{
	public class LightSystem
	{
		public LightSystem (double time, params LightGroup[] groups)
		{
			this.time = time;
			this.groups = new List<LightGroup>(groups);
		}
		
		public void AddGroup(LightGroup group)
		{
			groups.Add(group);
		}
		
		public void Tick(double time)
		{
			actTime += time;
			if (actTime >= this.time)
			{
				actTime = actTime - this.time;
			}
			
			foreach (var group in groups)
			{
				group.Tick(actTime);
			}
		}
		
		private double time;
		private double actTime;
		private List<LightGroup> groups;
	}
}

