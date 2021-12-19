using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DMX_MIDI
{
	public class Spot : DMXDevice
	{
		public int Id { get; set; }
		public int StartChannel { get; set; }
		public int[] ColorChannels { get; set; }
		public Color ColorValue { get; set; }
		public float GlobalIntensity { get; set; }
		public bool IsFlashing { get; set; }
		
		private Thread FlashThread;

		public Spot(int id, int startChannel, int[] colorChannels)
		{
			this.Id = id;
			this.StartChannel = startChannel;
			this.ColorChannels = colorChannels.Length == 3 ? colorChannels : new int[3];
			Random rdm = new Random();
			this.ColorValue = Color.FromArgb(rdm.Next(255), rdm.Next(255), rdm.Next(255));
			this.GlobalIntensity = 0;
			this.IsFlashing = false;
		}

		public void Flash(int duration = 500)
		{
			this.GlobalIntensity = 255;
			if (FlashThread == null || !FlashThread.IsAlive)
			{
				FlashThread = new Thread(() =>
				{
					int t = duration;
					int step = 1; //1ms
					while (t > 0)
					{
						this.GlobalIntensity -= (float)((float)255 / (float)duration);
						Thread.Sleep(step);
						t -= step;
					}
				});
				FlashThread.Name = "Device Flash Thread";
				FlashThread.Priority = ThreadPriority.Highest;
				FlashThread.Start();
			}
		}
	}
}
