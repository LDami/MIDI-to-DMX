namespace DMX_MIDI
{
	partial class Form_Settings
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
			this.Btn_Close = new System.Windows.Forms.Button();
			this.Label_Title = new System.Windows.Forms.Label();
			this.List_MIDIIn = new System.Windows.Forms.ComboBox();
			this.Label_MIDIInput = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.List_Serial = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// Btn_Close
			// 
			this.Btn_Close.FlatAppearance.BorderSize = 0;
			this.Btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
			this.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Btn_Close.Font = new System.Drawing.Font("Marlett", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Btn_Close.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.Btn_Close.Location = new System.Drawing.Point(725, 0);
			this.Btn_Close.Name = "Btn_Close";
			this.Btn_Close.Size = new System.Drawing.Size(75, 23);
			this.Btn_Close.TabIndex = 2;
			this.Btn_Close.Text = "X";
			this.Btn_Close.UseVisualStyleBackColor = true;
			this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
			// 
			// Label_Title
			// 
			this.Label_Title.AutoSize = true;
			this.Label_Title.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_Title.ForeColor = System.Drawing.SystemColors.Menu;
			this.Label_Title.Location = new System.Drawing.Point(12, 3);
			this.Label_Title.Name = "Label_Title";
			this.Label_Title.Size = new System.Drawing.Size(90, 18);
			this.Label_Title.TabIndex = 3;
			this.Label_Title.Text = "Paramètres";
			// 
			// List_MIDIIn
			// 
			this.List_MIDIIn.FormattingEnabled = true;
			this.List_MIDIIn.Location = new System.Drawing.Point(303, 64);
			this.List_MIDIIn.Name = "List_MIDIIn";
			this.List_MIDIIn.Size = new System.Drawing.Size(291, 21);
			this.List_MIDIIn.TabIndex = 4;
			this.List_MIDIIn.DropDownClosed += new System.EventHandler(this.List_MIDIIn_DropDownClosed);
			// 
			// Label_MIDIInput
			// 
			this.Label_MIDIInput.AutoSize = true;
			this.Label_MIDIInput.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.Label_MIDIInput.Location = new System.Drawing.Point(212, 67);
			this.Label_MIDIInput.Name = "Label_MIDIInput";
			this.Label_MIDIInput.Size = new System.Drawing.Size(64, 13);
			this.Label_MIDIInput.TabIndex = 5;
			this.Label_MIDIInput.Text = "Entrée MIDI";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.label1.Location = new System.Drawing.Point(212, 113);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Port série";
			// 
			// List_Serial
			// 
			this.List_Serial.FormattingEnabled = true;
			this.List_Serial.Location = new System.Drawing.Point(303, 110);
			this.List_Serial.Name = "List_Serial";
			this.List_Serial.Size = new System.Drawing.Size(291, 21);
			this.List_Serial.TabIndex = 6;
			this.List_Serial.DropDownClosed += new System.EventHandler(this.List_Serial_DropDownClosed);
			// 
			// Form_Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.MidnightBlue;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.List_Serial);
			this.Controls.Add(this.Label_MIDIInput);
			this.Controls.Add(this.List_MIDIIn);
			this.Controls.Add(this.Label_Title);
			this.Controls.Add(this.Btn_Close);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form_Settings";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.Form_Settings_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_Settings_MouseDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Btn_Close;
		private System.Windows.Forms.Label Label_Title;
		private System.Windows.Forms.ComboBox List_MIDIIn;
		private System.Windows.Forms.Label Label_MIDIInput;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox List_Serial;
	}
}