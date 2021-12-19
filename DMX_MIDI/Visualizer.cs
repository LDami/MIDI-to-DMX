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
	public partial class Form_Visualizer : Form
	{
		public Form_Visualizer()
		{
			InitializeComponent();
		}

		public enum ProgressBarLevel
		{
			Low,
			Medium,
			High
		}

		public void UpdateProgressBarBass(ProgressBarLevel bar, int value)
		{
			//Logger.AddLog("Visualizer.cs - UpdateProgressBarBass:W: value = " + value);
			if (value > 100)
			{
				//Logger.AddLog("Visualizer.cs - UpdateProgressBarBass:W: value is greater than 100");
				value = 100;
			}
			ProgressBar pb;
			switch(bar)
			{
				case ProgressBarLevel.Low:
					{
						pb = ProgressBarBass;
						break;
					}
				case ProgressBarLevel.Medium:
					{
						pb = ProgressBarMid;
						break;
					}
				case ProgressBarLevel.High:
					{
						pb = ProgressBarHigh;
						break;
					}
				default:
					{
						pb = ProgressBarBass;
						break;
					}
			}
			if (pb.InvokeRequired)
			{
				pb.BeginInvoke((MethodInvoker)delegate () { pb.Value = value; });
			}
			else
				pb.Value = value;
		}

		public void UpdateActualAverageLabel(double avg)
		{
			if (Label_ActualAverage.InvokeRequired)
			{
				Label_ActualAverage.BeginInvoke((MethodInvoker)delegate () { Label_ActualAverage.Text = "actual: " + avg.ToString(); });
			}
			else
				Label_ActualAverage.Text = "actual: " + avg.ToString();
		}
		public void UpdateHistoryAverageLabel(double avg)
		{
			if (Label_HistoryAverage.InvokeRequired)
			{
				Label_HistoryAverage.BeginInvoke((MethodInvoker)delegate () { Label_HistoryAverage.Text = "history: " + avg.ToString(); });
			}
			else
				Label_HistoryAverage.Text = "history: " + avg.ToString();
		}
	}

}
