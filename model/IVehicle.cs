using System;
namespace vsts
{
	public interface IVehicle
	{
		/// <summary>
		/// Length of the vehicle.
		/// </summary>
		double Length { get; }
		
		/// <summary>
		/// Distance on front of the vehicle that should be known.
		/// </summary>
		double LookAhead { get; }

		string Name { get; set; }
		
		/// <summary>
		/// Simulates driving the vehicle for specified <paramref name="time"/> 
		/// and having first obstacle at <paramref name="obstacleDistance"/> distance.
		/// </summary>
		/// <param name="time">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="obstacleDistance">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Double"/>
		/// </returns>
		double Drive(double time, double obstacleDistance);
		
		bool CanStop(double obstacleDistance);
	}
}

