using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DMX_MIDI
{
    public partial class ManualDMXSliderControl : UserControl
    {
        public class ValueChangedEventArgs(byte val) : EventArgs()
        {
            public byte newVal = val;
        }
        public event EventHandler<ValueChangedEventArgs> ValueChanged;
        protected virtual void OnBPMChanged(ValueChangedEventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        private int dmx_address;
        public int DMX_Address { get { return dmx_address; } set { dmx_address = value; Label_Addr.Text = $"Addr: {value}"; } }

        private byte dmx_value;
        public byte DMX_Value {
            get { return dmx_value; }
            private set {
                dmx_value = value;
                Label_Val.Text = value.ToString();
                TrackBar_Val.Value = value;
                ValueChanged.Invoke(this, new ValueChangedEventArgs(value));
            }
        }

        public ManualDMXSliderControl()
        {
            InitializeComponent();
        }

        private void TrackBar_Val_Scroll(object sender, EventArgs e)
        {
            DMX_Value = (byte)(sender as TrackBar).Value;
        }

        private void Btn_DecreaseVal_Click(object sender, EventArgs e)
        {
            if(DMX_Value > 0)
                DMX_Value -= 1;
        }

        private void Btn_IncreaseVal_Click(object sender, EventArgs e)
        {
            if (DMX_Value < 255)
            {
                DMX_Value += 1;
            }
        }
    }
}
