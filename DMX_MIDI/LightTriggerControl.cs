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

	// TODO Créer enum pour différents effets de lumière sur beat: flash, bounce, changement de couleur fixe (random ou custom)
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
			Btn_Edit.BackColor = selectedColor;
		}
		public void Unselect()
		{
			this.BackColor = defaultColor;
			Btn_Edit.BackColor = defaultColor;
		}

		private void Btn_Edit_Click(object sender, EventArgs e)
		{
			Form_LightTriggerControl ltForm = new();
			ltForm.Show();
			ltForm.LTControl = this;
		}
	}
}
