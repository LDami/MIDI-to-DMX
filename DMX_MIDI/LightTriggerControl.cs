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
	public enum LightTriggerType
	{
		Fixed,
		BeatDetection
	}
	public partial class LightTriggerControl : UserControl
	{
		private readonly Color defaultColor = Color.Aquamarine;
		private readonly Color selectedColor = Color.Aqua;

		private string lt_name;
		public string LTName { get { return lt_name; } set { lt_name = value; Label_Name.Text = value; } }

		private LightTriggerType type;
		public LightTriggerType Type { get { return type; } set { type = value; Label_Type.Text = value.ToString(); } }

		public LightTriggerControl()
		{
			InitializeComponent();
			this.Name = "Unnamed";
			this.Type = LightTriggerType.Fixed;
			this.Unselect();
		}
		public void Select()
		{
			this.BackColor = selectedColor;
		}
		public void Unselect()
		{
			this.BackColor = defaultColor;
		}
	}
}
