using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DMX_MIDI
{
	public enum LeftOrRight
    {
		Left, Right
    }
	public class Spot : DMXDevice
	{
		public int Id { get; set; }
		public int StartChannel { get; set; }
		public int[] ColorChannels { get; set; }
		public Color ColorValue { get; set; }
		public float GlobalIntensity { get; set; }
		public bool IsFlashing { get; set; }
		public bool IsBlackedout { get; set; }
		public LeftOrRight Side { get; set; }
		
		private Thread FlashThread;
		private Thread BlackoutThread;

		private static bool isPulseThreadRunning;
		private static bool isPulseThreadMustStop;

		public Spot(int id, int startChannel, int[] colorChannels, LeftOrRight side)
		{
			this.Id = id;
			this.StartChannel = startChannel;
			this.ColorChannels = colorChannels.Length == 3 ? colorChannels : new int[3];
			Random rdm = new Random();
			this.ColorValue = Color.White;
			this.GlobalIntensity = 128;
			this.IsFlashing = false;
			this.Side = side;
			isPulseThreadRunning = false;
		}

		public void Pulse(int duration = 500, float startingIntensity = 255, bool toBlack = false)
		{
			Thread PulseThread;
			const float minIntensity = 25;
			this.GlobalIntensity = startingIntensity;

			isPulseThreadMustStop = true;

			PulseThread = new Thread(() =>
			{
				isPulseThreadMustStop = false;
				int t = duration;
				int step = 1; //1ms
				while (t > 0 && !isPulseThreadMustStop)
				{
					this.GlobalIntensity -= (float)(startingIntensity / (float)duration);
					if (!toBlack && this.GlobalIntensity <= minIntensity)
						this.GlobalIntensity = minIntensity;
					Thread.Sleep(step);
					t -= step;
				}
			});
			PulseThread.Name = "Device Pulse Thread";
			PulseThread.Priority = ThreadPriority.Highest;
			PulseThread.Start();
		}

		public void Flash(int duration = 100)
        {
			if (FlashThread == null || !FlashThread.IsAlive)
			{
				this.GlobalIntensity = 255;
				FlashThread = new Thread(() =>
				{
					int t = duration;
					int step = 1; //1ms
					while (t > 0)
					{
						Thread.Sleep(step);
						t -= step;
					}
					this.GlobalIntensity = 0;
				});
				FlashThread.Name = "Device Flash Thread";
				FlashThread.Priority = ThreadPriority.Highest;
				FlashThread.Start();
			}
		}

		public void Blackout(int duration = 500)
		{
			this.IsBlackedout = true;
			this.GlobalIntensity = 255;
			if (BlackoutThread == null || !BlackoutThread.IsAlive)
			{
				BlackoutThread = new Thread(() =>
				{
					int t = duration;
					int step = 1; //1ms
					while (t > 0 && this.IsBlackedout)
					{
						this.GlobalIntensity -= (float)((float)255 / (float)duration);
						Thread.Sleep(step);
						t -= step;
					}
				});
				BlackoutThread.Name = "Device Blackout Thread";
				BlackoutThread.Priority = ThreadPriority.Highest;
				BlackoutThread.Start();
			}
		}
	}
}
