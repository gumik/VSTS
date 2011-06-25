using System;
namespace vsts
{
	public interface IOutChooser
	{
		uint OutsNum { get; }
		uint Choose();
	}
}

