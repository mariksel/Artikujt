using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArtikujtServerUI.Models;
using ChangeDetector;
using ArtikujtClient.Models;

namespace ArtikujtClient
{

    public partial class ArtikujtListItem : UserControl
    {
        public bool IsOnDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime;


        public static Color[] Colors = new Color[] { 
            Color.FromArgb(233,65,40),
            Color.FromArgb(241,130,41),
            Color.FromArgb(237,213,105),
            Color.FromArgb(69,137,85),
            Color.FromArgb(63,98,143),


        };

        public Artikull Artikull { get; }
        public Label IdLabel => idLabel;
        public Label EmriLabel => emriLabel;
        public Label CmimiLabel => cmimiLabel;

        public string Id {
            set => IdLabel.Text = value;
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

        private Cursor _defaultCursor;
        public ArtikujtListItem(Artikull artikull)
        {
            Artikull = artikull;
            InitializeComponent();

            if(!IsOnDesignMode)
                this.SizeChanged += new System.EventHandler(this.ArtikujtListItem_SizeChanged);




            _defaultCursor = Cursor;

            artikull.CmimiChanged += (cmimi) =>  Cmimi = cmimi;
            artikull.EmriChanged += (emri) =>  Emri = emri;
 
            artikull.Saving += (isSaving) =>
            {
                OnProcess(isSaving);
            };

            if (!artikull.IsMyArtikull)
            {
               innerPlanel.BackColor = Color.WhiteSmoke;
                idLabel.Cursor = Cursors.Default;
                emriLabel.Cursor = Cursors.Default;
                cmimiLabel.Cursor = Cursors.Default;
                colorLabel.BackColor = GetColor(artikull.Prefix);
            }

        }


        public static Color GetColor(string prefix)
        {
            var index = Math.Abs( prefix.GetHashCode()) % Colors.Length;
            return Colors[index];
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

        }

        public void OnProcess(bool isPorcessing = true)
        {
            this.Enabled = !isPorcessing;

        }


    }
}
