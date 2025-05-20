namespace DMX_MIDI
{
    partial class ManualDMXSliderControl
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.TrackBar_Val = new System.Windows.Forms.TrackBar();
            this.Label_Val = new System.Windows.Forms.Label();
            this.Label_Addr = new System.Windows.Forms.Label();
            this.Btn_DecreaseVal = new System.Windows.Forms.Button();
            this.Btn_IncreaseVal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar_Val)).BeginInit();
            this.SuspendLayout();
            // 
            // TrackBar_Val
            // 
            this.TrackBar_Val.BackColor = System.Drawing.SystemColors.HotTrack;
            this.TrackBar_Val.Location = new System.Drawing.Point(15, 24);
            this.TrackBar_Val.Maximum = 255;
            this.TrackBar_Val.Name = "TrackBar_Val";
            this.TrackBar_Val.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBar_Val.Size = new System.Drawing.Size(45, 281);
            this.TrackBar_Val.TabIndex = 0;
            this.TrackBar_Val.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TrackBar_Val.Scroll += new System.EventHandler(this.TrackBar_Val_Scroll);
            // 
            // Label_Val
            // 
            this.Label_Val.AutoSize = true;
            this.Label_Val.Location = new System.Drawing.Point(26, 308);
            this.Label_Val.Name = "Label_Val";
            this.Label_Val.Size = new System.Drawing.Size(25, 13);
            this.Label_Val.TabIndex = 1;
            this.Label_Val.Text = "255";
            this.Label_Val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Addr
            // 
            this.Label_Addr.AutoSize = true;
            this.Label_Addr.Location = new System.Drawing.Point(12, 8);
            this.Label_Addr.Name = "Label_Addr";
            this.Label_Addr.Size = new System.Drawing.Size(41, 13);
            this.Label_Addr.TabIndex = 2;
            this.Label_Addr.Text = "Addr: 0";
            // 
            // Btn_DecreaseVal
            // 
            this.Btn_DecreaseVal.Location = new System.Drawing.Point(4, 303);
            this.Btn_DecreaseVal.Name = "Btn_DecreaseVal";
            this.Btn_DecreaseVal.Size = new System.Drawing.Size(16, 23);
            this.Btn_DecreaseVal.TabIndex = 3;
            this.Btn_DecreaseVal.Text = "-";
            this.Btn_DecreaseVal.UseVisualStyleBackColor = true;
            this.Btn_DecreaseVal.Click += new System.EventHandler(this.Btn_DecreaseVal_Click);
            // 
            // Btn_IncreaseVal
            // 
            this.Btn_IncreaseVal.Location = new System.Drawing.Point(54, 303);
            this.Btn_IncreaseVal.Name = "Btn_IncreaseVal";
            this.Btn_IncreaseVal.Size = new System.Drawing.Size(16, 23);
            this.Btn_IncreaseVal.TabIndex = 4;
            this.Btn_IncreaseVal.Text = "+";
            this.Btn_IncreaseVal.UseVisualStyleBackColor = true;
            this.Btn_IncreaseVal.Click += new System.EventHandler(this.Btn_IncreaseVal_Click);
            // 
            // ManualDMXSliderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Controls.Add(this.Btn_IncreaseVal);
            this.Controls.Add(this.Btn_DecreaseVal);
            this.Controls.Add(this.Label_Addr);
            this.Controls.Add(this.Label_Val);
            this.Controls.Add(this.TrackBar_Val);
            this.Name = "ManualDMXSliderControl";
            this.Size = new System.Drawing.Size(73, 333);
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar_Val)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar TrackBar_Val;
        private System.Windows.Forms.Label Label_Val;
        private System.Windows.Forms.Label Label_Addr;
        private System.Windows.Forms.Button Btn_DecreaseVal;
        private System.Windows.Forms.Button Btn_IncreaseVal;
    }
}
