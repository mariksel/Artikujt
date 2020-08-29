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

namespace ArtikujtClient
{
    public partial class ArtikujtListItem : UserControl
    {
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
        public ArtikujtListItem(Artikull artikull)
        {
            Artikull = artikull;
            InitializeComponent();
        }


        private void syncButton_Click(object sender, EventArgs e)
        {
            if (!Artikull.IsProcessed)
            {
                this.Enabled = false;
            }
        }
    }
}
