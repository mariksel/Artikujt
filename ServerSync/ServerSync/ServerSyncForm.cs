using ArtikujtClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerSync
{
    public partial class ServerSyncForm : Form
    {
        public ServerSyncForm()
        {
            InitializeComponent();
        }

        private async void ServerSyncForm_Load(object sender, EventArgs e)
        {
            UpdateCount();
        }

        private async void procesoButton_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;

            using (var repo = new ArtikullRepository())
            {
                await repo.ProcessDeletedLogs();
                await repo.ProcessInsertLogs();
                await repo.ProcessUpdateLogs();
            }

            UpdateCount();

            progressBar.Visible = false;
        }

        private async void UpdateCount()
        {
            using (var repo = new ArtikullRepository())
            {
                logsCounLabel.Text = (await repo.CountunprocessedLogs()).ToString();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateCount();
        }
    }
}
