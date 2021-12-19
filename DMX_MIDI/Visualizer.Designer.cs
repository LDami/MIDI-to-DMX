
namespace DMX_MIDI
{
	partial class Form_Visualizer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ProgressBarBass = new System.Windows.Forms.ProgressBar();
			this.ProgressBarMid = new System.Windows.Forms.ProgressBar();
			this.ProgressBarHigh = new System.Windows.Forms.ProgressBar();
			this.Label_ActualAverage = new System.Windows.Forms.Label();
			this.Label_HistoryAverage = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ProgressBarBass
			// 
			this.ProgressBarBass.Location = new System.Drawing.Point(69, 61);
			this.ProgressBarBass.Name = "ProgressBarBass";
			this.ProgressBarBass.Size = new System.Drawing.Size(331, 23);
			this.ProgressBarBass.Step = 1;
			this.ProgressBarBass.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressBarBass.TabIndex = 0;
			this.ProgressBarBass.Value = 50;
			// 
			// ProgressBarMid
			// 
			this.ProgressBarMid.Location = new System.Drawing.Point(69, 90);
			this.ProgressBarMid.Name = "ProgressBarMid";
			this.ProgressBarMid.Size = new System.Drawing.Size(331, 23);
			this.ProgressBarMid.Step = 1;
			this.ProgressBarMid.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressBarMid.TabIndex = 1;
			this.ProgressBarMid.Value = 50;
			// 
			// ProgressBarHigh
			// 
			this.ProgressBarHigh.Location = new System.Drawing.Point(69, 119);
			this.ProgressBarHigh.Name = "ProgressBarHigh";
			this.ProgressBarHigh.Size = new System.Drawing.Size(331, 23);
			this.ProgressBarHigh.Step = 1;
			this.ProgressBarHigh.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressBarHigh.TabIndex = 2;
			this.ProgressBarHigh.Value = 50;
			// 
			// Label_ActualAverage
			// 
			this.Label_ActualAverage.AutoSize = true;
			this.Label_ActualAverage.Location = new System.Drawing.Point(521, 61);
			this.Label_ActualAverage.Name = "Label_ActualAverage";
			this.Label_ActualAverage.Size = new System.Drawing.Size(35, 13);
			this.Label_ActualAverage.TabIndex = 3;
			this.Label_ActualAverage.Text = "label1";
			// 
			// Label_HistoryAverage
			// 
			this.Label_HistoryAverage.AutoSize = true;
			this.Label_HistoryAverage.Location = new System.Drawing.Point(521, 90);
			this.Label_HistoryAverage.Name = "Label_HistoryAverage";
			this.Label_HistoryAverage.Size = new System.Drawing.Size(35, 13);
			this.Label_HistoryAverage.TabIndex = 4;
			this.Label_HistoryAverage.Text = "label1";
			// 
			// Form_Visualizer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.Label_HistoryAverage);
			this.Controls.Add(this.Label_ActualAverage);
			this.Controls.Add(this.ProgressBarHigh);
			this.Controls.Add(this.ProgressBarMid);
			this.Controls.Add(this.ProgressBarBass);
			this.Name = "Form_Visualizer";
			this.Text = "Visualizer";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar ProgressBarBass;
		private System.Windows.Forms.ProgressBar ProgressBarMid;
		private System.Windows.Forms.ProgressBar ProgressBarHigh;
		private System.Windows.Forms.Label Label_ActualAverage;
		private System.Windows.Forms.Label Label_HistoryAverage;
	}
}