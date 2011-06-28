using System;
namespace vsts
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class SourcePathControl : Gtk.Bin
	{
		public SourcePathControl ()
		{
			this.Build ();
		}
		
		private SourcePath _sourcePath;
		public SourcePath SourcePath 
		{ 
			get
			{
				return _sourcePath;
			}
			
			set
			{
				_sourcePath = value;
				_sourcePath.AddTime = spinbutton.Value;
			}
		}
		
		public double Value
		{
			get { return spinbutton.Value; }
			set { spinbutton.Value = value; }
		}
		
		protected virtual void OnSpinbuttonValueChanged (object sender, System.EventArgs e)
		{			
			if (SourcePath != null)
			{
				SourcePath.AddTime = spinbutton.Value;
			}
		}
		
		
	}
}