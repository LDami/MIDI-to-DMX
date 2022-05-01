
namespace DMX_MIDI
{
	partial class LightTriggerControl
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
            this.Label_Name = new System.Windows.Forms.Label();
            this.Label_Type = new System.Windows.Forms.Label();
            this.Btn_Edit = new System.Windows.Forms.Button();
            this.Label_Event = new System.Windows.Forms.Label();
            this.Rect_PrimaryColor = new System.Windows.Forms.FlowLayoutPanel();
            this.Rect_SecondaryColor = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Name.Location = new System.Drawing.Point(29, 13);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(68, 25);
            this.Label_Name.TabIndex = 0;
            this.Label_Name.Text = "Name";
            // 
            // Label_Type
            // 
            this.Label_Type.AutoSize = true;
            this.Label_Type.Location = new System.Drawing.Point(44, 47);
            this.Label_Type.Name = "Label_Type";
            this.Label_Type.Size = new System.Drawing.Size(27, 13);
            this.Label_Type.TabIndex = 1;
            this.Label_Type.Text = "type";
            // 
            // Btn_Edit
            // 
            this.Btn_Edit.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Edit.FlatAppearance.BorderSize = 0;
            this.Btn_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Edit.Location = new System.Drawing.Point(84, 62);
            this.Btn_Edit.Name = "Btn_Edit";
            this.Btn_Edit.Size = new System.Drawing.Size(35, 19);
            this.Btn_Edit.TabIndex = 2;
            this.Btn_Edit.Text = "Edit";
            this.Btn_Edit.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Btn_Edit.UseVisualStyleBackColor = false;
            this.Btn_Edit.Click += new System.EventHandler(this.Btn_Edit_Click);
            // 
            // Label_Event
            // 
            this.Label_Event.AutoSize = true;
            this.Label_Event.Location = new System.Drawing.Point(44, 60);
            this.Label_Event.Name = "Label_Event";
            this.Label_Event.Size = new System.Drawing.Size(34, 13);
            this.Label_Event.TabIndex = 3;
            this.Label_Event.Text = "event";
            // 
            // Rect_PrimaryColor
            // 
            this.Rect_PrimaryColor.Location = new System.Drawing.Point(4, 47);
            this.Rect_PrimaryColor.Name = "Rect_PrimaryColor";
            this.Rect_PrimaryColor.Size = new System.Drawing.Size(13, 13);
            this.Rect_PrimaryColor.TabIndex = 4;
            // 
            // Rect_SecondaryColor
            // 
            this.Rect_SecondaryColor.Location = new System.Drawing.Point(4, 66);
            this.Rect_SecondaryColor.Name = "Rect_SecondaryColor";
            this.Rect_SecondaryColor.Size = new System.Drawing.Size(13, 13);
            this.Rect_SecondaryColor.TabIndex = 5;
            // 
            // LightTriggerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Rect_SecondaryColor);
            this.Controls.Add(this.Rect_PrimaryColor);
            this.Controls.Add(this.Label_Event);
            this.Controls.Add(this.Btn_Edit);
            this.Controls.Add(this.Label_Type);
            this.Controls.Add(this.Label_Name);
            this.Name = "LightTriggerControl";
            this.Size = new System.Drawing.Size(122, 84);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Label_Name;
		private System.Windows.Forms.Label Label_Type;
		private System.Windows.Forms.Button Btn_Edit;
        private System.Windows.Forms.Label Label_Event;
        private System.Windows.Forms.FlowLayoutPanel Rect_PrimaryColor;
        private System.Windows.Forms.FlowLayoutPanel Rect_SecondaryColor;
    }
}
