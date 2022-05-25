using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMX_MIDI
{
	public enum OnBeatEvent
	{
		None = 0,
		PulseLeftRight,
		PulseAll,
		Flash,
		FlashRandomColor,
		RandomColor,
		Blackout,
	}
}
