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
		public int Timeout { get; set; } = 10000; // Timeout in ms

		private SerialPort sp;
		private byte[] channels;
		public List<DMXDevice> devices;
		private bool isBlinkOn; // Indicates if the light is ON on flashing

		private Thread HandshakeThread;
		private Action HandshakeFunc;
		public void Init()
		{
			IsReady = false;
			devices = new List<DMXDevice>();
			HandshakeFunc = () =>
			{
				Console.WriteLine("DMXManager.cs - Init:I: HandshakeThread started");
				int duration = 0;
				sp = new SerialPort(Settings.GetSettings.dmxPort ?? "COM3", 250000, Parity.None, 8, StopBits.Two);
				while (!sp.IsOpen && duration < Timeout)
				{
					try
					{
						sp.Open();
						IsReady = true;
						Console.WriteLine("DMXManager.cs - Init:I: Serial port opened: " + sp.PortName);
					}
					catch (Exception e)
					{
						Console.WriteLine("DMXManager.cs - Init:E: Serial open failed: ");
						Console.WriteLine(e.Message);
					}
					duration += 1000;
					Thread.Sleep(1000);
				}

				if (sp.IsOpen)
				{
					channels = new byte[512];
					ContinuousSend();
				}
				Console.WriteLine("DMXManager.cs - Init:I: HandshakeThread finished");
			};
			HandshakeThread = new Thread(() => HandshakeFunc());
			HandshakeThread.Start();
		}

		public void Dispose()
		{
			if (HandshakeThread != null && HandshakeThread.IsAlive)
			{
				HandshakeThread.Abort();
				Console.WriteLine("DMXManager.cs - Dispose:I: HandshakeThread finished");
			}
			Console.WriteLine("DMXManager.cs - Dispose:I: Serial port has been closed");
			sp.Close();
			sp.Dispose();
		}

		public void Reconnect()
		{
			Console.WriteLine("DMXManager.cs - Reconnect:I: Reconnect requested");
			if (sp != null && sp.IsOpen)
			{
				sp.Close();
				Thread.Sleep(1000);
			}
			HandshakeThread = new Thread(() => HandshakeFunc());
			HandshakeThread.Start();
		}

		public void ContinuousSend()
		{
			Thread t = new Thread(ts =>
			{
				Console.WriteLine("DMXManager.cs - ContinuousSend:I: Continuous Send thread started");
				try
				{
					byte[] zero = new byte[] { 0x00 };
					while (sp.IsOpen)
					{
						isBlinkOn = !isBlinkOn;
						devices.ForEach(device =>
						{
							if(device.IsFlashing)
							{
								channels[device.StartChannel + device.ColorChannels[0]] = isBlinkOn ? device.ColorValue.R : new byte();
								channels[device.StartChannel + device.ColorChannels[1]] = isBlinkOn ? device.ColorValue.G : new byte();
								channels[device.StartChannel + device.ColorChannels[2]] = isBlinkOn ? device.ColorValue.B : new byte();
							}
							else
							{
								channels[device.StartChannel + device.ColorChannels[0]] = device.ColorValue.R;
								channels[device.StartChannel + device.ColorChannels[1]] = device.ColorValue.G;
								channels[device.StartChannel + device.ColorChannels[2]] = device.ColorValue.B;
							}
						});

						sp.BreakState = true;
						Thread.Sleep(1);
						sp.BreakState = false;

						sp.Write(zero, 0, zero.Length);
						sp.BaudRate = 250000;
						sp.Write(channels, 0, channels.Length);
						sp.DiscardOutBuffer();
					}
				}
				catch(Exception e)
				{
					Console.WriteLine("DMXManager.cs - ContinuousSend:E: Serial port has been closed during writting data");
				}
				Console.WriteLine("DMXManager.cs - ContinuousSend:I: Continuous Send thread finished");
			});
			t.Start();
		}
	}
}
