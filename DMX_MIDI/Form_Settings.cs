using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MIDIOXLib;

namespace DMX_MIDI
{
	public partial class Form_Settings : Form
	{
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		public Form_Settings()
		{
			InitializeComponent();
		}

		private void Form_Settings_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		private MoxScript midiScript;
		public void UseMoxScript(MoxScript script)
		{
			if(script != null)
			{
				midiScript = script;
			}
		}

		private void Form_Settings_Load(object sender, EventArgs e)
		{
			// Chargement des appareils MIDI
			if (midiScript != null)
			{
				Logger.AddLog("Form_Settings.cs - Form_Settings_Load:I: Number of MIDI devices detected: " + midiScript.SysMidiInCount);
				string deviceName = midiScript.GetFirstSysMidiInDev();
				Logger.AddLog("Form_Settings.cs - Form_Settings_Load:I: First device detected: " + deviceName);
				List_MIDIIn.Items.Clear();
				string currentMidiDevice = Settings.Get(Settings.SettingsList.midiPort);
				while (deviceName != "")
				{
					Logger.AddLog("Form_Settings.cs - Form_Settings_Load:I: New device detected: " + deviceName);
					List_MIDIIn.Items.Add(deviceName);
					deviceName = midiScript.GetNextSysMidiInDev();
				}
				List_MIDIIn.SelectedItem = currentMidiDevice;
			}
			else
				Logger.AddLog("Form_Settings.cs - Form_Settings_Load:E: MoxScript is null, MIDI devices could not be found.");

			// Chargement des ports série
			string[] ports = SerialPort.GetPortNames();
			List_Serial.Items.Clear();
			string currentSerialPort = Settings.Get(Settings.SettingsList.dmxPort);
			foreach (string port in ports)
			{
				Logger.AddLog("Form_Settings.cs - Form_Settings_Load:I: New Serial Port detected: " + port);
				List_Serial.Items.Add(port);
			}
			List_Serial.SelectedItem = currentSerialPort;
		}

		private void Btn_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void List_MIDIIn_DropDownClosed(object sender, EventArgs e)
		{
			if(!(List_MIDIIn.SelectedItem is null))
				Settings.Set(Settings.SettingsList.midiPort, List_MIDIIn.SelectedItem.ToString());
		}

		private void List_Serial_DropDownClosed(object sender, EventArgs e)
		{
			if (!(List_Serial.SelectedItem is null))
				Settings.Set(Settings.SettingsList.dmxPort, List_Serial.SelectedItem.ToString());
		}
	}
}
