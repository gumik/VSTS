using System;
using System.Collections.Generic;
using System.Threading;

namespace vsts
{
	public class UpdateThread
	{
		public UpdateThread ()
		{
			paths = new List<Path>();
			systems = new List<LightSystem>();
		}
		
		public int SleepTime { get; set; }
		
		public void AddPath(Path path)
		{
			paths.Add(path);
		}
		
		public void AddLightSystem(LightSystem system)
		{
			systems.Add(system);
		}
		
		public void Start()
		{
			run = true;
			thread = new Thread(new ThreadStart(ThreadMethod));
			thread.Start();
		}
		
		public void Stop()
		{
			run = false;
		}
		
		public event Action Tick = delegate { };
		
		private void ThreadMethod()
		{
			while (run)
			{
				TickMethod((double)SleepTime / 1000);
				Thread.Sleep(SleepTime);
			}
		}
		
		internal void TickMethod(double time)
		{
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
						
			Tick();
		}
		
		private List<Path> paths;
		private List<LightSystem> systems;
		private bool run;
		private Thread thread;
	}
}

