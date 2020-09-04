using ServerSync;
using ServerSync.Models;
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
        public static Configuration Configuration { get; set; }
        public ServerSyncForm()
        {
            InitializeComponent();

            prefixLabel.Text = Configuration.Prefix;
        }

        private void ServerSyncForm_Load(object sender, EventArgs e)
        {
            UpdateCount();
        }

        private async void procesoButton_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;

            try
            {
                using (var repo = new ArtikullRepository())
                {
                    await repo.ProcessArtikullLogs();
                    //await repo.ProcessDeletedLogs();
                    //await repo.ProcessInsertLogs();
                    //await repo.ProcessUpdateLogs();
                }
            } catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
