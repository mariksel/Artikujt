using ArtikujtMVC.Database;
using ArtikujtMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ArtikujtWindowsForms
{
    public partial class ArtikullForm : Form
    {
        public static Artikull Artikull = CreateNewArtikull();

        public static Artikull CreateNewArtikull()
        {
            var artikull = new Artikull { IsNew = true };
            Artikull = artikull;
            return artikull;
        }

        public ArtikullForm()
        {
            InitializeComponent();

            TipiComboBox.DataSource = new string[] { 
                Tipi.Ushqimore,
                Tipi.Bulmet,
                Tipi.Pije,
                Tipi.Embelsire,
            };
            TipiComboBox.SelectedItem = null;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Reset();
        }

        private void Reset()
        {
            if (!Artikull.IsNew)
            {
                EmriTextBox.Text = Artikull.Emri;
                NjesiaTextBox.Text = Artikull.Njesia;
                DataSkadencesPicker.Value = Artikull.DataSkadences;
                cmimiTextBox.Text = Artikull.Cmimi.ToString("F99").TrimEnd('0').TrimEnd('.');
                RadioButtonImportuar.Checked = Artikull.Lloj == Lloj.Importuar;
                RadioButtonVendi.Checked = Artikull.Lloj == Lloj.Vendi;
                KaTvshCheckBox.Checked = Artikull.KaTvsh;
                TipiComboBox.SelectedItem = Artikull.Tipi;
                BarkodTextBox.Text = Artikull.Barkod;
            } else
            {
                EmriTextBox.Text = "";
                NjesiaTextBox.Text = "";
                DataSkadencesPicker.Value = DateTime.Now;
                cmimiTextBox.Text = "";
                RadioButtonImportuar.Checked = false;
                RadioButtonVendi.Checked = false;
                KaTvshCheckBox.Checked = false;
                TipiComboBox.SelectedItem = null;
                BarkodTextBox.Text = "";
            }

            FshiButton.Visible = !Artikull.IsNew;
        }

        public void Open()
        {
            Show();
            Reset();
        }
        private void KerkoButton_Click(object sender, EventArgs e)
        {
            Program.KerkoForm.Open();
            Hide();
        }

        private void RuajButton_Click(object sender, EventArgs e)
        {
            try
            {
                IsOnValidState(Artikull);
            } catch(ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Probleme me artikullin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new ApplicationDBContext())
            {

                context.Artikujt.AddOrUpdate(Artikull);
                var rowsNr = context.SaveChanges();
                if (rowsNr > 0)
                {
                    MessageBox.Show(this, "Artikulli u ruajt me sukses", "Suksess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Artikull.IsNew)
                    {
                        CreateNewArtikull();
                        Reset();
                    }
                }

            }
        }

        private async void FshiButton_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDBContext())
            {
                var artikull = await context.Artikujt.FindAsync(Artikull.Id);
                if (artikull == null)
                {
                    MessageBox.Show(this, $"Artikulli {artikull.Emri} nuk u gjet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                context.Artikujt.Remove(artikull);
                var rowsNr = await context.SaveChangesAsync();
                if (rowsNr > 0)
                {
                    MessageBox.Show(this, $"Artikulli {artikull.Emri} u fshi me sukses", "Suksess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CreateNewArtikull();
                    Reset();
                }

            }
        }

        private void IsOnValidState(Artikull artikull)
        {
            if (string.IsNullOrWhiteSpace(artikull.Emri))
                throw new ArgumentException($"{nameof(artikull.Emri)} duhet plotesuar");
            if (string.IsNullOrWhiteSpace(artikull.Njesia))
                throw new ArgumentException($"{nameof(artikull.Njesia)} duhet plotesuar");
            if (artikull.Cmimi < 0)
                throw new ArgumentException($"{nameof(artikull.Cmimi)} nuk mund te jete numer negativ");
            if (string.IsNullOrWhiteSpace(artikull.Lloj))
                throw new ArgumentException($"{nameof(artikull.Lloj)} duhet plotesuar");
            if (string.IsNullOrWhiteSpace(artikull.Tipi))
                throw new ArgumentException($"{nameof(artikull.Tipi)} duhet plotesuar");
            if (string.IsNullOrWhiteSpace(artikull.Barkod))
                throw new ArgumentException($"{nameof(artikull.Barkod)} duhet plotesuar");
        }


        // Bindings
        private void TipiComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Artikull.Tipi = (string)((ComboBox)sender).SelectedItem;
        }

        private void EmriTextBox_TextChanged(object sender, EventArgs e)
        {
            Artikull.Emri = EmriTextBox.Text;
        }

        private void NjesiaTextBox_TextChanged(object sender, EventArgs e)
        {
            Artikull.Njesia = NjesiaTextBox.Text;
        }

        private void DataSkadencesPicker_ValueChanged(object sender, EventArgs e)
        {
            Artikull.DataSkadences = DataSkadencesPicker.Value;
        }


        private void cmimiTextBox_TextChanged(object sender, EventArgs e)
        {
            Artikull.Cmimi = 0;
            if (!string.IsNullOrEmpty(cmimiTextBox.Text)){
                Artikull.Cmimi = double.Parse(cmimiTextBox.Text);
            }
        }

        private void RadioButtonLloj_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioButtonImportuar.Checked)
                Artikull.Lloj = Lloj.Importuar;
            else if(RadioButtonVendi.Checked)
                Artikull.Lloj = Lloj.Vendi;
        }

        private void KaTvshCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Artikull.KaTvsh = KaTvshCheckBox.Checked;
        }

        private void BarkodTextBox_TextChanged(object sender, EventArgs e)
        {
            Artikull.Barkod = BarkodTextBox.Text;
        }

        private void ArtikullIRiButton_Click(object sender, EventArgs e)
        {
            CreateNewArtikull();
            Reset();
        }

        public void onlynumwithsinglepoint(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void cmimiTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
            if (e.KeyChar == '-')
                e.Handled = true;
        }


    }
}
