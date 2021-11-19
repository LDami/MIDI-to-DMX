using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMX_MIDI
{
	public class Settings
	{
		public struct SettingsList
		{
			public string midiPort;
			public string dmxPort;
		}

		private static SettingsList localSettings = new SettingsList();
		public static SettingsList GetSettings
		{
			get => localSettings;
		}

		public static void Set(SettingsList newlist)
		{
			localSettings = newlist;
		}
	}
}
