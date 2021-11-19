using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMX_MIDI
{
	public class Spot : DMXDevice
	{
		public int Id { get; set; }
		public int StartChannel { get; set; }
		public int[] ColorChannels { get; set; }
		public Color ColorValue { get; set; }
		public bool IsFlashing { get; set; }

		public Spot(int id, int startChannel, int[] colorChannels)
		{
			this.Id = id;
			this.StartChannel = startChannel;
			this.ColorChannels = colorChannels.Length == 3 ? colorChannels : new int[3];
			Random rdm = new Random();
			this.ColorValue = Color.FromArgb(rdm.Next(255), rdm.Next(255), rdm.Next(255));
			this.IsFlashing = false;
		}
	}
}
