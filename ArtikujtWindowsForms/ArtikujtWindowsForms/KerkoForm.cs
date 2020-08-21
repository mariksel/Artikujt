using ArtikujtMVC.Database;
using ArtikujtMVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ArtikujtWindowsForms
{
    public partial class KerkoForm : Form
    {
        public KerkoForm()
        {
            InitializeComponent();
            

        }



        private Dictionary<int, Artikull> _artikujt = new Dictionary<int, Artikull>();


        private async void Reset(int page = 1)
        {
            await Task.Run(async () => {
                await InitializeViewList(page);
            });
        }

        public void Open()
        {
            Show();
            Reset();
        }

        private async Task InitializeViewList(int page = 1)
        {
            var list = await GetPageWithArtikuj(page);

            _artikujt = new Dictionary<int, Artikull>();

            foreach (var artikull in list.Models)
            {
                _artikujt.Add(artikull.Id, artikull);
            }
            BeginInvoke((Action)(() =>
            {
                ArtikujtListView.Items.Clear();
                foreach (var kvp in _artikujt)
                {
                    var artikull = kvp.Value;

                    string[] row = { artikull.Id.ToString(), artikull.Emri, artikull.Cmimi.ToString() };
                    var item = new ListViewItem();
                    item.SubItems.Add(artikull.Id.ToString());
                    item.SubItems.Add(artikull.Emri);
                    item.SubItems.Add(artikull.Cmimi.ToString("F99").TrimEnd('0').TrimEnd('.'));
                    ArtikujtListView.Items.Add(item);
                }

                this.GeneratePagingButtions(list);
            }));
            
        }

        private void GeneratePagingButtions(PaginatedList<Artikull> list)
        {
            PagingPanel.Controls.Clear();

            int leftMargin = 0;
            foreach(var page in list.Pages)
            {
                var button = new Button();
                button.Width = 30;
                button.Text = page.Index.ToString();
                if (page.IsActive)
                {
                    button.BackColor = Color.FromArgb(172,198,199);
                }
                button.Location = new Point(leftMargin, 0 );
                leftMargin += 30;
                button.Font = new Font(button.Font, FontStyle.Bold);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = Color.FromArgb(172, 198, 199);
                button.Cursor = Cursors.Hand;
                button.Click += async (sender, args ) => {
                    Reset(page.Index);
                };
                PagingPanel.Controls.Add(button);
            }

            
        }

        private void PagingButton_Click(object sender, EventArgs e)
        {
            Program.ArtikullForm.Show();
            Hide();
        }

        private void DilButton_Click(object sender, EventArgs e)
        {
            ArtikullForm.CreateNewArtikull();
            Program.ArtikullForm.Open();
            Hide();
        }

        private Artikull _selectedArtikull = null;
        private void ArtikujtListView_MouseClick(object sender, MouseEventArgs e)
        {
            var item = ((ListView)sender).SelectedItems[0];
            var id = int.Parse(item.SubItems[1].Text);
            _selectedArtikull = _artikujt[id];
            ArtikullForm.Artikull = _selectedArtikull;

            navigateToArtikullForm();
        }

        private void navigateToArtikullForm()
        {
            Program.ArtikullForm.Open();
            Hide();
        }

        private async Task<PaginatedList<Artikull>> GetPageWithArtikuj(int index = 1)
        {
            index = Math.Max(index, 1);
            int pageSize = 10;

            Artikull[] artikujt = null;

            int numberOfPages = 0;

            using (var context = new ApplicationDBContext())
            {
                artikujt = await context.Artikujt
                                .OrderByDescending(a => a.Id)
                               .Skip((index - 1) * pageSize).
                               Take(pageSize).ToArrayAsync();

                int totalCount = context.Artikujt.Count();
                numberOfPages = (int)Math.Ceiling(totalCount * 1.0 / pageSize);

            }

            return new PaginatedList<Artikull>(artikujt, numberOfPages, index);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Program.ArtikullForm.Close();
        }
    }
}
