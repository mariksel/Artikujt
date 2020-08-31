using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArtikutClient.Models;
using ChangeDetector;

namespace ArtikujtClient
{

    public partial class ArtikujtListItem : UserControl
    {
        public bool IsOnDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public Artikull Artikull { get; }
        public Label IdLabel => idLabel;
        public Label EmriLabel => emriLabel;
        public Label CmimiLabel => cmimiLabel;
        public Button SyncButton => syncButton;

        public int Id {
            set => IdLabel.Text = value.ToString();
        }
        public string Emri
        {
            set => EmriLabel.Text = value;
        }
        public double Cmimi
        {
            set => CmimiLabel.Text = value.ToString("F99").TrimEnd('0').TrimEnd('.') + " LEK";
        }
        public ArtikujtListItem()
        {
            InitializeComponent();
        }
        private Color _syncButtonBackColor;
        private Color _syncButtonForeColor;
        private Cursor _defaultCursor;
        public ArtikujtListItem(Artikull artikull)
        {
            Artikull = artikull;
            InitializeComponent();

            if(!IsOnDesignMode)
                this.SizeChanged += new System.EventHandler(this.ArtikujtListItem_SizeChanged);

            if (Artikull.IsDeleted)
                deletedLabel.Visible = true;
            OnProcess(Artikull.IsProcessing);

            _syncButtonBackColor = syncButton.BackColor;
            _syncButtonForeColor = syncButton.ForeColor;
            _defaultCursor = Cursor;

            artikull.CmimiChanged += (cmimi) =>  Cmimi = cmimi;
            artikull.EmriChanged += (emri) =>  Emri = emri;
            artikull.ProcessStatusChanged += (status) =>
            {
                if (status == ProcessStatus.Processed)
                    MarkAsProcessed();
                else
                    MarkAsUnProcessed();
            };
            artikull.Saving += (isSaving) =>
            {
                OnProcess(isSaving);
            };

            artikull.IsDeletedChanged += (isDeleted) =>
            {
                if (isDeleted)
                    deletedLabel.Visible = true;
            };

        }

        private void MarkAsProcessed()
        {
            BeginInvoke((Action)(() =>
            {
                syncButton.BackColor = Color.FromArgb(84, 152, 100);
                syncButton.ForeColor = Color.White;
                syncButton.Text = ProcessStatus.Processed;
            }));
            
        }
        private void MarkAsUnProcessed()
        {
            BeginInvoke((Action)(() =>
            {
                syncButton.BackColor = _syncButtonBackColor;
                syncButton.ForeColor = _syncButtonForeColor;
                syncButton.Text = ProcessStatus.UnProcessed;
            }));
        }




        private async void syncButton_Click(object sender, EventArgs e)
        {
            if (!Artikull.IsProcessed)
            {
                OnProcess();
                if (Artikull.IsDeleted)
                {
                    await ClientSync.Instance.DeleteArtikujtAsync(Artikull);
                }
                else
                {
                    await ClientSync.Instance.SaveArtikujtAsync(Artikull);
                }
                OnProcess(false);
            }
        }

        private void emriLabel_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void idLabel_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void cmimiLabel_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void ArtikujtListItem_SizeChanged(object sender, EventArgs e)
        {
            var newSize = CmimiLabel.Size;

            newSize.Width = (Size.Width - 100) / 2;
            CmimiLabel.Size = newSize;
            deletedLabel.Size = contentPanel.Size+ new Size(3,3);
            deletedLabel.Location = contentPanel.Location;
        }

        public void OnProcess(bool isPorcessing = true)
        {
            this.Enabled = !isPorcessing;
            progressBar.Visible = isPorcessing;
        }

        private void syncButton_MouseHover(object sender, EventArgs e)
        {
            var message = "Un Processed";
            if (Artikull.IsProcessed)
                message = "Processed";

            toolTip1.Show(message, syncButton);
        }
    }
}
