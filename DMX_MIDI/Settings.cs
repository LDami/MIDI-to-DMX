using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMX_MIDI
{
	public class Settings
	{
		public class SettingsUpdatedEventArgs
		{
			public SettingsList key;
			public string newValue;
		}
		public delegate void SettingsUpdatedEventHandler(SettingsUpdatedEventArgs e);
		public static event SettingsUpdatedEventHandler Updated;

		public enum SettingsList
		{
			midiPort,
			dmxPort
		}

		private static Dictionary<SettingsList, string> localSettings;

		public static void Init()
		{
			localSettings = new Dictionary<SettingsList, string>();
			//TODO: load
		}

		public static string Get(SettingsList key)
		{
			if (localSettings != null)
			{
				if (localSettings.ContainsKey(key))
					return localSettings[key];
				else return null;

			}
			else
				throw new Exception("Settings.Get has been called before Settings.Init !");
		}
		public static void Set(SettingsList key, string value)
		{
			if (localSettings != null)
			{
				if (localSettings.ContainsKey(key))
					localSettings[key] = value;
				else
					localSettings.Add(key, value);
				Updated?.Invoke(new SettingsUpdatedEventArgs() { key = key, newValue = value });
			}
			else
				throw new Exception("Settings.Get has been called before Settings.Init !");
		}

	}
}
