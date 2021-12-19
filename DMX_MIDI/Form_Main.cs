using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMX_MIDI
{
	public struct GUISpot
	{
		public Spot spot;
		public PictureBox picture;
		public GUISpot(Spot _spot, PictureBox _picture)
		{
			spot = _spot;
			picture = _picture;
		}
	}
	public partial class Form_Main : Form
	{
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		public Form_Main()
		{
			InitializeComponent();
		}

		private void Form_Main_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		readonly Color DEVICE_SELECTED_COLOR = Color.Gray;

		private bool TL_Current_IsMouseDown;
		private Point TL_Current_LastLocation;
		private Timeline timeline;

		private bool isAutoModeActive;

		private GUISpot selectedDevice;

		private Slider red, green, blue;

		private DMXManager dmxManager = new DMXManager();
		private GUISpot[] spots;

		//private SpectrumBeatDetector beatDetector = new(76, 48000, SensivityLevel.VERY_LOW, SensivityLevel.VERY_LOW);
		private SpectrumBeatDetector beatDetector;

		private const int MaxLTElements = 5;
		private LightTriggerControl[] ltControls;
		private Button ltPrevButton;
		private Button ltNextButton;
		private int ltIndex;

		private void Form_Main_Load(object sender, EventArgs e)
		{
			Logger.Init();
			dmxManager.Init();
			Thread checkStatus = new Thread(t =>
			{
				while(!this.IsDisposed)
				{
					Label_SerialStatus.ForeColor = dmxManager.IsReady ? Color.Green : Color.Red;
					if(Label_BPMInfo.InvokeRequired)
					{
						Label_BPMInfo.BeginInvoke((MethodInvoker) delegate() { Label_BPMInfo.Text = dmxManager.averageSpeed + "/s";  });
					}
					else
						Label_BPMInfo.Text = dmxManager.averageSpeed + "/s";
					Thread.Sleep(50);
				}
				Logger.AddLog("Fin du thread checkStatus");
			});
			checkStatus.Start();
			
			isAutoModeActive = true;

			if(isAutoModeActive)
			{
				beatDetector = new(85, 48000, SensivityLevel.VERY_LOW, SensivityLevel.VERY_LOW);
				beatDetector.Subscribe(new SpectrumBeatDetector.BeatDetectedHandler(BpmManager_Beat));
				beatDetector.StartAnalysis();
				dmxManager.ResetTimeout();
			}
			//Label_BPMInfo.Text = beatDetector.DeviceName;

			timeline = new Timeline(TL_Line.Location, TL_Line.Size.Width);
			TL_Current.Location = timeline.CurrentLocation;

			red = new Slider(Slider.Color.R, Slider_Red_Value, Line_Red_Value);
			green = new Slider(Slider.Color.G, Slider_Green_Value, Line_Green_Value);
			blue = new Slider(Slider.Color.B, Slider_Blue_Value, Line_Blue_Value);

			spots = new GUISpot[2];
			spots[0] = new GUISpot(
				new Spot(1, 0, new int[] { 0, 1, 2 }),
				light1
			);
			Thread.Sleep(1);
			spots[1] = new GUISpot(
				new Spot(2, 6, new int[] { 0, 1, 2 }),
				light2
			);
			dmxManager.devices.Add(spots[0].spot);
			dmxManager.devices.Add(spots[1].spot);
			
			Thread getLightColors = new Thread(t =>
			{
				while (!this.IsDisposed)
				{
					List<DMXDevice> devices = dmxManager.devices;
					devices.ForEach(device =>
					{
						spots.First<GUISpot>(s => s.spot.Id == device.Id).picture.BackColor = device.ColorValue;
					});
					Thread.Sleep(50);
				}
			});
			getLightColors.Start();
			lightTriggers.ColumnCount = 7;

			/* Building light trigger controllers */

			ltPrevButton = new Button();
			ltPrevButton.Size = new Size(50, lightTriggers.Size.Height);
			ltPrevButton.Text = "<";
			ltPrevButton.Click += LTPrevButton_Click;
			ltNextButton = new Button();
			ltNextButton.Text = ">";
			ltNextButton.Size = new Size(50, lightTriggers.Size.Height);
			ltNextButton.Click += LTNextButton_Click;

			ltIndex = 0;

			ltControls = new LightTriggerControl[20];
			lightTriggers.Controls.Add(ltPrevButton);
			for (int i = 0; i < ltControls.Length; i++)
			{
				ltControls[i] = new LightTriggerControl();
				ltControls[i].LTName = $"#{i}";
			}
			for (int i = 0; i < MaxLTElements; i++)
			{
				lightTriggers.Controls.Add(ltControls[i]);
			}
			lightTriggers.Controls.Add(ltNextButton);
			lightTriggers.MouseWheel += LightTriggers_MouseWheel;
		}

		private void LightTriggerControl_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < ltControls.Length; i++)
				ltControls[i].Unselect();

			((LightTriggerControl)sender).Select();
		}

		private void LightTriggers_MouseWheel(object sender, MouseEventArgs e)
		{
			if(e.Delta > 0 && ltIndex > 0)
				ltIndex--;
			else if(e.Delta < 0 && ltIndex < ltControls.Length)
				ltIndex++;

			UpdateLightTriggerControl();
		}

		private void LTPrevButton_Click(object sender, EventArgs e)
		{
			if(ltIndex > 0)
			{
				ltIndex--;

				UpdateLightTriggerControl();
			}
		}

		private void LTNextButton_Click(object sender, EventArgs e)
		{
			if (ltIndex < ltControls.Length)
			{
				ltIndex++;

				UpdateLightTriggerControl();
			}
		}

		public void UpdateLightTriggerControl()
		{
			lightTriggers.Controls.Clear();
			lightTriggers.Controls.Add(ltPrevButton);
			for (int i = ltIndex; i < (MaxLTElements + ltIndex); i++)
			{
				if (i >= ltControls.Length)
					break;
				lightTriggers.Controls.Add(ltControls[i]);
			}
			lightTriggers.Controls.Add(ltNextButton);
		}

		public void UpdateBPMInfo(string txt)
		{
			Label_BPMInfo.Text = txt;
		}

		private void BpmManager_Beat(byte value)
		{
			//Logger.AddLog("beat: " + value);
			Random rdm = new();
			Label_BPM.ForeColor = Color.FromArgb(rdm.Next(0, 255), rdm.Next(0, 255), rdm.Next(0, 255));
			
			List<DMXDevice> devices = dmxManager.devices;
			devices.ForEach(device =>
			{
				//spots.First<GUISpot>(s => s.spot.Id == device.Id).spot.ColorValue = Color.FromArgb(rdm.Next(0, 255), rdm.Next(0, 255), rdm.Next(0, 255));
				spots.First<GUISpot>(s => s.spot.Id == device.Id).spot.Flash();
			});
			
		}

		private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			beatDetector.StopAnalysis();
			beatDetector.Free();
			dmxManager.Dispose();
		}

		private void Btn_Settings_Click(object sender, EventArgs e)
		{
			Form settings = new Form_Settings();
			settings.Show();
			settings.Disposed += Settings_Disposed;
			this.Opacity = 0.75;
		}

		private void Settings_Disposed(object sender, EventArgs e)
		{
			this.Opacity = 1;
		}

		private void Btn_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void light1_Click(object sender, EventArgs e)
		{
			LightClicked(sender);
		}
		private void light2_Click(object sender, EventArgs e)
		{
			LightClicked(sender);
		}

		private void LightClicked(object sender)
		{
			SelectDevice(spots.First<GUISpot>(s => s.spot.Id == Convert.ToInt32((sender as PictureBox).Tag)));
			/*
			ColorDialog dialog = new ColorDialog();
			dialog.ShowDialog();
			spots.First<GUISpot>(s => s.spot.Id == Convert.ToInt32((sender as PictureBox).Tag)).spot.ColorValue = dialog.Color;
			*/
		}

		private void SelectDevice(GUISpot device)
		{
			selectedDevice = device;
			device.picture.BackColor = DEVICE_SELECTED_COLOR;

			red.CurrentValue = device.spot.ColorValue.R;
			green.CurrentValue = device.spot.ColorValue.G;
			blue.CurrentValue = device.spot.ColorValue.B;
		}

		private void Label_BPM_Click(object sender, EventArgs e)
		{
			/*
			bpmManager.Tap();
			Label_BPM.Text = "BPM: " + bpmManager.BPM;
			*/
		}

		private void Label_SerialStatus_Click(object sender, EventArgs e)
		{
			dmxManager.Init();
		}

		private void Btn_Play_Click(object sender, EventArgs e)
		{

		}

		private void Btn_Flash_MouseDown(object sender, MouseEventArgs e)
		{
			//spots.First<GUISpot>(s => s.spot.Id == Convert.ToInt32((sender as Button).Tag)).spot.IsFlashing = true;
			spots.ToList().ForEach(spot =>
			{
				spot.spot.IsFlashing = true;
			});
		}

		private void Btn_Flash_MouseUp(object sender, MouseEventArgs e)
		{
			//spots.First<GUISpot>(s => s.spot.Id == Convert.ToInt32((sender as Button).Tag)).spot.IsFlashing = false;
			spots.ToList().ForEach(spot =>
			{
				spot.spot.IsFlashing = false;
			});
		}

		private void Button_Auto_Click(object sender, EventArgs e)
		{
			isAutoModeActive = !isAutoModeActive;
			if (isAutoModeActive)
			{
				beatDetector = new(85, 48000, SensivityLevel.NORMAL, SensivityLevel.NORMAL);
				beatDetector.Subscribe(new SpectrumBeatDetector.BeatDetectedHandler(BpmManager_Beat));
				beatDetector.StartAnalysis();
				Label_BPMInfo.Text = "Auto: Active";
			}
			else
			{
				if(beatDetector != null)
				{
					beatDetector.StopAnalysis();
					beatDetector.UnSubscribe(new SpectrumBeatDetector.BeatDetectedHandler(BpmManager_Beat));
					beatDetector.Free();
					beatDetector = null;
				}
				Label_BPMInfo.Text = "Auto: Inactive";
				//dmxManager.Reconnect();
			}
			//dmxManager.ResetTimeout();
		}

		private void TL_Current_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				TL_Current_IsMouseDown = true;
				TL_Current_LastLocation = e.Location;
			}
		}

		private void TL_Current_MouseMove(object sender, MouseEventArgs e)
		{
			if(TL_Current_IsMouseDown)
			{
				Point newLocation = new Point(
					(TL_Current.Location.X - TL_Current_LastLocation.X) + e.X,
					TL_Current.Location.Y
				);
				TL_Current.Location = timeline.ConstrainCurrentFrame(newLocation);
				timeline.CurrentLocation = TL_Current.Location;
				Label_CurrentFrame.Text = "Frame: " + timeline.CurrentFrame + "/" + timeline.Frames.Length;
			}
		}

		private void TL_Current_MouseUp(object sender, MouseEventArgs e)
		{
			TL_Current_IsMouseDown = false;
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
				if(selectedDevice.spot != null)
				{
					Color newColor = Color.FromArgb(red.CurrentValue, selectedDevice.spot.ColorValue.G, selectedDevice.spot.ColorValue.B);
					selectedDevice.spot.ColorValue = newColor;
				}
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
				Slider_Green_Value.Location = red.ConstrainLocation(newLocation);
				green.CurrentLocation = new Point(Slider_Green_Value.Location.X - Line_Green_Value.Location.X, Slider_Green_Value.Location.Y);
				Label_Green_Value.Text = "Green: " + red.CurrentValue;
				Line_Green_Value.BackColor = Color.FromArgb(0, green.CurrentValue, 0);
				if (selectedDevice.spot != null)
				{
					Color newColor = Color.FromArgb(selectedDevice.spot.ColorValue.R, green.CurrentValue, selectedDevice.spot.ColorValue.B);
					selectedDevice.spot.ColorValue = newColor;
				}
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
				if (selectedDevice.spot != null)
				{
					Color newColor = Color.FromArgb(selectedDevice.spot.ColorValue.R, selectedDevice.spot.ColorValue.G, blue.CurrentValue);
					selectedDevice.spot.ColorValue = newColor;
				}
			}
		}

		private void Slider_Blue_Value_MouseUp(object sender, MouseEventArgs e)
		{
			BlueSliderIsMoving = false;
		}
	}
}
