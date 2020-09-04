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
                ArtikullService.Instance.ServiceChange += () =>
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
                button.Height = 28;
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

        private void processoProbressBar_Click(object sender, EventArgs e)
        {
                    }

        private void refreshBUtton_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
