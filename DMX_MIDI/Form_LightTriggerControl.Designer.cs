
namespace DMX_MIDI
{
	partial class Form_LightTriggerControl
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
            this.List_EventType = new System.Windows.Forms.ComboBox();
            this.Slider_Blue_Value = new System.Windows.Forms.Label();
            this.Line_Blue_Value = new System.Windows.Forms.Label();
            this.Label_Blue_Value = new System.Windows.Forms.Label();
            this.Slider_Green_Value = new System.Windows.Forms.Label();
            this.Line_Green_Value = new System.Windows.Forms.Label();
            this.Label_Green_Value = new System.Windows.Forms.Label();
            this.Slider_Red_Value = new System.Windows.Forms.Label();
            this.Line_Red_Value = new System.Windows.Forms.Label();
            this.Label_Red_Value = new System.Windows.Forms.Label();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.List_Type = new System.Windows.Forms.ComboBox();
            this.Label_Type = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_PrimaryColor = new System.Windows.Forms.Button();
            this.Btn_SecondaryColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Close
            // 
            this.Btn_Close.FlatAppearance.BorderSize = 0;
            this.Btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Close.Font = new System.Drawing.Font("Marlett", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Close.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_Close.Location = new System.Drawing.Point(725, 1);
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
            this.Label_Title.Location = new System.Drawing.Point(12, 1);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(75, 18);
            this.Label_Title.TabIndex = 5;
            this.Label_Title.Text = "Unnamed";
            // 
            // List_EventType
            // 
            this.List_EventType.FormattingEnabled = true;
            this.List_EventType.Location = new System.Drawing.Point(210, 100);
            this.List_EventType.Name = "List_EventType";
            this.List_EventType.Size = new System.Drawing.Size(256, 21);
            this.List_EventType.TabIndex = 6;
            // 
            // Slider_Blue_Value
            // 
            this.Slider_Blue_Value.AutoSize = true;
            this.Slider_Blue_Value.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Slider_Blue_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Slider_Blue_Value.ForeColor = System.Drawing.SystemColors.Control;
            this.Slider_Blue_Value.Location = new System.Drawing.Point(207, 233);
            this.Slider_Blue_Value.Name = "Slider_Blue_Value";
            this.Slider_Blue_Value.Size = new System.Drawing.Size(16, 13);
            this.Slider_Blue_Value.TabIndex = 30;
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
            this.Line_Blue_Value.Location = new System.Drawing.Point(210, 241);
            this.Line_Blue_Value.MaximumSize = new System.Drawing.Size(2, 5);
            this.Line_Blue_Value.MinimumSize = new System.Drawing.Size(256, 2);
            this.Line_Blue_Value.Name = "Line_Blue_Value";
            this.Line_Blue_Value.Size = new System.Drawing.Size(256, 5);
            this.Line_Blue_Value.TabIndex = 29;
            // 
            // Label_Blue_Value
            // 
            this.Label_Blue_Value.AutoSize = true;
            this.Label_Blue_Value.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_Blue_Value.Location = new System.Drawing.Point(207, 219);
            this.Label_Blue_Value.Name = "Label_Blue_Value";
            this.Label_Blue_Value.Size = new System.Drawing.Size(28, 13);
            this.Label_Blue_Value.TabIndex = 28;
            this.Label_Blue_Value.Text = "Blue";
            // 
            // Slider_Green_Value
            // 
            this.Slider_Green_Value.AutoSize = true;
            this.Slider_Green_Value.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Slider_Green_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Slider_Green_Value.ForeColor = System.Drawing.SystemColors.Control;
            this.Slider_Green_Value.Location = new System.Drawing.Point(207, 195);
            this.Slider_Green_Value.Name = "Slider_Green_Value";
            this.Slider_Green_Value.Size = new System.Drawing.Size(16, 13);
            this.Slider_Green_Value.TabIndex = 27;
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
            this.Line_Green_Value.Location = new System.Drawing.Point(210, 203);
            this.Line_Green_Value.MaximumSize = new System.Drawing.Size(2, 5);
            this.Line_Green_Value.MinimumSize = new System.Drawing.Size(256, 2);
            this.Line_Green_Value.Name = "Line_Green_Value";
            this.Line_Green_Value.Size = new System.Drawing.Size(256, 5);
            this.Line_Green_Value.TabIndex = 26;
            // 
            // Label_Green_Value
            // 
            this.Label_Green_Value.AutoSize = true;
            this.Label_Green_Value.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_Green_Value.Location = new System.Drawing.Point(207, 181);
            this.Label_Green_Value.Name = "Label_Green_Value";
            this.Label_Green_Value.Size = new System.Drawing.Size(36, 13);
            this.Label_Green_Value.TabIndex = 25;
            this.Label_Green_Value.Text = "Green";
            // 
            // Slider_Red_Value
            // 
            this.Slider_Red_Value.AutoSize = true;
            this.Slider_Red_Value.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Slider_Red_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Slider_Red_Value.ForeColor = System.Drawing.SystemColors.Control;
            this.Slider_Red_Value.Location = new System.Drawing.Point(207, 156);
            this.Slider_Red_Value.Name = "Slider_Red_Value";
            this.Slider_Red_Value.Size = new System.Drawing.Size(16, 13);
            this.Slider_Red_Value.TabIndex = 24;
            this.Slider_Red_Value.Text = "O";
            this.Slider_Red_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Slider_Red_Value.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Slider_Red_Value_MouseDown);
            this.Slider_Red_Value.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Slider_Red_Value_MouseMove);
            this.Slider_Red_Value.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Slider_Red_Value_MouseUp);
            // 
            // Line_Red_Value
            // 
            this.Line_Red_Value.AutoSize = true;
            this.Line_Red_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Line_Red_Value.Location = new System.Drawing.Point(210, 164);
            this.Line_Red_Value.MaximumSize = new System.Drawing.Size(2, 5);
            this.Line_Red_Value.MinimumSize = new System.Drawing.Size(256, 2);
            this.Line_Red_Value.Name = "Line_Red_Value";
            this.Line_Red_Value.Size = new System.Drawing.Size(256, 5);
            this.Line_Red_Value.TabIndex = 23;
            // 
            // Label_Red_Value
            // 
            this.Label_Red_Value.AutoSize = true;
            this.Label_Red_Value.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_Red_Value.Location = new System.Drawing.Point(207, 142);
            this.Label_Red_Value.Name = "Label_Red_Value";
            this.Label_Red_Value.Size = new System.Drawing.Size(27, 13);
            this.Label_Red_Value.TabIndex = 22;
            this.Label_Red_Value.Text = "Red";
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(285, 344);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(75, 23);
            this.Btn_Save.TabIndex = 31;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // List_Type
            // 
            this.List_Type.FormattingEnabled = true;
            this.List_Type.Location = new System.Drawing.Point(210, 73);
            this.List_Type.Name = "List_Type";
            this.List_Type.Size = new System.Drawing.Size(256, 21);
            this.List_Type.TabIndex = 32;
            // 
            // Label_Type
            // 
            this.Label_Type.AutoSize = true;
            this.Label_Type.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_Type.Location = new System.Drawing.Point(123, 76);
            this.Label_Type.Name = "Label_Type";
            this.Label_Type.Size = new System.Drawing.Size(77, 13);
            this.Label_Type.TabIndex = 33;
            this.Label_Type.Text = "Triggering type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(123, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Triggered event";
            // 
            // Btn_PrimaryColor
            // 
            this.Btn_PrimaryColor.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Btn_PrimaryColor.Location = new System.Drawing.Point(502, 146);
            this.Btn_PrimaryColor.Name = "Btn_PrimaryColor";
            this.Btn_PrimaryColor.Size = new System.Drawing.Size(154, 23);
            this.Btn_PrimaryColor.TabIndex = 36;
            this.Btn_PrimaryColor.Text = "Primary";
            this.Btn_PrimaryColor.UseVisualStyleBackColor = false;
            this.Btn_PrimaryColor.Click += new System.EventHandler(this.Btn_PrimaryColor_Click);
            // 
            // Btn_SecondaryColor
            // 
            this.Btn_SecondaryColor.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Btn_SecondaryColor.Location = new System.Drawing.Point(502, 176);
            this.Btn_SecondaryColor.Name = "Btn_SecondaryColor";
            this.Btn_SecondaryColor.Size = new System.Drawing.Size(154, 23);
            this.Btn_SecondaryColor.TabIndex = 37;
            this.Btn_SecondaryColor.Text = "Secondary";
            this.Btn_SecondaryColor.UseVisualStyleBackColor = false;
            this.Btn_SecondaryColor.Click += new System.EventHandler(this.Btn_SecondaryColor_Click);
            // 
            // Form_LightTriggerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_SecondaryColor);
            this.Controls.Add(this.Btn_PrimaryColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label_Type);
            this.Controls.Add(this.List_Type);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Slider_Blue_Value);
            this.Controls.Add(this.Line_Blue_Value);
            this.Controls.Add(this.Label_Blue_Value);
            this.Controls.Add(this.Slider_Green_Value);
            this.Controls.Add(this.Line_Green_Value);
            this.Controls.Add(this.Label_Green_Value);
            this.Controls.Add(this.Slider_Red_Value);
            this.Controls.Add(this.Line_Red_Value);
            this.Controls.Add(this.Label_Red_Value);
            this.Controls.Add(this.List_EventType);
            this.Controls.Add(this.Label_Title);
            this.Controls.Add(this.Btn_Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_LightTriggerControl";
            this.Text = "Form_LightTriggerControl";
            this.Shown += new System.EventHandler(this.Form_LightTriggerControl_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_LightTriggerControl_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Btn_Close;
		private System.Windows.Forms.Label Label_Title;
		private System.Windows.Forms.ComboBox List_EventType;
        private System.Windows.Forms.Label Slider_Blue_Value;
        private System.Windows.Forms.Label Line_Blue_Value;
        private System.Windows.Forms.Label Label_Blue_Value;
        private System.Windows.Forms.Label Slider_Green_Value;
        private System.Windows.Forms.Label Line_Green_Value;
        private System.Windows.Forms.Label Label_Green_Value;
        private System.Windows.Forms.Label Slider_Red_Value;
        private System.Windows.Forms.Label Line_Red_Value;
        private System.Windows.Forms.Label Label_Red_Value;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.ComboBox List_Type;
        private System.Windows.Forms.Label Label_Type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_PrimaryColor;
        private System.Windows.Forms.Button Btn_SecondaryColor;
    }
}