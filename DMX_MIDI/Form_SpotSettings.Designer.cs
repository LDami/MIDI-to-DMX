namespace DMX_MIDI
{
    partial class Form_SpotSettings
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
            this.Label_Title = new System.Windows.Forms.Label();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.Text_Name = new System.Windows.Forms.TextBox();
            this.Label_Name = new System.Windows.Forms.Label();
            this.Num_StartingChannel = new System.Windows.Forms.NumericUpDown();
            this.Label_StartingChannel = new System.Windows.Forms.Label();
            this.Label_RedCH = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Label_GreenCH = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.Label_BlueCH = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.Btn_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Num_StartingChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_Title
            // 
            this.Label_Title.AutoSize = true;
            this.Label_Title.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Title.ForeColor = System.Drawing.SystemColors.Menu;
            this.Label_Title.Location = new System.Drawing.Point(12, 1);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(75, 18);
            this.Label_Title.TabIndex = 7;
            this.Label_Title.Text = "Unnamed";
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
            this.Btn_Close.TabIndex = 6;
            this.Btn_Close.Text = "X";
            this.Btn_Close.UseVisualStyleBackColor = true;
            // 
            // Text_Name
            // 
            this.Text_Name.Location = new System.Drawing.Point(324, 87);
            this.Text_Name.Name = "Text_Name";
            this.Text_Name.Size = new System.Drawing.Size(221, 20);
            this.Text_Name.TabIndex = 8;
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_Name.Location = new System.Drawing.Point(268, 90);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(35, 13);
            this.Label_Name.TabIndex = 9;
            this.Label_Name.Text = "Name";
            // 
            // Num_StartingChannel
            // 
            this.Num_StartingChannel.Location = new System.Drawing.Point(324, 113);
            this.Num_StartingChannel.Name = "Num_StartingChannel";
            this.Num_StartingChannel.Size = new System.Drawing.Size(90, 20);
            this.Num_StartingChannel.TabIndex = 10;
            // 
            // Label_StartingChannel
            // 
            this.Label_StartingChannel.AutoSize = true;
            this.Label_StartingChannel.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_StartingChannel.Location = new System.Drawing.Point(268, 115);
            this.Label_StartingChannel.Name = "Label_StartingChannel";
            this.Label_StartingChannel.Size = new System.Drawing.Size(47, 13);
            this.Label_StartingChannel.TabIndex = 11;
            this.Label_StartingChannel.Text = "Start CH";
            // 
            // Label_RedCH
            // 
            this.Label_RedCH.AutoSize = true;
            this.Label_RedCH.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_RedCH.Location = new System.Drawing.Point(268, 141);
            this.Label_RedCH.Name = "Label_RedCH";
            this.Label_RedCH.Size = new System.Drawing.Size(45, 13);
            this.Label_RedCH.TabIndex = 13;
            this.Label_RedCH.Text = "Red CH";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(324, 139);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown1.TabIndex = 12;
            // 
            // Label_GreenCH
            // 
            this.Label_GreenCH.AutoSize = true;
            this.Label_GreenCH.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_GreenCH.Location = new System.Drawing.Point(268, 167);
            this.Label_GreenCH.Name = "Label_GreenCH";
            this.Label_GreenCH.Size = new System.Drawing.Size(54, 13);
            this.Label_GreenCH.TabIndex = 15;
            this.Label_GreenCH.Text = "Green CH";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(324, 165);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown2.TabIndex = 14;
            // 
            // Label_BlueCH
            // 
            this.Label_BlueCH.AutoSize = true;
            this.Label_BlueCH.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_BlueCH.Location = new System.Drawing.Point(268, 193);
            this.Label_BlueCH.Name = "Label_BlueCH";
            this.Label_BlueCH.Size = new System.Drawing.Size(46, 13);
            this.Label_BlueCH.TabIndex = 17;
            this.Label_BlueCH.Text = "Blue CH";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(324, 191);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown3.TabIndex = 16;
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(324, 266);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(75, 23);
            this.Btn_Save.TabIndex = 32;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Form_SpotSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Label_BlueCH);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.Label_GreenCH);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.Label_RedCH);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.Label_StartingChannel);
            this.Controls.Add(this.Num_StartingChannel);
            this.Controls.Add(this.Label_Name);
            this.Controls.Add(this.Text_Name);
            this.Controls.Add(this.Label_Title);
            this.Controls.Add(this.Btn_Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_SpotSettings";
            this.Text = "Form_SpotSettings";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_SpotSettings_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.Num_StartingChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.TextBox Text_Name;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.NumericUpDown Num_StartingChannel;
        private System.Windows.Forms.Label Label_StartingChannel;
        private System.Windows.Forms.Label Label_RedCH;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label Label_GreenCH;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label Label_BlueCH;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Button Btn_Save;
    }
}