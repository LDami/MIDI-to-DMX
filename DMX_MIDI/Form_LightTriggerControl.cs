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
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		private void Form_LightTriggerControl_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		// Events
		public class LightTriggerEventArgs : EventArgs
        {
			public LightTriggerType LightTriggerType;
			public OnBeatEvent OnBeatEvent;
			public Color PrimaryColor;
			public Color SecondaryColor;
        }
		public event EventHandler<LightTriggerEventArgs> LightTriggerChanged;
		protected virtual void OnLightTriggerChanged(LightTriggerEventArgs e)
        {
			LightTriggerChanged?.Invoke(this, e);
		}

		// Public properties
		private LightTriggerControl ltControl;
		public LightTriggerControl LTControl
		{
			get { return ltControl; }
			set
			{
				ltControl = value;
				Label_Title.Text = value.LTName;
			}
		}

		// Private variables
		private Slider red, green, blue;
		private Color primaryColor, secondaryColor;
		private bool isPrimarySelected;
		public Form_LightTriggerControl()
		{
			InitializeComponent();

			red = new Slider(Slider_Red_Value, Line_Red_Value, 255, Slider.Color.R);
			green = new Slider(Slider_Green_Value, Line_Green_Value, 255, Slider.Color.G);
			blue = new Slider(Slider_Blue_Value, Line_Blue_Value, 255, Slider.Color.B);
			isPrimarySelected = true;
			Btn_PrimaryColor.FlatStyle = FlatStyle.Standard;
			Btn_SecondaryColor.FlatStyle = FlatStyle.Flat;
		}

		private void Form_LightTriggerControl_Shown(object sender, EventArgs e)
		{
			if (ltControl != null)
			{
				List_Type.Items.AddRange(Enum.GetNames(typeof(LightTriggerType)));
				List_Type.SelectedIndex = List_Type.Items.IndexOf(ltControl.LTType.ToString());

				List_EventType.Items.AddRange(Enum.GetNames(typeof(OnBeatEvent)));
				List_EventType.SelectedIndex = List_EventType.Items.IndexOf(ltControl.LTEvt.ToString());

				primaryColor = ltControl.PrimaryColor;
				secondaryColor = ltControl.SecondaryColor;
				red.CurrentValue = primaryColor.R;
				green.CurrentValue = primaryColor.G;
				blue.CurrentValue = primaryColor.B;
				UpdateColors();
			}
			else
				Console.WriteLine("ltControl is null");
		}

		private void Btn_Save_Click(object sender, EventArgs e)
		{
			OnLightTriggerChanged(new LightTriggerEventArgs
			{
				LightTriggerType = (LightTriggerType)List_Type.SelectedIndex,
				OnBeatEvent = (OnBeatEvent)List_EventType.SelectedIndex,
				PrimaryColor = primaryColor,
				SecondaryColor = secondaryColor
			});
			this.Close();
		}

		private void Btn_Close_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void Btn_PrimaryColor_Click(object sender, EventArgs e)
		{
			isPrimarySelected = true;
			Btn_PrimaryColor.FlatStyle = FlatStyle.Standard;
			Btn_SecondaryColor.FlatStyle = FlatStyle.Flat;

			red.CurrentValue = primaryColor.R;
			green.CurrentValue = primaryColor.G;
			blue.CurrentValue = primaryColor.B;
		}

		private void Btn_SecondaryColor_Click(object sender, EventArgs e)
		{
			isPrimarySelected = false;
			Btn_PrimaryColor.FlatStyle = FlatStyle.Flat;
			Btn_SecondaryColor.FlatStyle = FlatStyle.Standard;

			red.CurrentValue = secondaryColor.R;
			green.CurrentValue = secondaryColor.G;
			blue.CurrentValue = secondaryColor.B;
		}

		bool RedSliderIsMoving;
		Point RedSliderLastLocation;
		bool GreenSliderIsMoving;
		Point GreenSliderLastLocation;
		bool BlueSliderIsMoving;
		Point BlueSliderLastLocation;

		private void Slider_Red_Value_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				RedSliderIsMoving = true;
				RedSliderLastLocation = e.Location;
			}
		}

		private void Slider_Red_Value_MouseMove(object sender, MouseEventArgs e)
		{
			if (RedSliderIsMoving)
			{
				Point newLocation = new Point(
					(Slider_Red_Value.Location.X - RedSliderLastLocation.X) + e.X,
					Slider_Red_Value.Location.Y
				);
				Slider_Red_Value.Location = red.ConstrainLocation(newLocation);
				red.CurrentLocation = new Point(Slider_Red_Value.Location.X - Line_Red_Value.Location.X, Slider_Red_Value.Location.Y);
				Label_Red_Value.Text = "Red: " + red.CurrentValue;
				Line_Red_Value.BackColor = Color.FromArgb(red.CurrentValue, 0, 0);
				UpdateColors();
			}
		}

		private void Slider_Red_Value_MouseUp(object sender, MouseEventArgs e)
		{
			RedSliderIsMoving = false;
		}

		private void Slider_Green_Value_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				GreenSliderIsMoving = true;
				GreenSliderLastLocation = e.Location;
			}
		}

		private void Slider_Green_Value_MouseMove(object sender, MouseEventArgs e)
		{
			if (GreenSliderIsMoving)
			{
				Point newLocation = new Point(
					(Slider_Green_Value.Location.X - GreenSliderLastLocation.X) + e.X,
					Slider_Green_Value.Location.Y
				);
				Slider_Green_Value.Location = green.ConstrainLocation(newLocation);
				green.CurrentLocation = new Point(Slider_Green_Value.Location.X - Line_Green_Value.Location.X, Slider_Green_Value.Location.Y);
				Label_Green_Value.Text = "Green: " + green.CurrentValue;
				Line_Green_Value.BackColor = Color.FromArgb(0, green.CurrentValue, 0);
				UpdateColors();
			}
		}

		private void Slider_Green_Value_MouseUp(object sender, MouseEventArgs e)
		{
			GreenSliderIsMoving = false;
		}

		private void Slider_Blue_Value_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				BlueSliderIsMoving = true;
				BlueSliderLastLocation = e.Location;
			}
		}

        private void Slider_Blue_Value_MouseMove(object sender, MouseEventArgs e)
		{
			if (BlueSliderIsMoving)
			{
				Point newLocation = new Point(
					(Slider_Blue_Value.Location.X - BlueSliderLastLocation.X) + e.X,
					Slider_Blue_Value.Location.Y
				);
				Slider_Blue_Value.Location = red.ConstrainLocation(newLocation);
				blue.CurrentLocation = new Point(Slider_Blue_Value.Location.X - Line_Blue_Value.Location.X, Slider_Blue_Value.Location.Y);
				Label_Blue_Value.Text = "Blue: " + blue.CurrentValue;
				Line_Blue_Value.BackColor = Color.FromArgb(0, 0, blue.CurrentValue);
				UpdateColors();
			}
		}

		private void Slider_Blue_Value_MouseUp(object sender, MouseEventArgs e)
		{
			BlueSliderIsMoving = false;
		}

		private void UpdateColors()
        {
			if (isPrimarySelected)
			{
				primaryColor = Color.FromArgb(red.CurrentValue, green.CurrentValue, blue.CurrentValue);
			}
			else
			{
				secondaryColor = Color.FromArgb(red.CurrentValue, green.CurrentValue, blue.CurrentValue);
			}
			Btn_PrimaryColor.BackColor = primaryColor;
			Btn_SecondaryColor.BackColor = secondaryColor;
		}
	}
}
