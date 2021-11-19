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

		private void Form_Settings_Load(object sender, EventArgs e)
		{
			// Chargement des appareils MIDI
			MoxScript midiScript = new MoxScript();
			Console.WriteLine("Number of MIDI devices detected: " + midiScript.SysMidiInCount);
			string deviceName = midiScript.GetFirstSysMidiInDev();
			Console.WriteLine("First device detected: " + deviceName);
			List_MIDIIn.Items.Clear();
			while (deviceName != "")
			{
				Console.WriteLine("New device detected: " + deviceName);
				List_MIDIIn.Items.Add(deviceName);
				deviceName = midiScript.GetNextSysMidiInDev();
			}

			// Chargement des ports série
			string[] ports = SerialPort.GetPortNames();
			List_Serial.Items.Clear();
			foreach (string port in ports)
			{
				Console.WriteLine("New Serial Port detected: " + port);
				List_Serial.Items.Add(port);
			}
		}

		private void Btn_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void List_MIDIIn_DropDownClosed(object sender, EventArgs e)
		{
			Settings.SettingsList settings = Settings.GetSettings;
			settings.midiPort = List_MIDIIn.Text;
			Settings.Set(settings);
		}

		private void List_Serial_DropDownClosed(object sender, EventArgs e)
		{
			Settings.SettingsList settings = Settings.GetSettings;
			settings.dmxPort = List_Serial.Text;
			Settings.Set(settings);
		}
	}
}
