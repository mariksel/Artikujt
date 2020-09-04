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
using System.Linq.Expressions;
using System.Diagnostics;
using ArtikujtClient.Models;

namespace ArtikujtClient
{
    public partial class ArtikujtListControl : UserControl
    {
        private int currentPageIndex = 1;
        public bool IsOnDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        private Dictionary<string, Artikull> _artikujt = new Dictionary<string, Artikull>();

        public ArtikujtListControl()
        {
            InitializeComponent();

            if(!IsOnDesignMode)
                this.Load += new System.EventHandler(this.ArtikujtListControl_Load);

            if (!IsOnDesignMode)
            {
                ClientSync.Instance.Synchronized += () =>
                {
                    Reset();
                };
            }
            

        }




        private void ArtikujtListControl_Load(object sender, EventArgs e)
        {
            if (!IsOnDesignMode)
            {
                ShowArtikujtPage(1);
            }
        }

        public void AddArtikull(Artikull artikull)
        {
            BeginInvoke((Action)(() =>
            {
                var artikullItem = GenerateArtikullListItem(artikull);
                ArtikujtListPanel.Controls.Add(artikullItem);

            }));
        }

        public async void Reset(int? page = null)
        {
            if (page is null)
                page = currentPageIndex;
            await Task.Run(() =>
            {

                if (!IsOnDesignMode)
                {
                    ShowArtikujtPage(page.Value);
                }

            });
        }

        private async void ShowArtikujtPage(int page = 1)
        {
            currentPageIndex = page;
            PaginatedList<Artikull> list = null;

            using (var repo = new ArtikullRepository())
            {
                list = await repo.GetPageWithArtikuj(page);
            }

            _artikujt = new Dictionary<string, Artikull>();

            foreach (var artikull in list.Models)
            {
                _artikujt.Add(artikull.Id, artikull);
            }

            UpdateArtikujtListPanel(list);
        }

        private void UpdateArtikujtListPanel(PaginatedList<Artikull> list)
        {
            BeginInvoke((Action)(() =>
            {
                ArtikujtListPanel.Visible = false;
                var items = new List<Control>();
                foreach (var artikull in _artikujt.Values.ToArray().Reverse())
                {
                    var artikullItem = GenerateArtikullListItem(artikull);
                    items.Add(artikullItem);
                }
                ArtikujtListPanel.Controls.Clear();
                ArtikujtListPanel.Controls.AddRange(items.ToArray()); ;
                ArtikujtListPanel.Visible = true;

                this.GeneratePagingButtions(list);
            }));
        }

        private ArtikujtListItem GenerateArtikullListItem(Artikull artikull)
        {
            var artikullItem = new ArtikujtListItem(artikull);
            artikullItem.Id = artikull.Id;
            artikullItem.Emri = artikull.Emri;
            artikullItem.Cmimi = artikull.Cmimi;

            artikullItem.Dock = artikujtListItem1.Dock;
            artikullItem.Size = artikujtListItem1.Size;
            artikullItem.Padding = artikujtListItem1.Padding;

            if (artikull.IsProcessed)
                MarkArikullItemAsProcessed(artikullItem);

            artikullItem.Click += (obj, args) =>
            {
                ArtikullForm.Artikull = artikull;
            };


            return artikullItem;
        }

        private void GeneratePagingButtions(PaginatedList<Artikull> list)
        {
            PagingPanel.Controls.Clear();

            int leftMargin = 0;
            foreach (var page in list.Pages)
            {
                var button = new Button();
                button.Width = 30;
                button.Text = page.Index.ToString();
                if (page.IsActive)
                {
                    button.BackColor = Color.FromArgb(172, 198, 199);
                }
                button.Location = new Point(leftMargin, 0);
                leftMargin += 30;
                button.Font = new Font(button.Font, FontStyle.Bold);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = Color.FromArgb(172, 198, 199);
                button.Cursor = Cursors.Hand;
                button.Click += async (sender, args) =>
                {
                    Reset(page.Index);
                };
                PagingPanel.Controls.Add(button);
            }


        }

        private void MarkArikullItemAsProcessed(ArtikujtListItem item)
        {
            item.SyncButton.BackColor = Color.FromArgb(84, 152, 100);
            item.SyncButton.ForeColor = Color.White;
            item.SyncButton.Text = ProcessStatus.Processed;
        }
        private void MarkArikullItemAsUnProcessed(ArtikujtListItem item)
        {
            item.SyncButton.BackColor = artikujtListItem1.SyncButton.BackColor;
            item.SyncButton.ForeColor = artikujtListItem1.SyncButton.ForeColor;
            item.SyncButton.Text = ProcessStatus.UnProcessed;
        }

        private async void ProcesoButton_Click(object sender, EventArgs e)
        {
            using (var repo = new ArtikullRepository())
            {
                Enabled = false;
                processoProbressBar.Visible = true;
                procesoLabel.Visible = true;

                var createdartikujt = await repo.GetUnprocessedArtikujtAsync(RecordType.Insert);
                var updatedartikujt = await repo.GetUnprocessedArtikujtAsync(RecordType.Update);
                var deletedartikujt = await repo.GetUnprocessedArtikujtAsync(RecordType.Delete);
                await ClientSync.Instance.CreateArtikujtAsync(createdartikujt);
                await ClientSync.Instance.UpdateArtikujtAsync(updatedartikujt);
                await ClientSync.Instance.DeleteArtikujtAsync(deletedartikujt);

                procesoLabel.Visible = false;
                processoProbressBar.Visible = false;
                Enabled = true;

            }
        }

        
    }
}
