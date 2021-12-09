using ManagedBass;
using System;


namespace DMX_MIDI
{
    public sealed class BeatDetectorInitOnly
    {
        public BeatDetectorInitOnly(int SamplingRate = 44100)
        {
            // Initialize BASS
            bool result = Bass.Init(0, SamplingRate, DeviceInitFlags.Stereo);

            if (!result)
            {
                throw new BassException(Bass.LastError);
            }
            else
                Console.WriteLine("Bass.Init done");
        }

        public void Free()
		{
            Bass.Free();
		}

    }
}