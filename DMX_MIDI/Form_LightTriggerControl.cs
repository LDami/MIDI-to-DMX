using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMX_MIDI
{
	public partial class Form_LightTriggerControl : Form
	{
		public Form_LightTriggerControl()
		{
			InitializeComponent();
		}

		private LightTriggerControl ltControl;
		public LightTriggerControl LTControl { get { return ltControl; } set {
				ltControl = value;
				Label_Title.Text = value.LTName;
			} }


		private void Btn_Close_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
