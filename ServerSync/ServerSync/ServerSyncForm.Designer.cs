namespace ServerSync
{
    partial class ServerSyncForm
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
            this.procesoButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.logsCounLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.refreshButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // procesoButton
            // 
            this.procesoButton.Location = new System.Drawing.Point(98, 35);
            this.procesoButton.Name = "procesoButton";
            this.procesoButton.Size = new System.Drawing.Size(75, 23);
            this.procesoButton.TabIndex = 0;
            this.procesoButton.Text = "Proceso";
            this.procesoButton.UseVisualStyleBackColor = true;
            this.procesoButton.Click += new System.EventHandler(this.procesoButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.refreshButton);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.procesoButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 187);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(406, 70);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Numri i XML logs te pa procesuar:";
            // 
            // logsCounLabel
            // 
            this.logsCounLabel.AutoSize = true;
            this.logsCounLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logsCounLabel.Location = new System.Drawing.Point(286, 13);
            this.logsCounLabel.Name = "logsCounLabel";
            this.logsCounLabel.Size = new System.Drawing.Size(19, 21);
            this.logsCounLabel.TabIndex = 3;
            this.logsCounLabel.Text = "0";
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.Location = new System.Drawing.Point(5, 5);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(396, 12);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(17, 35);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // ServerSyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 257);
            this.Controls.Add(this.logsCounLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "ServerSyncForm";
            this.Text = "Server Sync";
            this.Load += new System.EventHandler(this.ServerSyncForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button procesoButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label logsCounLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button refreshButton;
    }
}

