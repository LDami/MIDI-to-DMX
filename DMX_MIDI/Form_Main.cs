using MIDIOXLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
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
		private Slider freq;

		private DMXManager dmxManager = new DMXManager();
		private GUISpot[] spots;

		private OnBeatEvent defaultBeatEvent = OnBeatEvent.Flash;
		private bool nextIsSecondaryColor = false;
		private Tapper tapper;
		private int beatMultiplier = 0; // +2 = Lights triggered twice in a beat ; -2 = 2 beats for 1 light trigger
		private bool beatMultiplierButtonPressed = false;
		LeftOrRight primarySide = LeftOrRight.Left;


		private MoxScript midiScript;
		private string midiDeviceName;
		public string MidiDeviceName { get { return midiDeviceName; } set { midiDeviceName = value; Label_MidiDevice.Text = "MIDI: " + value; } }

		private string serialPortName;
		public string SerialPortName { get { return serialPortName; } set { serialPortName = value; Label_SerialStatus.Text = "Serial: " + value; } }


		//private SpectrumBeatDetector beatDetector = new(76, 48000, SensivityLevel.VERY_LOW, SensivityLevel.VERY_LOW);
		private SpectrumBeatDetector beatDetector;

		private const int MaxLTElements = 5;
		private LightTriggerControl[] ltControls;
		private int ltSelectedIndex;
		private Button ltPrevButton;
		private Button ltNextButton;
		private int ltIndex;
		private Thread fixedLightThread;

		private void Form_Main_Load(object sender, EventArgs e)
		{
			Logger.Init();
			Settings.Init();
			Settings.Updated += Settings_Updated;
			dmxManager.Init();

			MidiDeviceName = Settings.Get(Settings.SettingsList.midiPort) ?? "None";
			SerialPortName = Settings.Get(Settings.SettingsList.dmxPort) ?? "None";

			Thread checkStatus = new Thread(t =>
			{
				while(!this.IsDisposed)
				{
					Label_SerialStatus.ForeColor = dmxManager.IsReady ? Color.Green : Color.Red;
					Thread.Sleep(50);
				}
				Logger.AddLog("Fin du thread checkStatus");
			});
			checkStatus.Start();
			
			isAutoModeActive = false;

			if(isAutoModeActive)
			{
				beatDetector = new(84, 48000);
				beatDetector.Subscribe(new SpectrumBeatDetector.BeatDetectedHandler(BpmManager_Beat));
				beatDetector.StartAnalysis();
				dmxManager.ResetTimeout();
				Label_BPMInfo.Text = beatDetector.DeviceName;
			}

			timeline = new Timeline(TL_Line.Location, TL_Line.Size.Width);
			TL_Current.Location = timeline.CurrentLocation;

			red = new Slider(Slider_Red_Value, Line_Red_Value, 255, Slider.Color.R);
			green = new Slider(Slider_Green_Value, Line_Green_Value, 255, Slider.Color.G);
			blue = new Slider(Slider_Blue_Value, Line_Blue_Value, 255, Slider.Color.B);
			freq = new Slider(Slider_Freq_Filter, Line_Freq_Filter, 20000, Slider.Color.None);

			spots = new GUISpot[2];
			spots[0] = new GUISpot(
				new Spot(1, 0, new int[] { 0, 1, 2 }, LeftOrRight.Left),
				light1
			);
			Thread.Sleep(1);
			spots[1] = new GUISpot(
				new Spot(2, 6, new int[] { 0, 1, 2 }, LeftOrRight.Right),
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
						GUISpot spot = spots.First<GUISpot>(s => s.spot.Id == device.Id);
						spot.picture.BackColor = device.ColorValue;
						/*
						if(selectedDevice.spot == spot.spot)
                        {
							red.CurrentValue = spot.spot.ColorValue.R;
							green.CurrentValue = spot.spot.ColorValue.G;
							blue.CurrentValue = spot.spot.ColorValue.B;
                        }
						*/
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

			Color[] colors =
			{
				Color.White,
				Color.Firebrick,
                Color.FromArgb(255, 3, 4),
                Color.FromArgb(4, 3, 255)
            };

			ltControls = new LightTriggerControl[20];
			lightTriggers.Controls.Add(ltPrevButton);
			for (int i = 0; i < ltControls.Length; i++)
			{
				ltControls[i] = new LightTriggerControl();
				ltControls[i].LTName = $"#{i+1}";
				ltControls[i].LTType = LightTriggerType.Tap;
				ltControls[i].LTEvt = OnBeatEvent.LeftRight;
                ltControls[i].PrimaryColor = colors[i % colors.Length];
				if(i == 2)
	                ltControls[i].SecondaryColor = colors[i % colors.Length + 1];
                ltControls[i].Click += (sender, args) =>
				{
					// TODO: to fix: crash when enabled AUTO mode
					//ltSelectedIndex = i;
					//UpdateSelectedLightTriggerControl();
				};
				ltControls[i].DoubleClick += (sender, args) =>
				{
					((LightTriggerControl)sender).Edit();
				};
			}
			for (int i = 0; i < MaxLTElements; i++)
			{
				lightTriggers.Controls.Add(ltControls[i]);
			}
			lightTriggers.Controls.Add(ltNextButton);
			lightTriggers.MouseWheel += LightTriggers_MouseWheel;
			ltSelectedIndex = -1;

			fixedLightThread = null;
			tapper = new(this);
            tapper.TapEvent += Tapper_TapEvent;
            tapper.BPMChanged += Tapper_BPMChanged;

			midiScript = new MoxScript();
			midiScript.ShutdownAtEnd = 1;
			midiScript.FireMidiInput = 1;
			midiScript.MidiInput += MidiScript_MidiInput;
            midiScript.SysExInput += MidiScript_SysExInput;

            // Load default midi device and serial port


            // Chargement des appareils MIDI
            if (midiScript != null)
            {
                Logger.AddLog("Form_Main.cs - Form_Main_Load:I: Number of MIDI devices detected: " + midiScript.SysMidiInCount);
                string deviceName = midiScript.GetFirstSysMidiInDev();
                Logger.AddLog("Form_Main.cs - Form_Main_Load:I: First device detected: " + deviceName);
                Settings.Set(Settings.SettingsList.midiPort, deviceName);
            }
            else
                Logger.AddLog("Form_Main.cs - Form_Main_Load:E: MoxScript is null, MIDI devices could not be found.");

            // Chargement des ports série
            string[] ports = SerialPort.GetPortNames();
            Settings.Set(Settings.SettingsList.dmxPort, ports[0]);
        }

        private void Tapper_BPMChanged(object sender, Tapper.BPMChangedEventArgs e)
		{
			if (Label_BPM.InvokeRequired)
				Label_BPM.BeginInvoke(new Action(() => Label_BPM.Text = $"BPM: {e.newBPM}"));
			else
				Label_BPM.Text = $"BPM: {e.newBPM}";
        }

        private void Tapper_TapEvent(object sender, Tapper.TapEventArgs e)
        {
			Random rdm = new();
			Label_BPM.ForeColor = Color.FromArgb(rdm.Next(0, 255), rdm.Next(0, 255), rdm.Next(0, 255));

			// Cancel tap if the division is not used in this beatMultiplier
			if(beatMultiplier != 0)
			{
				if (beatMultiplier == 4 && e.BeatDivision % 2 != 0)
					return;
				if (beatMultiplier == 2 && !(e.BeatDivision == 1 || e.BeatDivision == 4))
					return;
			}
			else
			{
				if (e.BeatDivision != 1)
					return;
			}

			if (ltSelectedIndex != -1)
			{
				if (ltControls[ltSelectedIndex].LTType == LightTriggerType.Tap)
				{
					List<DMXDevice> devices = dmxManager.devices;
					Spot spot;
					devices.ForEach(device =>
					{
						spot = spots.First<GUISpot>(s => s.spot.Id == device.Id).spot;
						if (!spot.IsBlackedout)
						{							
							switch (ltControls[ltSelectedIndex].LTEvt)
							{
                                case OnBeatEvent.LeftRight:
                                    if (spot.Side == primarySide)
                                    {
                                        spot.ColorValue = ltControls[ltSelectedIndex].PrimaryColor;
                                    }
                                    else
                                    {
                                        spot.ColorValue = ltControls[ltSelectedIndex].SecondaryColor;
                                    }
                                    break;
								case OnBeatEvent.PulseLeftRight:
									if (spot.Side == primarySide)
									{
										spot.ColorValue = ltControls[ltSelectedIndex].PrimaryColor;
									}
									else
									{
										spot.ColorValue = ltControls[ltSelectedIndex].SecondaryColor;
									}
									spot.Pulse(100, 128, false);
									break;
                                case OnBeatEvent.PulseAll:
                                    spot.ColorValue = (spot.ColorValue != ltControls[ltSelectedIndex].PrimaryColor) ? ltControls[ltSelectedIndex].PrimaryColor : ltControls[ltSelectedIndex].SecondaryColor;

                                    spot.Pulse(100, 128, false);
                                    break;
                                case OnBeatEvent.Flash:
									spot.ColorValue = ltControls[ltSelectedIndex].PrimaryColor;
									spot.Flash(20);
									break;
								case OnBeatEvent.FlashRandomColor:
									spot.ColorValue = Color.FromArgb(rdm.Next(0, 255), rdm.Next(0, 255), rdm.Next(0, 255));
									spot.Flash();
									break;
								case OnBeatEvent.RandomColor:
									spot.GlobalIntensity = 255;
									spot.ColorValue = Color.FromArgb(rdm.Next(0, 255), rdm.Next(0, 255), rdm.Next(0, 255));
									break;
								case OnBeatEvent.Blackout:
									spot.Blackout();
									break;
							}
						}
					});
					primarySide = (primarySide == LeftOrRight.Left) ? LeftOrRight.Right : LeftOrRight.Left;
				}

			}

		}

		private void ToggleSelectLightControlTrigger(int index)
        {
            if (ltSelectedIndex == index)
                ltSelectedIndex = -1;
            else
                ltSelectedIndex = index;
            UpdateSelectedLightTriggerControl();
        }

        private void MidiScript_MidiInput(int nTimestamp, int port, int status, int data1, int data2)
		{
			Logger.AddLog($"Form_Main.cs - MidiScript_MidiInput:I: MIDI IN = {nTimestamp} - {port} - {status} - {data1} - {data2}");

			MidiDevice.MidiActionEx? midiAction = null;
			if (Settings.Get(Settings.SettingsList.midiPort) == "nanoPAD2")
			{
				midiAction = NanoPad2.GetMidiAction(Convert.ToByte(status), Convert.ToByte(data1), status == 0x90 || (status == 0xb0 && data2 == 0x7f));
			}
			Console.WriteLine("midiAction = " + midiAction.Value.Action + " (" + midiAction.Value.ParamValue + ")");
            switch (midiAction.Value.Action)
            {
				case MidiDevice.MidiAction.UpdateGlobalIntensityWithData2:
                    spots.ToList().ForEach(s => s.spot.GlobalIntensity = data2 * 2);
					break;
                case MidiDevice.MidiAction.SelectCue1:
                    ToggleSelectLightControlTrigger(0);
                    break;
                case MidiDevice.MidiAction.SelectCue2:
                    ToggleSelectLightControlTrigger(1);
                    break;
                case MidiDevice.MidiAction.SelectCue3:
                    ToggleSelectLightControlTrigger(2);
                    break;
                case MidiDevice.MidiAction.SelectCue4:
                    ToggleSelectLightControlTrigger(3);
                    break;
                case MidiDevice.MidiAction.SelectCue5:
                    ToggleSelectLightControlTrigger(4);
                    break;
                case MidiDevice.MidiAction.SelectCue6:
                    ToggleSelectLightControlTrigger(5);
                    break;
                case MidiDevice.MidiAction.SelectCue7:
                    ToggleSelectLightControlTrigger(6);
                    break;
                case MidiDevice.MidiAction.SelectCue8:
                    ToggleSelectLightControlTrigger(7);
                    break;
                case MidiDevice.MidiAction.Flash:
                    spots.ToList().ForEach(spot =>
                    {
                        spot.spot.IsFlashing = true;
                    });
                    break;
                case MidiDevice.MidiAction.StopFlash:
                    spots.ToList().ForEach(spot =>
                    {
                        spot.spot.IsFlashing = false;
                    });
                    break;
                case MidiDevice.MidiAction.Tap:
                    tapper.Tap();
					break;
                case MidiDevice.MidiAction.BeatMultiplier:
                    beatMultiplier = midiAction.Value.ParamValue; // Ne fonctionnera qu'avec 2 pas car Tapper ne divise pas par 4
                    break;
            }
		}

		private void MidiScript_SysExInput(string bStrSysEx)
		{
			Logger.AddLog($"Form_Main.cs - MidiScript_SysExInput:I: SYSEX IN = {bStrSysEx}");
			byte[] bStr = bStrSysEx.Split(' ').Where(item => item.Length > 0 && item != " ").Select(item => Convert.ToByte(item, 16)).ToArray();
			int scene = bStr[9] + 0x01;
			Logger.AddLog($"Form_Main.cs - MidiScript_SysExInput:I: Scene = {scene}");
		}

		private void UpdateSelectedLightTriggerControl()
		{
			for (int i = 0; i < ltControls.Length; i++)
				if (ltSelectedIndex != i) ltControls[i].Unselect();

			if (ltSelectedIndex >= 0 && ltSelectedIndex < ltControls.Length)
			{
				ltControls[ltSelectedIndex].Select();
				spots.ToList().ForEach(spot =>
				{
					spot.spot.IsBlackedout = false;
				});


				if (ltControls[ltSelectedIndex].LTType == LightTriggerType.Fixed)
				{
					List<DMXDevice> devices = dmxManager.devices;
					Spot spot;
					devices.ForEach(device =>
					{
						spot = spots.First<GUISpot>(s => s.spot.Id == device.Id).spot;
						spot.IsBlackedout = false;
						spot.ColorValue = ltControls[ltSelectedIndex].PrimaryColor;
						switch (ltControls[ltSelectedIndex].LTEvt)
						{
							case OnBeatEvent.PulseLeftRight:
								if (spot.Side == primarySide)
								{
									spot.ColorValue = ltControls[ltSelectedIndex].PrimaryColor;
								}
								else
								{
									spot.ColorValue = ltControls[ltSelectedIndex].SecondaryColor;
								}
								spot.Pulse(500, 0, false);
								break;
							case OnBeatEvent.PulseAll:
								spot.ColorValue = !nextIsSecondaryColor ? ltControls[ltSelectedIndex].PrimaryColor : ltControls[ltSelectedIndex].SecondaryColor;

								spot.Pulse(500, 0, false);
								break;
							case OnBeatEvent.Flash:
								spot.Flash();
								break;
							case OnBeatEvent.RandomColor:
								/* Not available */
								break;
							case OnBeatEvent.Blackout:
								spot.Blackout();
								break;
						}
					});
				}

				if (ltControls[ltSelectedIndex].LTType == LightTriggerType.Frequency)
				{
					if (fixedLightThread != null)
					{
						fixedLightThread.Abort();
						fixedLightThread = null;
					}
					LeftOrRight primarySide = LeftOrRight.Left;
					fixedLightThread = new Thread(new ThreadStart(() =>
					{
						Random rdm = new();
						int lastLTIndex = ltSelectedIndex;
						while(lastLTIndex == ltSelectedIndex && !this.IsDisposed)
						{
							List<DMXDevice> devices = dmxManager.devices;
							Spot spot;
							devices.ForEach(device =>
							{
								spot = spots.First<GUISpot>(s => s.spot.Id == device.Id).spot;
								switch (ltControls[ltSelectedIndex].LTEvt)
								{
									case OnBeatEvent.PulseLeftRight:
										if (spot.Side == primarySide)
										{
											spot.ColorValue = ltControls[ltSelectedIndex].PrimaryColor;
										}
										else
										{
											spot.ColorValue = ltControls[ltSelectedIndex].SecondaryColor;
										}
										spot.Pulse(500, 0, false);
										break;
									case OnBeatEvent.PulseAll:
										spot.ColorValue = !nextIsSecondaryColor ? ltControls[ltSelectedIndex].PrimaryColor : ltControls[ltSelectedIndex].SecondaryColor;

										spot.Pulse(500, 0, false);
										break;
									case OnBeatEvent.Flash:
										spot.Flash();
										break;
									case OnBeatEvent.RandomColor:
										spot.GlobalIntensity = 255;
										spot.ColorValue = Color.FromArgb(rdm.Next(0, 255), rdm.Next(0, 255), rdm.Next(0, 255));
										break;
									case OnBeatEvent.Blackout:
										spot.Blackout();
										break;
								}
							});

							nextIsSecondaryColor = !nextIsSecondaryColor;
							primarySide = (primarySide == LeftOrRight.Left) ? LeftOrRight.Right : LeftOrRight.Left;

							Thread.Sleep(500);
						}
					}));
					fixedLightThread.Start();
				}
			}
		}

		private void Settings_Updated(Settings.SettingsUpdatedEventArgs e)
		{
			if(e.key == Settings.SettingsList.midiPort && e.newValue.GetType() == typeof(string))
			{
				MidiDeviceName = e.newValue.ToString();
			}
			else if (e.key == Settings.SettingsList.dmxPort && e.newValue.GetType() == typeof(string))
			{
				SerialPortName = e.newValue.ToString();
			}
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
			//Label_BPM.ForeColor = Color.FromArgb(rdm.Next(0, 255), rdm.Next(0, 255), rdm.Next(0, 255));

			/*
			if(ltSelectedIndex != -1)
            {
				defaultBeatEvent = ltControls[ltSelectedIndex].LTEvt;
			}
			*/

			if(ltSelectedIndex != -1) // One LT is selected
			{
				if (ltControls[ltSelectedIndex].LTType == LightTriggerType.BeatDetection)
				{
					List<DMXDevice> devices = dmxManager.devices;
					Spot spot;
					devices.ForEach(device =>
					{
						spot = spots.First<GUISpot>(s => s.spot.Id == device.Id).spot;
						if (!spot.IsBlackedout)
						{
							if (ltSelectedIndex != -1)
							{
								spot.ColorValue = ltControls[ltSelectedIndex].PrimaryColor;
							}
							//spots.First<GUISpot>(s => s.spot.Id == device.Id).spot.ColorValue = Color.FromArgb(rdm.Next(0, 255), rdm.Next(0, 255), rdm.Next(0, 255));
							switch (defaultBeatEvent)
							{
								case OnBeatEvent.PulseLeftRight:
									spot.ColorValue = rdm.NextDouble() > 0.5 ? ltControls[ltSelectedIndex].PrimaryColor : ltControls[ltSelectedIndex].SecondaryColor;
									nextIsSecondaryColor = !nextIsSecondaryColor;
									spot.Pulse(startingIntensity: (float)beatDetector.Peak, toBlack: beatDetector.GetAverage() > 0.5);
									break;
								case OnBeatEvent.PulseAll:
									spot.ColorValue = !nextIsSecondaryColor ? ltControls[ltSelectedIndex].PrimaryColor : ltControls[ltSelectedIndex].SecondaryColor;

									spot.Pulse(startingIntensity: (float)beatDetector.Peak, toBlack: beatDetector.GetAverage() > 0.5);
									break;
								case OnBeatEvent.Flash:
									spot.Flash();
									break;
								case OnBeatEvent.RandomColor:
									spot.GlobalIntensity = 255;
									spot.ColorValue = Color.FromArgb(rdm.Next(0, 255), rdm.Next(0, 255), rdm.Next(0, 255));
									break;
								case OnBeatEvent.Blackout:
									spot.Blackout();
									break;
							}
						}
					});
					nextIsSecondaryColor = !nextIsSecondaryColor;
				}
			}


			if (Label_PeakLevel.InvokeRequired)
				Label_PeakLevel.BeginInvoke(new Action(() => Label_PeakLevel.Text = "Peak: " + beatDetector.Peak));
			else
				Label_PeakLevel.Text = "Peak: " + beatDetector.Peak;

			if (Label_AverageLevel.InvokeRequired)
				Label_AverageLevel.BeginInvoke(new Action(() => Label_AverageLevel.Text = "Average: " + beatDetector.Average));
			else
				Label_AverageLevel.Text = "Average: " + beatDetector.Average;
			
		}

		private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			midiScript.FireMidiInput = 0;
			midiScript = null;
			if(beatDetector != null)
			{
				beatDetector.StopAnalysis();
				beatDetector.Free();
			}
			dmxManager.Dispose();
		}

		private void Btn_Settings_Click(object sender, EventArgs e)
		{
			Form_Settings settings = new Form_Settings();
			settings.UseMoxScript(midiScript);
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
			if (isAutoModeActive)
				DisableAutoMode();
			else
				EnableAutoMode();
		}

		private void EnableAutoMode()
        {
			isAutoModeActive = true;
			beatDetector = new(84, 48000);
			beatDetector.Subscribe(new SpectrumBeatDetector.BeatDetectedHandler(BpmManager_Beat));
			beatDetector.StartAnalysis();

			if (Label_BPMInfo.InvokeRequired)
				Label_BPMInfo.BeginInvoke(new Action(() => Label_BPMInfo.Text = "Auto: Active"));
			else
				Label_BPMInfo.Text = "Auto: Active";

		}

		private void DisableAutoMode()
		{
			isAutoModeActive = false;
			if (beatDetector != null)
			{
				beatDetector.StopAnalysis();
				beatDetector.UnSubscribe(new SpectrumBeatDetector.BeatDetectedHandler(BpmManager_Beat));
				beatDetector.Free();
				beatDetector = null;
			}

			if (Label_BPMInfo.InvokeRequired)
				Label_BPMInfo.BeginInvoke(new Action(() => Label_BPMInfo.Text = "Auto: Inactive"));
			else
				Label_BPMInfo.Text = "Auto: Inactive";
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
		bool FreqSliderIsMoving;
		Point FreqSliderLastLocation;

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
				Slider_Green_Value.Location = green.ConstrainLocation(newLocation);
				green.CurrentLocation = new Point(Slider_Green_Value.Location.X - Line_Green_Value.Location.X, Slider_Green_Value.Location.Y);
				Label_Green_Value.Text = "Green: " + green.CurrentValue;
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

		private void Slider_Freq_Filter_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				FreqSliderIsMoving = true;
				FreqSliderLastLocation = e.Location;
			}
		}

		private void Slider_Freq_Filter_MouseMove(object sender, MouseEventArgs e)
		{
			if (FreqSliderIsMoving)
			{
				Point newLocation = new Point(
					(Slider_Freq_Filter.Location.X - FreqSliderLastLocation.X) + e.X,
					Slider_Freq_Filter.Location.Y
				);
				Slider_Freq_Filter.Location = red.ConstrainLocation(newLocation);
				freq.CurrentLocation = new Point(Slider_Freq_Filter.Location.X - Line_Freq_Filter.Location.X, Slider_Freq_Filter.Location.Y);
				Label_Freq_Filter.Text = "Frequency: " + (freq.CurrentValue * 20) + "hz";

				beatDetector.SetFrenquency(freq.CurrentValue * 20);

			}
		}

		private void Slider_Freq_Filter_MouseUp(object sender, MouseEventArgs e)
		{
			FreqSliderIsMoving = false;
		}

		private void Button_InstantToExcel_Click(object sender, EventArgs e)
		{
			beatDetector.SaveInstant();
		}
	}
}
