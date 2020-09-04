namespace ArtikujtClient
{
    partial class ArtikujtListControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.PagingPanel = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.refreshBUtton = new System.Windows.Forms.Button();
            this.ArtikujtListPanel = new System.Windows.Forms.Panel();
            this.artikujtListItem2 = new ArtikujtClient.ArtikujtListItem();
            this.artikujtListItem1 = new ArtikujtClient.ArtikujtListItem();
            this.panel1.SuspendLayout();
            this.PagingPanel.SuspendLayout();
            this.ArtikujtListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.PagingPanel);
            this.panel1.Controls.Add(this.refreshBUtton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 405);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(282, 49);
            this.panel1.TabIndex = 7;
            // 
            // PagingPanel
            // 
            this.PagingPanel.Controls.Add(this.progressBar1);
            this.PagingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PagingPanel.Location = new System.Drawing.Point(68, 10);
            this.PagingPanel.Name = "PagingPanel";
            this.PagingPanel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.PagingPanel.Size = new System.Drawing.Size(204, 29);
            this.PagingPanel.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(5, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(199, 29);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // refreshBUtton
            // 
            this.refreshBUtton.Dock = System.Windows.Forms.DockStyle.Left;
            this.refreshBUtton.Location = new System.Drawing.Point(10, 10);
            this.refreshBUtton.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.refreshBUtton.Name = "refreshBUtton";
            this.refreshBUtton.Size = new System.Drawing.Size(58, 29);
            this.refreshBUtton.TabIndex = 1;
            this.refreshBUtton.Text = "Refresh";
            this.refreshBUtton.UseVisualStyleBackColor = true;
            this.refreshBUtton.Click += new System.EventHandler(this.refreshBUtton_Click);
            // 
            // ArtikujtListPanel
            // 
            this.ArtikujtListPanel.AutoScroll = true;
            this.ArtikujtListPanel.Controls.Add(this.artikujtListItem2);
            this.ArtikujtListPanel.Controls.Add(this.artikujtListItem1);
            this.ArtikujtListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArtikujtListPanel.Location = new System.Drawing.Point(0, 0);
            this.ArtikujtListPanel.Name = "ArtikujtListPanel";
            this.ArtikujtListPanel.Padding = new System.Windows.Forms.Padding(3);
            this.ArtikujtListPanel.Size = new System.Drawing.Size(282, 405);
            this.ArtikujtListPanel.TabIndex = 9;
            // 
            // artikujtListItem2
            // 
            this.artikujtListItem2.Dock = System.Windows.Forms.DockStyle.Top;
            this.artikujtListItem2.Location = new System.Drawing.Point(3, 43);
            this.artikujtListItem2.Name = "artikujtListItem2";
            this.artikujtListItem2.Padding = new System.Windows.Forms.Padding(3);
            this.artikujtListItem2.Size = new System.Drawing.Size(276, 40);
            this.artikujtListItem2.TabIndex = 1;
            // 
            // artikujtListItem1
            // 
            this.artikujtListItem1.Dock = System.Windows.Forms.DockStyle.Top;
            this.artikujtListItem1.Location = new System.Drawing.Point(3, 3);
            this.artikujtListItem1.Name = "artikujtListItem1";
            this.artikujtListItem1.Padding = new System.Windows.Forms.Padding(3);
            this.artikujtListItem1.Size = new System.Drawing.Size(276, 40);
            this.artikujtListItem1.TabIndex = 0;
            // 
            // ArtikujtListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.ArtikujtListPanel);
            this.Controls.Add(this.panel1);
            this.Name = "ArtikujtListControl";
            this.Size = new System.Drawing.Size(282, 454);
            this.panel1.ResumeLayout(false);
            this.PagingPanel.ResumeLayout(false);
            this.ArtikujtListPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ArtikujtListPanel;
        private System.Windows.Forms.Panel PagingPanel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button refreshBUtton;
        private ArtikujtListItem artikujtListItem2;
        private ArtikujtListItem artikujtListItem1;
    }
}
