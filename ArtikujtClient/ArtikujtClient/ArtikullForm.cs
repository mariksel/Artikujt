using ArtikutClient.Database;
using ArtikutClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ArtikujtClient
{
    public delegate void ArtikullEventHandler(Artikull artikull);
    public partial class ArtikullForm : Form
    {
        private static event ArtikullEventHandler ArtikullChanged;
        private static Artikull _artikull = CreateNewArtikull();
        public static Artikull Artikull { 
            get => _artikull; 
            set  {
                _artikull = value;
                ArtikullChanged?.Invoke(value);
            }
        } 

        public static Artikull CreateNewArtikull()
        {
            var artikull = new Artikull { IsNew = true };
            Artikull = artikull;
            return artikull;
        }

        public ArtikullForm()
        {
            InitializeComponent();

            ArtikullChanged += OnArtikullChanged;

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

        private void OnArtikullChanged(Artikull artikull)
        {
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

        private async void RuajButton_Click(object sender, EventArgs e)
        {
            try
            {
                IsOnValidState(Artikull);
            } catch(ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Probleme me artikullin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var repo = new ArtikullRepository())
            {
                var currentArtikull = Artikull;
                try
                {
                    currentArtikull.OnSave();

                    await repo.RuajArtikullAsync(currentArtikull);
                    MessageBox.Show(this, "Artikulli u ruajt me sukses", "Suksess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (currentArtikull.IsNew)
                    {
                        currentArtikull.IsNew = false;
                        artikujtListControl1.AddArtikull(currentArtikull);
                    }

                    CreateNewArtikull();
                    Reset();

                    await ClientSync.Instance.SaveArtikujtAsync(currentArtikull);

                }
                catch (DbEntityValidationException ex)
                {
                    MessageBox.Show(this, ex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage, 
                        "Probleme me artikullin", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                } catch(Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                currentArtikull.OnSave(false);

            }
        }

        private async void FshiButton_Click(object sender, EventArgs e)
        {
            using (var repo = new ArtikullRepository())
            {
                try
                {
                    await repo.FshiArtikullAsync(Artikull);
                    await ClientSync.Instance.DeleteArtikujtAsync(Artikull);
                } 
                catch (Exception ex){
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(this, $"Artikulli {Artikull.Emri} u fshi me sukses", "Suksess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CreateNewArtikull();
                Reset();


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
            string num = cmimiTextBox.Text;
            num = num.Replace(',', '.');
            num = num.TrimEnd('.');
            if (!string.IsNullOrEmpty(num)){
                if (double.TryParse(num, out double cmimi))
                    Artikull.Cmimi = cmimi;
                else
                    cmimiTextBox.Text = Artikull.Cmimi.ToString();
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
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.' || e.KeyChar == ','))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if ((e.KeyChar == '.' || e.KeyChar == ',') && HasDecimpaPoint(txtDecimal.Text) 
                || e.KeyChar == 'e')
            {
                e.Handled = true;
            }

        }

        private bool HasDecimpaPoint(string value)
        {
            return value.Contains(".") || value.Contains(",");
        }

        private void cmimiTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
            if (e.KeyChar == '-')
                e.Handled = true;
        }
    }
}
