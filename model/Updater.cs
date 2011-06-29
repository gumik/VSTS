using System;
using System.Collections.Generic;
using System.Threading;

namespace vsts
{
	public class Updater
	{
		public Updater ()
		{
			paths = new List<Path>();
			systems = new List<LightSystem>();
		}
		
		public void AddPath(Path path)
		{
			paths.Add(path);
		}
		
		public void AddLightSystem(LightSystem system)
		{
			systems.Add(system);
		}
		
		public event Action Ticked = delegate { };
		
		public void Tick(uint milis)
		{
			var time = ((double)milis / 1000);
			foreach (var system in systems)
			{
				system.Tick(time);
			}
			
			foreach (var path in paths)
			{
				path.PreGo(time);
			}
			
			foreach (var path in paths)
			{
				path.Go();
			}
						
			Ticked();
		}
		
		private List<Path> paths;
		private List<LightSystem> systems;
	}
}

