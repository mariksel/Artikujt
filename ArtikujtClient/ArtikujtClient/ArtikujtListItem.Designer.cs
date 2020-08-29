namespace ArtikujtClient
{
    partial class ArtikujtListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.idLabel = new System.Windows.Forms.Label();
            this.innerPlanel = new System.Windows.Forms.Panel();
            this.cmimiLabel = new System.Windows.Forms.Label();
            this.emriLabel = new System.Windows.Forms.Label();
            this.syncButton = new System.Windows.Forms.Button();
            this.innerPlanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.idLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.idLabel.Location = new System.Drawing.Point(0, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Padding = new System.Windows.Forms.Padding(7, 5, 5, 5);
            this.idLabel.Size = new System.Drawing.Size(42, 38);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "Id";
            this.idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // innerPlanel
            // 
            this.innerPlanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.innerPlanel.Controls.Add(this.cmimiLabel);
            this.innerPlanel.Controls.Add(this.emriLabel);
            this.innerPlanel.Controls.Add(this.idLabel);
            this.innerPlanel.Controls.Add(this.syncButton);
            this.innerPlanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerPlanel.Location = new System.Drawing.Point(3, 3);
            this.innerPlanel.Margin = new System.Windows.Forms.Padding(10);
            this.innerPlanel.Name = "innerPlanel";
            this.innerPlanel.Size = new System.Drawing.Size(394, 38);
            this.innerPlanel.TabIndex = 4;
            // 
            // cmimiLabel
            // 
            this.cmimiLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmimiLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmimiLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.cmimiLabel.Location = new System.Drawing.Point(279, 0);
            this.cmimiLabel.Margin = new System.Windows.Forms.Padding(5);
            this.cmimiLabel.Name = "cmimiLabel";
            this.cmimiLabel.Padding = new System.Windows.Forms.Padding(7);
            this.cmimiLabel.Size = new System.Drawing.Size(80, 38);
            this.cmimiLabel.TabIndex = 5;
            this.cmimiLabel.Text = "Cmimi";
            this.cmimiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // emriLabel
            // 
            this.emriLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emriLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emriLabel.Location = new System.Drawing.Point(42, 0);
            this.emriLabel.Name = "emriLabel";
            this.emriLabel.Padding = new System.Windows.Forms.Padding(5);
            this.emriLabel.Size = new System.Drawing.Size(317, 38);
            this.emriLabel.TabIndex = 4;
            this.emriLabel.Text = "Emri";
            this.emriLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // syncButton
            // 
            this.syncButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.syncButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.syncButton.FlatAppearance.BorderSize = 0;
            this.syncButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.syncButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncButton.ForeColor = System.Drawing.Color.Gray;
            this.syncButton.Location = new System.Drawing.Point(359, 0);
            this.syncButton.Margin = new System.Windows.Forms.Padding(0);
            this.syncButton.Name = "syncButton";
            this.syncButton.Size = new System.Drawing.Size(35, 38);
            this.syncButton.TabIndex = 3;
            this.syncButton.Text = "U";
            this.syncButton.UseVisualStyleBackColor = false;
            this.syncButton.Click += new System.EventHandler(this.syncButton_Click);
            // 
            // ArtikujtListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.innerPlanel);
            this.Name = "ArtikujtListItem";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(400, 44);
            this.innerPlanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Panel innerPlanel;
        private System.Windows.Forms.Label emriLabel;
        private System.Windows.Forms.Label cmimiLabel;
        private System.Windows.Forms.Button syncButton;
    }
}
