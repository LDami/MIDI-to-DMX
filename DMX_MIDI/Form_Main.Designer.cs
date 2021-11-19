﻿namespace DMX_MIDI
{
	partial class Form_Main
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
			this.Btn_Settings = new System.Windows.Forms.Button();
			this.Btn_Close = new System.Windows.Forms.Button();
			this.Label_Title = new System.Windows.Forms.Label();
			this.Label_SerialStatus = new System.Windows.Forms.Label();
			this.light2 = new System.Windows.Forms.PictureBox();
			this.Btn_Play = new System.Windows.Forms.Button();
			this.light1 = new System.Windows.Forms.PictureBox();
			this.containerLight1 = new System.Windows.Forms.FlowLayoutPanel();
			this.Btn_Flash = new System.Windows.Forms.Button();
			this.TL_Line = new System.Windows.Forms.Label();
			this.TL_Current = new System.Windows.Forms.Label();
			this.Label_CurrentFrame = new System.Windows.Forms.Label();
			this.Label_Red_Value = new System.Windows.Forms.Label();
			this.Line_Red_Value = new System.Windows.Forms.Label();
			this.Slider_Red_Value = new System.Windows.Forms.Label();
			this.Slider_Green_Value = new System.Windows.Forms.Label();
			this.Line_Green_Value = new System.Windows.Forms.Label();
			this.Label_Green_Value = new System.Windows.Forms.Label();
			this.Slider_Blue_Value = new System.Windows.Forms.Label();
			this.Line_Blue_Value = new System.Windows.Forms.Label();
			this.Label_Blue_Value = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.light2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.light1)).BeginInit();
			this.containerLight1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Btn_Settings
			// 
			this.Btn_Settings.Location = new System.Drawing.Point(971, 2);
			this.Btn_Settings.Name = "Btn_Settings";
			this.Btn_Settings.Size = new System.Drawing.Size(75, 23);
			this.Btn_Settings.TabIndex = 0;
			this.Btn_Settings.Text = "Paramètres";
			this.Btn_Settings.UseVisualStyleBackColor = true;
			this.Btn_Settings.Click += new System.EventHandler(this.Btn_Settings_Click);
			// 
			// Btn_Close
			// 
			this.Btn_Close.FlatAppearance.BorderSize = 0;
			this.Btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
			this.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Btn_Close.Font = new System.Drawing.Font("Marlett", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Btn_Close.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.Btn_Close.Location = new System.Drawing.Point(1052, 0);
			this.Btn_Close.Name = "Btn_Close";
			this.Btn_Close.Size = new System.Drawing.Size(75, 23);
			this.Btn_Close.TabIndex = 1;
			this.Btn_Close.Text = "X";
			this.Btn_Close.UseVisualStyleBackColor = true;
			this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
			// 
			// Label_Title
			// 
			this.Label_Title.AutoSize = true;
			this.Label_Title.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_Title.ForeColor = System.Drawing.SystemColors.Menu;
			this.Label_Title.Location = new System.Drawing.Point(12, 5);
			this.Label_Title.Name = "Label_Title";
			this.Label_Title.Size = new System.Drawing.Size(96, 18);
			this.Label_Title.TabIndex = 4;
			this.Label_Title.Text = "MIDI to DMX";
			// 
			// Label_SerialStatus
			// 
			this.Label_SerialStatus.AutoSize = true;
			this.Label_SerialStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_SerialStatus.ForeColor = System.Drawing.SystemColors.Control;
			this.Label_SerialStatus.Location = new System.Drawing.Point(12, 533);
			this.Label_SerialStatus.Name = "Label_SerialStatus";
			this.Label_SerialStatus.Size = new System.Drawing.Size(41, 16);
			this.Label_SerialStatus.TabIndex = 5;
			this.Label_SerialStatus.Text = "Serial";
			// 
			// light2
			// 
			this.light2.BackColor = System.Drawing.Color.AliceBlue;
			this.light2.Image = ((System.Drawing.Image)(resources.GetObject("light2.Image")));
			this.light2.Location = new System.Drawing.Point(18, 141);
			this.light2.Name = "light2";
			this.light2.Size = new System.Drawing.Size(122, 79);
			this.light2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.light2.TabIndex = 6;
			this.light2.TabStop = false;
			this.light2.Tag = "2";
			this.light2.Click += new System.EventHandler(this.light2_Click);
			// 
			// Btn_Play
			// 
			this.Btn_Play.Location = new System.Drawing.Point(33, 432);
			this.Btn_Play.Name = "Btn_Play";
			this.Btn_Play.Size = new System.Drawing.Size(75, 23);
			this.Btn_Play.TabIndex = 9;
			this.Btn_Play.Text = "Lecture";
			this.Btn_Play.UseVisualStyleBackColor = true;
			this.Btn_Play.Click += new System.EventHandler(this.Btn_Play_Click);
			// 
			// light1
			// 
			this.light1.Image = ((System.Drawing.Image)(resources.GetObject("light1.Image")));
			this.light1.Location = new System.Drawing.Point(3, 3);
			this.light1.Name = "light1";
			this.light1.Size = new System.Drawing.Size(122, 79);
			this.light1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.light1.TabIndex = 6;
			this.light1.TabStop = false;
			this.light1.Tag = "1";
			this.light1.Click += new System.EventHandler(this.light1_Click);
			// 
			// containerLight1
			// 
			this.containerLight1.BackColor = System.Drawing.Color.AliceBlue;
			this.containerLight1.Controls.Add(this.light1);
			this.containerLight1.Location = new System.Drawing.Point(15, 53);
			this.containerLight1.Name = "containerLight1";
			this.containerLight1.Size = new System.Drawing.Size(658, 244);
			this.containerLight1.TabIndex = 7;
			// 
			// Btn_Flash
			// 
			this.Btn_Flash.Location = new System.Drawing.Point(33, 403);
			this.Btn_Flash.Name = "Btn_Flash";
			this.Btn_Flash.Size = new System.Drawing.Size(75, 23);
			this.Btn_Flash.TabIndex = 7;
			this.Btn_Flash.Tag = "1";
			this.Btn_Flash.Text = "Flash";
			this.Btn_Flash.UseVisualStyleBackColor = true;
			this.Btn_Flash.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Flash_MouseDown);
			this.Btn_Flash.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Flash_MouseUp);
			// 
			// TL_Line
			// 
			this.TL_Line.AutoSize = true;
			this.TL_Line.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TL_Line.Location = new System.Drawing.Point(30, 484);
			this.TL_Line.MaximumSize = new System.Drawing.Size(2, 5);
			this.TL_Line.MinimumSize = new System.Drawing.Size(1000, 2);
			this.TL_Line.Name = "TL_Line";
			this.TL_Line.Size = new System.Drawing.Size(1000, 5);
			this.TL_Line.TabIndex = 10;
			// 
			// TL_Current
			// 
			this.TL_Current.AutoSize = true;
			this.TL_Current.Cursor = System.Windows.Forms.Cursors.Hand;
			this.TL_Current.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TL_Current.ForeColor = System.Drawing.SystemColors.Control;
			this.TL_Current.Location = new System.Drawing.Point(27, 476);
			this.TL_Current.Name = "TL_Current";
			this.TL_Current.Size = new System.Drawing.Size(16, 13);
			this.TL_Current.TabIndex = 11;
			this.TL_Current.Text = "O";
			this.TL_Current.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.TL_Current.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TL_Current_MouseDown);
			this.TL_Current.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TL_Current_MouseMove);
			this.TL_Current.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TL_Current_MouseUp);
			// 
			// Label_CurrentFrame
			// 
			this.Label_CurrentFrame.AutoSize = true;
			this.Label_CurrentFrame.ForeColor = System.Drawing.SystemColors.Control;
			this.Label_CurrentFrame.Location = new System.Drawing.Point(1037, 484);
			this.Label_CurrentFrame.Name = "Label_CurrentFrame";
			this.Label_CurrentFrame.Size = new System.Drawing.Size(83, 13);
			this.Label_CurrentFrame.TabIndex = 12;
			this.Label_CurrentFrame.Text = "Frame: 000/000";
			// 
			// Label_Red_Value
			// 
			this.Label_Red_Value.AutoSize = true;
			this.Label_Red_Value.ForeColor = System.Drawing.SystemColors.Control;
			this.Label_Red_Value.Location = new System.Drawing.Point(746, 80);
			this.Label_Red_Value.Name = "Label_Red_Value";
			this.Label_Red_Value.Size = new System.Drawing.Size(27, 13);
			this.Label_Red_Value.TabIndex = 13;
			this.Label_Red_Value.Text = "Red";
			// 
			// Line_Red_Value
			// 
			this.Line_Red_Value.AutoSize = true;
			this.Line_Red_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Line_Red_Value.Location = new System.Drawing.Point(749, 102);
			this.Line_Red_Value.MaximumSize = new System.Drawing.Size(2, 5);
			this.Line_Red_Value.MinimumSize = new System.Drawing.Size(256, 2);
			this.Line_Red_Value.Name = "Line_Red_Value";
			this.Line_Red_Value.Size = new System.Drawing.Size(256, 5);
			this.Line_Red_Value.TabIndex = 14;
			// 
			// Slider_Red_Value
			// 
			this.Slider_Red_Value.AutoSize = true;
			this.Slider_Red_Value.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Slider_Red_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Slider_Red_Value.ForeColor = System.Drawing.SystemColors.Control;
			this.Slider_Red_Value.Location = new System.Drawing.Point(746, 94);
			this.Slider_Red_Value.Name = "Slider_Red_Value";
			this.Slider_Red_Value.Size = new System.Drawing.Size(16, 13);
			this.Slider_Red_Value.TabIndex = 15;
			this.Slider_Red_Value.Text = "O";
			this.Slider_Red_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Slider_Red_Value.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Slider_Red_Value_MouseDown);
			this.Slider_Red_Value.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Slider_Red_Value_MouseMove);
			this.Slider_Red_Value.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Slider_Red_Value_MouseUp);
			// 
			// Slider_Green_Value
			// 
			this.Slider_Green_Value.AutoSize = true;
			this.Slider_Green_Value.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Slider_Green_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Slider_Green_Value.ForeColor = System.Drawing.SystemColors.Control;
			this.Slider_Green_Value.Location = new System.Drawing.Point(746, 133);
			this.Slider_Green_Value.Name = "Slider_Green_Value";
			this.Slider_Green_Value.Size = new System.Drawing.Size(16, 13);
			this.Slider_Green_Value.TabIndex = 18;
			this.Slider_Green_Value.Text = "O";
			this.Slider_Green_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Slider_Green_Value.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Slider_Green_Value_MouseDown);
			this.Slider_Green_Value.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Slider_Green_Value_MouseMove);
			this.Slider_Green_Value.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Slider_Green_Value_MouseUp);
			// 
			// Line_Green_Value
			// 
			this.Line_Green_Value.AutoSize = true;
			this.Line_Green_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Line_Green_Value.Location = new System.Drawing.Point(749, 141);
			this.Line_Green_Value.MaximumSize = new System.Drawing.Size(2, 5);
			this.Line_Green_Value.MinimumSize = new System.Drawing.Size(256, 2);
			this.Line_Green_Value.Name = "Line_Green_Value";
			this.Line_Green_Value.Size = new System.Drawing.Size(256, 5);
			this.Line_Green_Value.TabIndex = 17;
			// 
			// Label_Green_Value
			// 
			this.Label_Green_Value.AutoSize = true;
			this.Label_Green_Value.ForeColor = System.Drawing.SystemColors.Control;
			this.Label_Green_Value.Location = new System.Drawing.Point(746, 119);
			this.Label_Green_Value.Name = "Label_Green_Value";
			this.Label_Green_Value.Size = new System.Drawing.Size(36, 13);
			this.Label_Green_Value.TabIndex = 16;
			this.Label_Green_Value.Text = "Green";
			// 
			// Slider_Blue_Value
			// 
			this.Slider_Blue_Value.AutoSize = true;
			this.Slider_Blue_Value.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Slider_Blue_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Slider_Blue_Value.ForeColor = System.Drawing.SystemColors.Control;
			this.Slider_Blue_Value.Location = new System.Drawing.Point(746, 171);
			this.Slider_Blue_Value.Name = "Slider_Blue_Value";
			this.Slider_Blue_Value.Size = new System.Drawing.Size(16, 13);
			this.Slider_Blue_Value.TabIndex = 21;
			this.Slider_Blue_Value.Text = "O";
			this.Slider_Blue_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Slider_Blue_Value.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Slider_Blue_Value_MouseDown);
			this.Slider_Blue_Value.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Slider_Blue_Value_MouseMove);
			this.Slider_Blue_Value.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Slider_Blue_Value_MouseUp);
			// 
			// Line_Blue_Value
			// 
			this.Line_Blue_Value.AutoSize = true;
			this.Line_Blue_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Line_Blue_Value.Location = new System.Drawing.Point(749, 179);
			this.Line_Blue_Value.MaximumSize = new System.Drawing.Size(2, 5);
			this.Line_Blue_Value.MinimumSize = new System.Drawing.Size(256, 2);
			this.Line_Blue_Value.Name = "Line_Blue_Value";
			this.Line_Blue_Value.Size = new System.Drawing.Size(256, 5);
			this.Line_Blue_Value.TabIndex = 20;
			// 
			// Label_Blue_Value
			// 
			this.Label_Blue_Value.AutoSize = true;
			this.Label_Blue_Value.ForeColor = System.Drawing.SystemColors.Control;
			this.Label_Blue_Value.Location = new System.Drawing.Point(746, 157);
			this.Label_Blue_Value.Name = "Label_Blue_Value";
			this.Label_Blue_Value.Size = new System.Drawing.Size(28, 13);
			this.Label_Blue_Value.TabIndex = 19;
			this.Label_Blue_Value.Text = "Blue";
			// 
			// Form_Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.MidnightBlue;
			this.ClientSize = new System.Drawing.Size(1128, 558);
			this.Controls.Add(this.Slider_Blue_Value);
			this.Controls.Add(this.Line_Blue_Value);
			this.Controls.Add(this.Label_Blue_Value);
			this.Controls.Add(this.Slider_Green_Value);
			this.Controls.Add(this.Line_Green_Value);
			this.Controls.Add(this.Label_Green_Value);
			this.Controls.Add(this.Slider_Red_Value);
			this.Controls.Add(this.Line_Red_Value);
			this.Controls.Add(this.Label_Red_Value);
			this.Controls.Add(this.Label_CurrentFrame);
			this.Controls.Add(this.TL_Current);
			this.Controls.Add(this.TL_Line);
			this.Controls.Add(this.light2);
			this.Controls.Add(this.Btn_Flash);
			this.Controls.Add(this.Btn_Play);
			this.Controls.Add(this.containerLight1);
			this.Controls.Add(this.Label_SerialStatus);
			this.Controls.Add(this.Label_Title);
			this.Controls.Add(this.Btn_Close);
			this.Controls.Add(this.Btn_Settings);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form_Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
			this.Load += new System.EventHandler(this.Form_Main_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_Main_MouseDown);
			((System.ComponentModel.ISupportInitialize)(this.light2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.light1)).EndInit();
			this.containerLight1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Btn_Settings;
		private System.Windows.Forms.Button Btn_Close;
		private System.Windows.Forms.Label Label_Title;
		private System.Windows.Forms.Label Label_SerialStatus;
		private System.Windows.Forms.PictureBox light2;
		private System.Windows.Forms.Button Btn_Play;
		private System.Windows.Forms.PictureBox light1;
		private System.Windows.Forms.FlowLayoutPanel containerLight1;
		private System.Windows.Forms.Button Btn_Flash;
		private System.Windows.Forms.Label TL_Line;
		private System.Windows.Forms.Label TL_Current;
		private System.Windows.Forms.Label Label_CurrentFrame;
		private System.Windows.Forms.Label Label_Red_Value;
		private System.Windows.Forms.Label Line_Red_Value;
		private System.Windows.Forms.Label Slider_Red_Value;
		private System.Windows.Forms.Label Slider_Green_Value;
		private System.Windows.Forms.Label Line_Green_Value;
		private System.Windows.Forms.Label Label_Green_Value;
		private System.Windows.Forms.Label Slider_Blue_Value;
		private System.Windows.Forms.Label Line_Blue_Value;
		private System.Windows.Forms.Label Label_Blue_Value;
	}
}

