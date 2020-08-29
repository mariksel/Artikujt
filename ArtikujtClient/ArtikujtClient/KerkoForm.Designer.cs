namespace ArtikujtClient
{
    partial class KerkoForm
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
            System.Windows.Forms.ColumnHeader IdColumn;
            this.DilButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ArtikujtListView = new System.Windows.Forms.ListView();
            this.FirstColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmriColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CmimiColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.PagingPanel = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            IdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PagingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // IdColumn
            // 
            IdColumn.Text = "Id";
            IdColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DilButton
            // 
            this.DilButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DilButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.DilButton.Location = new System.Drawing.Point(12, 13);
            this.DilButton.Name = "DilButton";
            this.DilButton.Size = new System.Drawing.Size(75, 23);
            this.DilButton.TabIndex = 1;
            this.DilButton.Text = "Dil";
            this.DilButton.UseVisualStyleBackColor = true;
            this.DilButton.Click += new System.EventHandler(this.DilButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ArtikujtListView);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 344);
            this.panel1.TabIndex = 2;
            // 
            // ArtikujtListView
            // 
            this.ArtikujtListView.AutoArrange = false;
            this.ArtikujtListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ArtikujtListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FirstColumn,
            IdColumn,
            this.EmriColumn,
            this.CmimiColumn});
            this.ArtikujtListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArtikujtListView.FullRowSelect = true;
            this.ArtikujtListView.GridLines = true;
            this.ArtikujtListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ArtikujtListView.Location = new System.Drawing.Point(0, 0);
            this.ArtikujtListView.MultiSelect = false;
            this.ArtikujtListView.Name = "ArtikujtListView";
            this.ArtikujtListView.Size = new System.Drawing.Size(540, 296);
            this.ArtikujtListView.TabIndex = 1;
            this.ArtikujtListView.UseCompatibleStateImageBehavior = false;
            this.ArtikujtListView.View = System.Windows.Forms.View.Details;
            this.ArtikujtListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ArtikujtListView_MouseClick);
            // 
            // FirstColumn
            // 
            this.FirstColumn.Text = "";
            this.FirstColumn.Width = 0;
            // 
            // EmriColumn
            // 
            this.EmriColumn.Text = "Emri";
            this.EmriColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EmriColumn.Width = 100;
            // 
            // CmimiColumn
            // 
            this.CmimiColumn.Text = "Cmimi";
            this.CmimiColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CmimiColumn.Width = 100;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PagingPanel);
            this.panel2.Controls.Add(this.DilButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 296);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(540, 48);
            this.panel2.TabIndex = 0;
            // 
            // PagingPanel
            // 
            this.PagingPanel.Controls.Add(this.progressBar1);
            this.PagingPanel.Location = new System.Drawing.Point(119, 13);
            this.PagingPanel.Name = "PagingPanel";
            this.PagingPanel.Size = new System.Drawing.Size(270, 23);
            this.PagingPanel.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressBar1.Location = new System.Drawing.Point(3, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(130, 17);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // KerkoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 344);
            this.Controls.Add(this.panel1);
            this.Name = "KerkoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kerko";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.PagingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DilButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView ArtikujtListView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader FirstColumn;
        private System.Windows.Forms.ColumnHeader EmriColumn;
        private System.Windows.Forms.ColumnHeader CmimiColumn;
        private System.Windows.Forms.Panel PagingPanel;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}