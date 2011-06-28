using System;
using Gtk;
using System.Collections.Generic;

namespace vsts
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class StandardChooserControl : Gtk.Bin
	{
		public StandardChooserControl ()
		{
			this.Build ();
			_spinIndex = new Dictionary<SpinButton, int>();
		}
		
		StandardOutChooser _chooser;
		public StandardOutChooser Chooser
		{
			get { return _chooser; }
			set
			{
				_chooser = value;
				for (int i = 0; i < _chooser.OutsNum; ++i)
				{
					var spinbutton = new SpinButton(0, 1, 0.01);
					spinbutton.Value = _chooser.GetProbability(i);
					spinbutton.ValueChanged += Changed;
					_spinIndex[spinbutton] = i;
					hbox.Add(spinbutton);
					((Box.BoxChild)hbox[spinbutton]).Position = i;
				}
				
				hbox.ShowAll();
			}
		}
		
		private void Changed(object o, EventArgs e)
		{
			var spinbutton = o as SpinButton;
			var index = _spinIndex[spinbutton];
			_chooser.SetProbability(index, spinbutton.Value);
		}
		
		private Dictionary<SpinButton, int> _spinIndex;
	}
}

