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
    public partial class ArtikujtListControl : UserControl
    {
        private Dictionary<int, Artikull> _artikujt = new Dictionary<int, Artikull>();

        public ArtikujtListControl()
        {
            InitializeComponent();
        }

        private async void ArtikujtListControl_Load(object sender, EventArgs e)
        {
            await ShowArtikujtPage(1);
        }

        private async void Reset(int page = 1)
        {
            await Task.Run(async () => {
                await ShowArtikujtPage(page);
            });
        }

        private async Task ShowArtikujtPage(int page = 1)
        {
            PaginatedList<Artikull> list = null;

            using(var repo = new ArtikullRepository())
            {
                list = await repo.GetPageWithArtikuj(page);
            }

            _artikujt = new Dictionary<int, Artikull>();

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
                ArtikujtListPanel.Controls.Clear();
                foreach (var artikull in _artikujt.Values.ToArray().Reverse())
                {
                    var artikullItem = GenerateArtikullListItem(artikull);
                    ArtikujtListPanel.Controls.Add(artikullItem);
                }

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
                ArtikullForm.Artikull = artikull ;
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
                button.Click += async (sender, args) => {
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
                var artikujt = await repo.GetUnprocessedArtikujtAsync();
                ClientSync.Instance.SaveArtikujt(artikujt);
            }
        }

        
    }
}
