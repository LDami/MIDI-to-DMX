using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMX_MIDI
{
    public partial class Form_ManualDMX : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private DMXManager dmxManager;

        public Form_ManualDMX(DMXManager _dmxManager)
        {
            InitializeComponent();

            dmxManager = _dmxManager;
            dmxManager.SetManualMode(true);

            tableLayoutPanel1.ColumnCount = 16;
            for(int i = 1; i <= 16; i ++)
            {
                ManualDMXSliderControl ctrl = new()
                {
                    DMX_Address = i
                };
                ctrl.ValueChanged += DMXSlider_ValueChanged;
                tableLayoutPanel1.Controls.Add(ctrl);
            }
        }

        private void DMXSlider_ValueChanged(object sender, ManualDMXSliderControl.ValueChangedEventArgs e)
        {
            dmxManager.manualChannels[(sender as ManualDMXSliderControl).DMX_Address - 1] = e.newVal;
        }

        private void Form_ManualDMX_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void Form_ManualDMX_FormClosing(object sender, FormClosingEventArgs e)
        {
            dmxManager.SetManualMode(false);
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
