namespace DMX_MIDI
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
            this.Label_BPM = new System.Windows.Forms.Label();
            this.Label_BPMInfo = new System.Windows.Forms.Label();
            this.Button_Auto = new System.Windows.Forms.Button();
            this.lightTriggers = new System.Windows.Forms.TableLayoutPanel();
            this.Label_MidiDevice = new System.Windows.Forms.Label();
            this.Slider_Freq_Filter = new System.Windows.Forms.Label();
            this.Line_Freq_Filter = new System.Windows.Forms.Label();
            this.Label_Freq_Filter = new System.Windows.Forms.Label();
            this.Button_InstantToExcel = new System.Windows.Forms.Button();
            this.Label_PeakLevel = new System.Windows.Forms.Label();
            this.Label_AverageLevel = new System.Windows.Forms.Label();
            this.Btn_ManualDMX = new System.Windows.Forms.Button();
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
            this.Label_SerialStatus.Size = new System.Drawing.Size(78, 16);
            this.Label_SerialStatus.TabIndex = 5;
            this.Label_SerialStatus.Text = "Serial: None";
            this.Label_SerialStatus.Click += new System.EventHandler(this.Label_SerialStatus_Click);
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
            // Label_BPM
            // 
            this.Label_BPM.AutoSize = true;
            this.Label_BPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_BPM.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_BPM.Location = new System.Drawing.Point(26, 330);
            this.Label_BPM.Name = "Label_BPM";
            this.Label_BPM.Size = new System.Drawing.Size(182, 42);
            this.Label_BPM.TabIndex = 22;
            this.Label_BPM.Text = "BPM: 000";
            this.Label_BPM.Click += new System.EventHandler(this.Label_BPM_Click);
            // 
            // Label_BPMInfo
            // 
            this.Label_BPMInfo.AutoSize = true;
            this.Label_BPMInfo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_BPMInfo.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_BPMInfo.Location = new System.Drawing.Point(835, 533);
            this.Label_BPMInfo.Name = "Label_BPMInfo";
            this.Label_BPMInfo.Size = new System.Drawing.Size(27, 16);
            this.Label_BPMInfo.TabIndex = 23;
            this.Label_BPMInfo.Text = "Info";
            // 
            // Button_Auto
            // 
            this.Button_Auto.Location = new System.Drawing.Point(114, 403);
            this.Button_Auto.Name = "Button_Auto";
            this.Button_Auto.Size = new System.Drawing.Size(75, 23);
            this.Button_Auto.TabIndex = 24;
            this.Button_Auto.Text = "Auto/Man";
            this.Button_Auto.UseVisualStyleBackColor = true;
            this.Button_Auto.Click += new System.EventHandler(this.Button_Auto_Click);
            // 
            // lightTriggers
            // 
            this.lightTriggers.ColumnCount = 1;
            this.lightTriggers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.lightTriggers.Location = new System.Drawing.Point(274, 330);
            this.lightTriggers.Name = "lightTriggers";
            this.lightTriggers.RowCount = 1;
            this.lightTriggers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lightTriggers.Size = new System.Drawing.Size(808, 125);
            this.lightTriggers.TabIndex = 26;
            // 
            // Label_MidiDevice
            // 
            this.Label_MidiDevice.AutoSize = true;
            this.Label_MidiDevice.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_MidiDevice.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_MidiDevice.Location = new System.Drawing.Point(101, 533);
            this.Label_MidiDevice.Name = "Label_MidiDevice";
            this.Label_MidiDevice.Size = new System.Drawing.Size(71, 16);
            this.Label_MidiDevice.TabIndex = 27;
            this.Label_MidiDevice.Text = "MIDI: None";
            // 
            // Slider_Freq_Filter
            // 
            this.Slider_Freq_Filter.AutoSize = true;
            this.Slider_Freq_Filter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Slider_Freq_Filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Slider_Freq_Filter.ForeColor = System.Drawing.SystemColors.Control;
            this.Slider_Freq_Filter.Location = new System.Drawing.Point(746, 254);
            this.Slider_Freq_Filter.Name = "Slider_Freq_Filter";
            this.Slider_Freq_Filter.Size = new System.Drawing.Size(16, 13);
            this.Slider_Freq_Filter.TabIndex = 30;
            this.Slider_Freq_Filter.Text = "O";
            this.Slider_Freq_Filter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Slider_Freq_Filter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Slider_Freq_Filter_MouseDown);
            this.Slider_Freq_Filter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Slider_Freq_Filter_MouseMove);
            this.Slider_Freq_Filter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Slider_Freq_Filter_MouseUp);
            // 
            // Line_Freq_Filter
            // 
            this.Line_Freq_Filter.AutoSize = true;
            this.Line_Freq_Filter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Line_Freq_Filter.Location = new System.Drawing.Point(749, 262);
            this.Line_Freq_Filter.MaximumSize = new System.Drawing.Size(2, 5);
            this.Line_Freq_Filter.MinimumSize = new System.Drawing.Size(256, 2);
            this.Line_Freq_Filter.Name = "Line_Freq_Filter";
            this.Line_Freq_Filter.Size = new System.Drawing.Size(256, 5);
            this.Line_Freq_Filter.TabIndex = 29;
            // 
            // Label_Freq_Filter
            // 
            this.Label_Freq_Filter.AutoSize = true;
            this.Label_Freq_Filter.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_Freq_Filter.Location = new System.Drawing.Point(746, 240);
            this.Label_Freq_Filter.Name = "Label_Freq_Filter";
            this.Label_Freq_Filter.Size = new System.Drawing.Size(57, 13);
            this.Label_Freq_Filter.TabIndex = 28;
            this.Label_Freq_Filter.Text = "Frequency";
            // 
            // Button_InstantToExcel
            // 
            this.Button_InstantToExcel.Location = new System.Drawing.Point(114, 432);
            this.Button_InstantToExcel.Name = "Button_InstantToExcel";
            this.Button_InstantToExcel.Size = new System.Drawing.Size(75, 23);
            this.Button_InstantToExcel.TabIndex = 31;
            this.Button_InstantToExcel.Text = "Instant to Excel";
            this.Button_InstantToExcel.UseVisualStyleBackColor = true;
            this.Button_InstantToExcel.Click += new System.EventHandler(this.Button_InstantToExcel_Click);
            // 
            // Label_PeakLevel
            // 
            this.Label_PeakLevel.AutoSize = true;
            this.Label_PeakLevel.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_PeakLevel.Location = new System.Drawing.Point(749, 283);
            this.Label_PeakLevel.Name = "Label_PeakLevel";
            this.Label_PeakLevel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label_PeakLevel.Size = new System.Drawing.Size(35, 13);
            this.Label_PeakLevel.TabIndex = 32;
            this.Label_PeakLevel.Text = "Peak:";
            // 
            // Label_AverageLevel
            // 
            this.Label_AverageLevel.AutoSize = true;
            this.Label_AverageLevel.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_AverageLevel.Location = new System.Drawing.Point(749, 296);
            this.Label_AverageLevel.Name = "Label_AverageLevel";
            this.Label_AverageLevel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label_AverageLevel.Size = new System.Drawing.Size(50, 13);
            this.Label_AverageLevel.TabIndex = 33;
            this.Label_AverageLevel.Text = "Average:";
            // 
            // Btn_ManualDMX
            // 
            this.Btn_ManualDMX.Location = new System.Drawing.Point(861, 2);
            this.Btn_ManualDMX.Name = "Btn_ManualDMX";
            this.Btn_ManualDMX.Size = new System.Drawing.Size(104, 23);
            this.Btn_ManualDMX.TabIndex = 34;
            this.Btn_ManualDMX.Text = "Manual DMX";
            this.Btn_ManualDMX.UseVisualStyleBackColor = true;
            this.Btn_ManualDMX.Click += new System.EventHandler(this.Btn_ManualDMX_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1128, 558);
            this.Controls.Add(this.Btn_ManualDMX);
            this.Controls.Add(this.Label_AverageLevel);
            this.Controls.Add(this.Label_PeakLevel);
            this.Controls.Add(this.Button_InstantToExcel);
            this.Controls.Add(this.Slider_Freq_Filter);
            this.Controls.Add(this.Line_Freq_Filter);
            this.Controls.Add(this.Label_Freq_Filter);
            this.Controls.Add(this.Label_MidiDevice);
            this.Controls.Add(this.lightTriggers);
            this.Controls.Add(this.Button_Auto);
            this.Controls.Add(this.Label_BPMInfo);
            this.Controls.Add(this.Label_BPM);
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
		private System.Windows.Forms.Label Label_BPM;
		private System.Windows.Forms.Label Label_BPMInfo;
		private System.Windows.Forms.Button Button_Auto;
		private System.Windows.Forms.TableLayoutPanel lightTriggers;
		private System.Windows.Forms.Label Label_MidiDevice;
		private System.Windows.Forms.Label Slider_Freq_Filter;
		private System.Windows.Forms.Label Line_Freq_Filter;
		private System.Windows.Forms.Label Label_Freq_Filter;
		private System.Windows.Forms.Button Button_InstantToExcel;
        private System.Windows.Forms.Label Label_PeakLevel;
        private System.Windows.Forms.Label Label_AverageLevel;
        private System.Windows.Forms.Button Btn_ManualDMX;
    }
}

