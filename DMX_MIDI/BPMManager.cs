using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DMX_MIDI
{
	public delegate void Beat();
	class BPMManager
	{
		public double BPM
		{
			get
			{
				if (taps.Count > 0)
					return (1/ (taps.Average()/60000));
				else
					return 0.0;
			}
		}
		public List<long> taps;
		public event Beat Beat;

		private long lastTap;
		private bool isDisposed;
		private bool needToRestart;
		public void Init()
		{
			taps = new List<long>();
			lastTap = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

			Thread t = new(() =>
			{
				long startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
				while (!isDisposed)
				{
					if (BPM > 0)
					{
						Thread.Sleep((int)((double)(1 / BPM) * 60000));
						OnBeat();
					}
					else
					{
						startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
						Thread.Sleep(10);
					}
				}
			});
			t.Priority = ThreadPriority.AboveNormal;
			t.Start();
		}

		public void Dispose()
		{
			isDisposed = true;
		}

		protected virtual void OnBeat()
		{
			Beat?.Invoke();
		}

		public void Tap()
		{
			long now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
			if ((now - lastTap) > 5000)
			{
				taps.Clear();
			}
			else
			{
				taps.Add(now - lastTap);
			}
			lastTap = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
		}

		public void Restart()
		{

		}
	}
}
