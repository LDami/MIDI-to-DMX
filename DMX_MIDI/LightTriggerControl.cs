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

		private LightTriggerType lt_type;
		public LightTriggerType LTType { get { return lt_type; } set { lt_type = value; Label_Type.Text = value.ToString(); } }

		private OnBeatEvent lt_evt;
		public OnBeatEvent LTEvt { get { return lt_evt; } set { lt_evt = value; Label_Event.Text = value.ToString(); } }

		private Color primaryColor;
		public Color PrimaryColor { get { return primaryColor; } set { primaryColor = value;} }

		private Color secondaryColor;
		public Color SecondaryColor { get { return secondaryColor; } set { secondaryColor = value;} }

		private Form_LightTriggerControl ltForm;
		public LightTriggerControl()
		{
			InitializeComponent();
			this.Name = lt_name;
			this.Label_Type.Text = lt_type.ToString();
			this.Label_Event.Text = lt_evt.ToString();
			this.Rect_PrimaryColor.BackColor = primaryColor;
			this.Rect_SecondaryColor.BackColor = secondaryColor;
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

		public void Edit()
		{
			ltForm = new();
			ltForm.LTControl = this;
			ltForm.LightTriggerChanged += LtForm_LightTriggerChanged;
			ltForm.Show();
		}

        private void LtForm_LightTriggerChanged(object sender, Form_LightTriggerControl.LightTriggerEventArgs e)
		{
			lt_type = e.LightTriggerType;
			this.Label_Type.Text = lt_type.ToString();

			lt_evt = e.OnBeatEvent;
			this.Label_Event.Text = lt_evt.ToString();

			primaryColor = e.PrimaryColor;
			this.Rect_PrimaryColor.BackColor = primaryColor;

			secondaryColor = e.SecondaryColor;
			this.Rect_SecondaryColor.BackColor = secondaryColor;
		}
    }
}
