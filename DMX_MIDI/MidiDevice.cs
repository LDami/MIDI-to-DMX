using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMX_MIDI
{
    internal class MidiDevice
    {
        // Events
        public delegate void MidiInputHandler(MidiAction Value);
        private event MidiInputHandler OnMidiInput;

        public enum MidiAction
        {
            Unknown = -1,
            SelectCue1,
            SelectCue2,
            SelectCue3,
            SelectCue4,
            SelectCue5,
            SelectCue6,
            SelectCue7,
            SelectCue8,
            Flash,
            StopFlash,
            Tap,
            BeatMultiplier,
            UpdateGlobalIntensityWithData2
        }
        public struct MidiActionEx
        {
            public MidiAction Action;
            public int ParamValue;
            public MidiActionEx(MidiAction action, int pval)
            {
                Action = action;
                ParamValue = pval;
            }
            public MidiActionEx(MidiAction action): this(action, 0) { }
        }
    }
}
