using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace DMX_MIDI
{
	public class DMXManager
	{
		public bool IsReady { get; private set; }
		public int Timeout { get; set; } = 20000; // Timeout in ms

		private SerialPort sp;
		private byte[] channels;
		public List<DMXDevice> devices;
		private bool isBlinkOn; // Indicates if the light is ON on flashing

		public byte[] manualChannels;
		private bool isManualModeEnabled = false;

		private Thread HandshakeThread;
		private Action HandshakeFunc;
		public void Init()
		{
			Logger.AddLog("DMXManager.cs - Init called");
			IsReady = false;
			devices = new List<DMXDevice>();
			HandshakeFunc = () =>
			{
				Logger.AddLog("DMXManager.cs - Init:I: HandshakeThread started");
				int duration = 0;
				sp = new SerialPort(Settings.Get(Settings.SettingsList.dmxPort) ?? "COM3", 250000, Parity.None, 8, StopBits.Two);
				while (!sp.IsOpen && duration < Timeout)
				{
					try
					{
						sp.Open();
						IsReady = true;
						Logger.AddLog("DMXManager.cs - Init:I: Serial port opened: " + sp.PortName);
					}
					catch (Exception e)
					{
						Logger.AddLog("DMXManager.cs - Init:E: Serial open failed: ");
						Logger.AddLog(e.Message);
					}
					duration += 1000;
					Thread.Sleep(1000);
				}

				if (sp.IsOpen)
                {
                    channels = new byte[512];
                    manualChannels = new byte[512];
                    ContinuousSend();
				}
				Logger.AddLog("DMXManager.cs - Init:I: HandshakeThread finished");
			};
			HandshakeThread = new Thread(() => HandshakeFunc());
			HandshakeThread.Name = "HandshakeThread";
			HandshakeThread.Start();
		}

		public void Dispose()
		{
			if (HandshakeThread != null && HandshakeThread.IsAlive)
			{
				HandshakeThread.Abort();
				Logger.AddLog("DMXManager.cs - Dispose:I: HandshakeThread finished");
			}
			Logger.AddLog("DMXManager.cs - Dispose:I: Serial port has been closed");
			sp.Close();
			sp.Dispose();
		}

		public void Reconnect()
		{
			Logger.AddLog("DMXManager.cs - Reconnect:I: Reconnect requested");
			if (sp != null && sp.IsOpen)
			{
				sp.Close();
				Thread.Sleep(1000);
			}
			HandshakeThread = new Thread(() => HandshakeFunc());
			HandshakeThread.Start();
		}

		public void ResetTimeout()
		{
			if(sp != null && sp.IsOpen)
				sp.ReadTimeout = -1;
		}

		public double averageSpeed;
		public long nbrOfCall;
		public DateTime lastCalcul;
		public void ContinuousSend()
		{
			averageSpeed = 0;
			nbrOfCall = 0;
			lastCalcul = DateTime.Now;
			Thread t = new(delegate()
			{
				Logger.AddLog("DMXManager.cs - ContinuousSend:I: Continuous Send thread started");
				try
				{
					byte[] zero = [0x00];
					while (sp.IsOpen)
					{
						isBlinkOn = !isBlinkOn;
						
						devices.ForEach(device =>
						{
							byte r, g, b;
							r = (byte)(device.ColorValue.R * (device.GlobalIntensity / 255));
							//Console.WriteLine($"ColorValue.R = {device.ColorValue.R}");
							//Console.WriteLine($"GlobalIntensity = {device.GlobalIntensity}");
							g = (byte)(device.ColorValue.G * (device.GlobalIntensity / 255));
							b = (byte)(device.ColorValue.B * (device.GlobalIntensity / 255));
							if (device.IsFlashing)
							{
								channels[device.StartChannel + device.ColorChannels[0]] = isBlinkOn ? r : new byte();
								channels[device.StartChannel + device.ColorChannels[1]] = isBlinkOn ? g : new byte();
								channels[device.StartChannel + device.ColorChannels[2]] = isBlinkOn ? b : new byte();
							}
							else
							{
								channels[device.StartChannel + device.ColorChannels[0]] = r;
								channels[device.StartChannel + device.ColorChannels[1]] = g;
								channels[device.StartChannel + device.ColorChannels[2]] = b;
							}
						});

						sp.BreakState = true;
						Thread.Sleep(1);
						sp.BreakState = false;

						sp.Write(zero, 0, zero.Length);
						sp.BaudRate = 250000;
						/*
						for (int i = 0; i < 12; i++)
							Console.WriteLine($"channels[{i}] = {channels[i]}");
						*/
						if(isManualModeEnabled)
							sp.Write(manualChannels, 0, manualChannels.Length);
						else
							sp.Write(channels, 0, channels.Length);

						sp.DiscardOutBuffer();
						Thread.Sleep(9);
						nbrOfCall++;
						if(DateTime.Compare(lastCalcul.AddMilliseconds(1000), DateTime.Now) < 1)
						{
							averageSpeed = nbrOfCall;
							nbrOfCall = 0;
							lastCalcul = DateTime.Now;
						}
					}
				}
				catch(Exception e)
				{
					Logger.AddLog("DMXManager.cs - ContinuousSend:E: Exception = " + e.Message);
				}
				Logger.AddLog("DMXManager.cs - ContinuousSend:I: Continuous Send thread finished");
			});
			t.Priority = ThreadPriority.Highest;
			t.Start();
		}

		public void SetManualMode(bool mode)
		{
			isManualModeEnabled = mode;

        }
	}
}
