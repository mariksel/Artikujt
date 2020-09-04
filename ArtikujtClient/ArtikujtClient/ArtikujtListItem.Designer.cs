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
            this.components = new System.ComponentModel.Container();
            this.idLabel = new System.Windows.Forms.Label();
            this.innerPlanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.deletedLabel = new System.Windows.Forms.Label();
            this.emriLabel = new System.Windows.Forms.Label();
            this.cmimiLabel = new System.Windows.Forms.Label();
            this.syncButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.innerPlanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.idLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.idLabel.Location = new System.Drawing.Point(0, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Padding = new System.Windows.Forms.Padding(7, 5, 5, 5);
            this.idLabel.Size = new System.Drawing.Size(102, 54);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "Id";
            this.idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.idLabel.Click += new System.EventHandler(this.idLabel_Click);
            // 
            // innerPlanel
            // 
            this.innerPlanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.innerPlanel.Controls.Add(this.contentPanel);
            this.innerPlanel.Controls.Add(this.syncButton);
            this.innerPlanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerPlanel.Location = new System.Drawing.Point(3, 3);
            this.innerPlanel.Margin = new System.Windows.Forms.Padding(10);
            this.innerPlanel.Name = "innerPlanel";
            this.innerPlanel.Size = new System.Drawing.Size(567, 54);
            this.innerPlanel.TabIndex = 4;
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.deletedLabel);
            this.contentPanel.Controls.Add(this.emriLabel);
            this.contentPanel.Controls.Add(this.cmimiLabel);
            this.contentPanel.Controls.Add(this.idLabel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(532, 54);
            this.contentPanel.TabIndex = 6;
            // 
            // deletedLabel
            // 
            this.deletedLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.deletedLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletedLabel.ForeColor = System.Drawing.Color.LightCoral;
            this.deletedLabel.Location = new System.Drawing.Point(41, 11);
            this.deletedLabel.Margin = new System.Windows.Forms.Padding(0);
            this.deletedLabel.Name = "deletedLabel";
            this.deletedLabel.Padding = new System.Windows.Forms.Padding(6);
            this.deletedLabel.Size = new System.Drawing.Size(474, 37);
            this.deletedLabel.TabIndex = 6;
            this.deletedLabel.Text = "Artikulli eshte fshire";
            this.deletedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deletedLabel.Visible = false;
            // 
            // emriLabel
            // 
            this.emriLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.emriLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emriLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emriLabel.Location = new System.Drawing.Point(102, 0);
            this.emriLabel.Name = "emriLabel";
            this.emriLabel.Padding = new System.Windows.Forms.Padding(5);
            this.emriLabel.Size = new System.Drawing.Size(339, 54);
            this.emriLabel.TabIndex = 4;
            this.emriLabel.Text = "Emri";
            this.emriLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.emriLabel.Click += new System.EventHandler(this.emriLabel_Click);
            // 
            // cmimiLabel
            // 
            this.cmimiLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmimiLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmimiLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmimiLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.cmimiLabel.Location = new System.Drawing.Point(441, 0);
            this.cmimiLabel.Margin = new System.Windows.Forms.Padding(5);
            this.cmimiLabel.Name = "cmimiLabel";
            this.cmimiLabel.Padding = new System.Windows.Forms.Padding(7);
            this.cmimiLabel.Size = new System.Drawing.Size(91, 54);
            this.cmimiLabel.TabIndex = 5;
            this.cmimiLabel.Text = "Cmimi";
            this.cmimiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmimiLabel.Click += new System.EventHandler(this.cmimiLabel_Click);
            // 
            // syncButton
            // 
            this.syncButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.syncButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.syncButton.FlatAppearance.BorderSize = 0;
            this.syncButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.syncButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncButton.ForeColor = System.Drawing.Color.Gray;
            this.syncButton.Location = new System.Drawing.Point(532, 0);
            this.syncButton.Margin = new System.Windows.Forms.Padding(0);
            this.syncButton.Name = "syncButton";
            this.syncButton.Size = new System.Drawing.Size(35, 54);
            this.syncButton.TabIndex = 3;
            this.syncButton.Text = "U";
            this.syncButton.UseVisualStyleBackColor = false;
            this.syncButton.Click += new System.EventHandler(this.syncButton_Click);
            this.syncButton.MouseHover += new System.EventHandler(this.syncButton_MouseHover);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(3, 54);
            this.progressBar.MarqueeAnimationSpeed = 10;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(567, 3);
            this.progressBar.Step = 20;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 3000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 20;
            this.toolTip1.Tag = "";
            // 
            // ArtikujtListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.innerPlanel);
            this.Name = "ArtikujtListItem";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(573, 60);
            this.innerPlanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Panel innerPlanel;
        private System.Windows.Forms.Label emriLabel;
        private System.Windows.Forms.Label cmimiLabel;
        private System.Windows.Forms.Button syncButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label deletedLabel;
    }
}
