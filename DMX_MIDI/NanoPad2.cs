using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DMX_MIDI.MidiDevice;

namespace DMX_MIDI
{
    internal class NanoPad2 : MidiDevice
    {
        static bool isBeatMultiplierKeyDown = false;

        public static MidiActionEx GetMidiAction(byte status, byte data1, bool isDown)
        {
            if (status == 0xB0 && data1 == 0x02)
            {
                return new MidiActionEx(MidiAction.UpdateGlobalIntensityWithData2);
            }
            switch (data1)
            {
                case 0x2d:
                    return isDown ? new MidiActionEx(MidiAction.SelectCue1) : new MidiActionEx(MidiAction.Unknown);
                case 0x2f:
                    return isDown ? new MidiActionEx(MidiAction.SelectCue2) : new MidiActionEx(MidiAction.Unknown);
                case 0x31:
                    return isDown ? new MidiActionEx(MidiAction.SelectCue3) : new MidiActionEx(MidiAction.Unknown);
                case 0x33:
                    return isDown ? new MidiActionEx(MidiAction.SelectCue4) : new MidiActionEx(MidiAction.Unknown);
                case 0x3d:
                    return isDown ? new MidiActionEx(MidiAction.SelectCue5) : new MidiActionEx(MidiAction.Unknown);
                case 0x3f:
                    return isDown ? new MidiActionEx(MidiAction.SelectCue6) : new MidiActionEx(MidiAction.Unknown);
                case 0x41:
                    return isDown ? new MidiActionEx(MidiAction.SelectCue7) : new MidiActionEx(MidiAction.Unknown);
                case 0x43:
                    return isDown ? new MidiActionEx(MidiAction.SelectCue8) : new MidiActionEx(MidiAction.Unknown);
                case 0x14:
                case 0x35:
                    return isDown ? new MidiActionEx(MidiAction.Flash) : new MidiActionEx(MidiAction.StopFlash);
                case 0x2b:
                case 0x3b:
                    return isDown ? new MidiActionEx(MidiAction.Tap) : new MidiActionEx(MidiAction.Unknown);
                case 0x2a:
                case 0x3a:
                    isBeatMultiplierKeyDown = isDown;
                    return isDown ? new MidiActionEx(MidiAction.Unknown) : new MidiActionEx(MidiAction.BeatMultiplier, 0);
                case 0x2c:
                case 0x3c: // Multiplier 2
                    return isBeatMultiplierKeyDown && isDown ? new MidiActionEx(MidiAction.BeatMultiplier, 2) : new MidiActionEx(MidiAction.BeatMultiplier, 0);
                case 0x2e:
                case 0x3e: // Multiplier 4
                    return isBeatMultiplierKeyDown && isDown ? new MidiActionEx(MidiAction.BeatMultiplier, 4) : new MidiActionEx(MidiAction.BeatMultiplier, 0);
                case 0x30:
                case 0x40: // Multiplier 8
                    return isBeatMultiplierKeyDown && isDown ? new MidiActionEx(MidiAction.BeatMultiplier, 8) : new MidiActionEx(MidiAction.BeatMultiplier, 0);
                default:
                    return new MidiActionEx(MidiAction.Unknown);
            }
        }
    }
}
