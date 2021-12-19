
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
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
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(181, 62);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(194, 21);
			this.comboBox1.TabIndex = 6;
			// 
			// Form_LightTriggerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.MidnightBlue;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.Label_Title);
			this.Controls.Add(this.Btn_Close);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form_LightTriggerControl";
			this.Text = "Form_LightTriggerControl";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Btn_Close;
		private System.Windows.Forms.Label Label_Title;
		private System.Windows.Forms.ComboBox comboBox1;
	}
}