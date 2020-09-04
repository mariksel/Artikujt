namespace ArtikujtClient
{
    partial class ArtikullForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArtikullForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.prefixLabel = new System.Windows.Forms.Label();
            this.cmimiTextBox = new System.Windows.Forms.TextBox();
            this.BarkodLabel = new System.Windows.Forms.Label();
            this.BarkodTextBox = new System.Windows.Forms.TextBox();
            this.TipiLabel = new System.Windows.Forms.Label();
            this.TipiComboBox = new System.Windows.Forms.ComboBox();
            this.KaTvshCheckBox = new System.Windows.Forms.CheckBox();
            this.LlojGroupBox = new System.Windows.Forms.GroupBox();
            this.RadioButtonVendi = new System.Windows.Forms.RadioButton();
            this.RadioButtonImportuar = new System.Windows.Forms.RadioButton();
            this.CmimiLabel = new System.Windows.Forms.Label();
            this.DataSkadencesPicker = new System.Windows.Forms.DateTimePicker();
            this.DataSkadencesLabel = new System.Windows.Forms.Label();
            this.NjesiaLabel = new System.Windows.Forms.Label();
            this.NjesiaTextBox = new System.Windows.Forms.TextBox();
            this.EmriLabel = new System.Windows.Forms.Label();
            this.EmriTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ArtikullIRiButton = new System.Windows.Forms.Button();
            this.FshiButton = new System.Windows.Forms.Button();
            this.RuajButton = new System.Windows.Forms.Button();
            this.KerkoPanel = new System.Windows.Forms.Panel();
            this.artikujtListControl1 = new ArtikujtClient.ArtikujtListControl();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.LlojGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.KerkoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.cmimiTextBox);
            this.panel1.Controls.Add(this.BarkodLabel);
            this.panel1.Controls.Add(this.BarkodTextBox);
            this.panel1.Controls.Add(this.TipiLabel);
            this.panel1.Controls.Add(this.TipiComboBox);
            this.panel1.Controls.Add(this.KaTvshCheckBox);
            this.panel1.Controls.Add(this.LlojGroupBox);
            this.panel1.Controls.Add(this.CmimiLabel);
            this.panel1.Controls.Add(this.DataSkadencesPicker);
            this.panel1.Controls.Add(this.DataSkadencesLabel);
            this.panel1.Controls.Add(this.NjesiaLabel);
            this.panel1.Controls.Add(this.NjesiaTextBox);
            this.panel1.Controls.Add(this.EmriLabel);
            this.panel1.Controls.Add(this.EmriTextBox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(432, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 506);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.prefixLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(535, 38);
            this.panel3.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(36, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "Prefix:";
            // 
            // prefixLabel
            // 
            this.prefixLabel.AutoSize = true;
            this.prefixLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prefixLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.prefixLabel.Location = new System.Drawing.Point(101, 9);
            this.prefixLabel.Name = "prefixLabel";
            this.prefixLabel.Size = new System.Drawing.Size(16, 21);
            this.prefixLabel.TabIndex = 20;
            this.prefixLabel.Text = "-";
            // 
            // cmimiTextBox
            // 
            this.cmimiTextBox.Location = new System.Drawing.Point(306, 132);
            this.cmimiTextBox.Name = "cmimiTextBox";
            this.cmimiTextBox.Size = new System.Drawing.Size(200, 20);
            this.cmimiTextBox.TabIndex = 18;
            this.cmimiTextBox.TextChanged += new System.EventHandler(this.cmimiTextBox_TextChanged);
            this.cmimiTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmimiTextBox_KeyPress);
            // 
            // BarkodLabel
            // 
            this.BarkodLabel.AutoSize = true;
            this.BarkodLabel.Location = new System.Drawing.Point(303, 277);
            this.BarkodLabel.Name = "BarkodLabel";
            this.BarkodLabel.Size = new System.Drawing.Size(41, 13);
            this.BarkodLabel.TabIndex = 16;
            this.BarkodLabel.Text = "Barkod";
            // 
            // BarkodTextBox
            // 
            this.BarkodTextBox.Location = new System.Drawing.Point(306, 293);
            this.BarkodTextBox.Name = "BarkodTextBox";
            this.BarkodTextBox.Size = new System.Drawing.Size(200, 20);
            this.BarkodTextBox.TabIndex = 15;
            this.BarkodTextBox.TextChanged += new System.EventHandler(this.BarkodTextBox_TextChanged);
            // 
            // TipiLabel
            // 
            this.TipiLabel.AutoSize = true;
            this.TipiLabel.Location = new System.Drawing.Point(34, 276);
            this.TipiLabel.Name = "TipiLabel";
            this.TipiLabel.Size = new System.Drawing.Size(24, 13);
            this.TipiLabel.TabIndex = 14;
            this.TipiLabel.Text = "Tipi";
            // 
            // TipiComboBox
            // 
            this.TipiComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipiComboBox.FormattingEnabled = true;
            this.TipiComboBox.Location = new System.Drawing.Point(37, 292);
            this.TipiComboBox.Name = "TipiComboBox";
            this.TipiComboBox.Size = new System.Drawing.Size(200, 21);
            this.TipiComboBox.TabIndex = 13;
            this.TipiComboBox.SelectionChangeCommitted += new System.EventHandler(this.TipiComboBox_SelectionChangeCommitted);
            // 
            // KaTvshCheckBox
            // 
            this.KaTvshCheckBox.AutoSize = true;
            this.KaTvshCheckBox.Location = new System.Drawing.Point(306, 181);
            this.KaTvshCheckBox.Name = "KaTvshCheckBox";
            this.KaTvshCheckBox.Size = new System.Drawing.Size(72, 17);
            this.KaTvshCheckBox.TabIndex = 12;
            this.KaTvshCheckBox.Text = "Ka Tvsh?";
            this.KaTvshCheckBox.UseVisualStyleBackColor = true;
            this.KaTvshCheckBox.CheckedChanged += new System.EventHandler(this.KaTvshCheckBox_CheckedChanged);
            // 
            // LlojGroupBox
            // 
            this.LlojGroupBox.Controls.Add(this.RadioButtonVendi);
            this.LlojGroupBox.Controls.Add(this.RadioButtonImportuar);
            this.LlojGroupBox.Location = new System.Drawing.Point(37, 181);
            this.LlojGroupBox.Name = "LlojGroupBox";
            this.LlojGroupBox.Size = new System.Drawing.Size(200, 71);
            this.LlojGroupBox.TabIndex = 11;
            this.LlojGroupBox.TabStop = false;
            this.LlojGroupBox.Text = "Lloj";
            // 
            // RadioButtonVendi
            // 
            this.RadioButtonVendi.AutoSize = true;
            this.RadioButtonVendi.Location = new System.Drawing.Point(6, 42);
            this.RadioButtonVendi.Name = "RadioButtonVendi";
            this.RadioButtonVendi.Size = new System.Drawing.Size(52, 17);
            this.RadioButtonVendi.TabIndex = 10;
            this.RadioButtonVendi.TabStop = true;
            this.RadioButtonVendi.Text = "Vendi";
            this.RadioButtonVendi.UseVisualStyleBackColor = true;
            this.RadioButtonVendi.CheckedChanged += new System.EventHandler(this.RadioButtonLloj_CheckedChanged);
            // 
            // RadioButtonImportuar
            // 
            this.RadioButtonImportuar.AutoSize = true;
            this.RadioButtonImportuar.Location = new System.Drawing.Point(6, 19);
            this.RadioButtonImportuar.Name = "RadioButtonImportuar";
            this.RadioButtonImportuar.Size = new System.Drawing.Size(69, 17);
            this.RadioButtonImportuar.TabIndex = 9;
            this.RadioButtonImportuar.TabStop = true;
            this.RadioButtonImportuar.Text = "Importuar";
            this.RadioButtonImportuar.UseVisualStyleBackColor = true;
            this.RadioButtonImportuar.CheckedChanged += new System.EventHandler(this.RadioButtonLloj_CheckedChanged);
            // 
            // CmimiLabel
            // 
            this.CmimiLabel.AutoSize = true;
            this.CmimiLabel.Location = new System.Drawing.Point(303, 116);
            this.CmimiLabel.Name = "CmimiLabel";
            this.CmimiLabel.Size = new System.Drawing.Size(34, 13);
            this.CmimiLabel.TabIndex = 8;
            this.CmimiLabel.Text = "Cmimi";
            // 
            // DataSkadencesPicker
            // 
            this.DataSkadencesPicker.Location = new System.Drawing.Point(37, 132);
            this.DataSkadencesPicker.Name = "DataSkadencesPicker";
            this.DataSkadencesPicker.Size = new System.Drawing.Size(200, 20);
            this.DataSkadencesPicker.TabIndex = 6;
            this.DataSkadencesPicker.ValueChanged += new System.EventHandler(this.DataSkadencesPicker_ValueChanged);
            // 
            // DataSkadencesLabel
            // 
            this.DataSkadencesLabel.AutoSize = true;
            this.DataSkadencesLabel.Location = new System.Drawing.Point(34, 115);
            this.DataSkadencesLabel.Name = "DataSkadencesLabel";
            this.DataSkadencesLabel.Size = new System.Drawing.Size(87, 13);
            this.DataSkadencesLabel.TabIndex = 5;
            this.DataSkadencesLabel.Text = "Data Skadences";
            // 
            // NjesiaLabel
            // 
            this.NjesiaLabel.AutoSize = true;
            this.NjesiaLabel.Location = new System.Drawing.Point(303, 52);
            this.NjesiaLabel.Name = "NjesiaLabel";
            this.NjesiaLabel.Size = new System.Drawing.Size(36, 13);
            this.NjesiaLabel.TabIndex = 4;
            this.NjesiaLabel.Text = "Njesia";
            // 
            // NjesiaTextBox
            // 
            this.NjesiaTextBox.Location = new System.Drawing.Point(306, 68);
            this.NjesiaTextBox.Name = "NjesiaTextBox";
            this.NjesiaTextBox.Size = new System.Drawing.Size(200, 20);
            this.NjesiaTextBox.TabIndex = 3;
            this.NjesiaTextBox.TextChanged += new System.EventHandler(this.NjesiaTextBox_TextChanged);
            // 
            // EmriLabel
            // 
            this.EmriLabel.AutoSize = true;
            this.EmriLabel.Location = new System.Drawing.Point(34, 52);
            this.EmriLabel.Name = "EmriLabel";
            this.EmriLabel.Size = new System.Drawing.Size(27, 13);
            this.EmriLabel.TabIndex = 2;
            this.EmriLabel.Text = "Emri";
            // 
            // EmriTextBox
            // 
            this.EmriTextBox.Location = new System.Drawing.Point(37, 68);
            this.EmriTextBox.Name = "EmriTextBox";
            this.EmriTextBox.Size = new System.Drawing.Size(200, 20);
            this.EmriTextBox.TabIndex = 1;
            this.EmriTextBox.TextChanged += new System.EventHandler(this.EmriTextBox_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ArtikullIRiButton);
            this.panel2.Controls.Add(this.FshiButton);
            this.panel2.Controls.Add(this.RuajButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 457);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 49);
            this.panel2.TabIndex = 0;
            // 
            // ArtikullIRiButton
            // 
            this.ArtikullIRiButton.Location = new System.Drawing.Point(20, 14);
            this.ArtikullIRiButton.Name = "ArtikullIRiButton";
            this.ArtikullIRiButton.Size = new System.Drawing.Size(75, 23);
            this.ArtikullIRiButton.TabIndex = 4;
            this.ArtikullIRiButton.Text = "Artikull i ri";
            this.ArtikullIRiButton.UseVisualStyleBackColor = true;
            this.ArtikullIRiButton.Click += new System.EventHandler(this.ArtikullIRiButton_Click);
            // 
            // FshiButton
            // 
            this.FshiButton.Location = new System.Drawing.Point(182, 14);
            this.FshiButton.Name = "FshiButton";
            this.FshiButton.Size = new System.Drawing.Size(75, 23);
            this.FshiButton.TabIndex = 3;
            this.FshiButton.Text = "Fshi";
            this.FshiButton.UseVisualStyleBackColor = true;
            this.FshiButton.Click += new System.EventHandler(this.FshiButton_Click);
            // 
            // RuajButton
            // 
            this.RuajButton.Location = new System.Drawing.Point(101, 14);
            this.RuajButton.Name = "RuajButton";
            this.RuajButton.Size = new System.Drawing.Size(75, 23);
            this.RuajButton.TabIndex = 1;
            this.RuajButton.Text = "Ruaj";
            this.RuajButton.UseVisualStyleBackColor = true;
            this.RuajButton.Click += new System.EventHandler(this.RuajButton_Click);
            // 
            // KerkoPanel
            // 
            this.KerkoPanel.Controls.Add(this.artikujtListControl1);
            this.KerkoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KerkoPanel.Location = new System.Drawing.Point(0, 0);
            this.KerkoPanel.Name = "KerkoPanel";
            this.KerkoPanel.Size = new System.Drawing.Size(432, 506);
            this.KerkoPanel.TabIndex = 19;
            // 
            // artikujtListControl1
            // 
            this.artikujtListControl1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.artikujtListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artikujtListControl1.Location = new System.Drawing.Point(0, 0);
            this.artikujtListControl1.Name = "artikujtListControl1";
            this.artikujtListControl1.Size = new System.Drawing.Size(432, 506);
            this.artikujtListControl1.TabIndex = 0;
            // 
            // ArtikullForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 506);
            this.Controls.Add(this.KerkoPanel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ArtikullForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artikull";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.LlojGroupBox.ResumeLayout(false);
            this.LlojGroupBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.KerkoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button FshiButton;
        private System.Windows.Forms.Button RuajButton;
        private System.Windows.Forms.Label EmriLabel;
        private System.Windows.Forms.TextBox EmriTextBox;
        private System.Windows.Forms.DateTimePicker DataSkadencesPicker;
        private System.Windows.Forms.Label DataSkadencesLabel;
        private System.Windows.Forms.Label NjesiaLabel;
        private System.Windows.Forms.TextBox NjesiaTextBox;
        private System.Windows.Forms.Label BarkodLabel;
        private System.Windows.Forms.TextBox BarkodTextBox;
        private System.Windows.Forms.Label TipiLabel;
        private System.Windows.Forms.ComboBox TipiComboBox;
        private System.Windows.Forms.CheckBox KaTvshCheckBox;
        private System.Windows.Forms.GroupBox LlojGroupBox;
        private System.Windows.Forms.RadioButton RadioButtonVendi;
        private System.Windows.Forms.RadioButton RadioButtonImportuar;
        private System.Windows.Forms.Label CmimiLabel;
        private System.Windows.Forms.Button ArtikullIRiButton;
        private System.Windows.Forms.TextBox cmimiTextBox;
        private System.Windows.Forms.Panel KerkoPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label prefixLabel;
        private ArtikujtListControl artikujtListControl1;
    }
}