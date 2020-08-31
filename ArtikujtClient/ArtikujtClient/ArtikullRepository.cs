using ArtikujtClient.Models;
using ArtikutClient.Database;
using ArtikutClient.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtikujtClient
{
    public class ArtikullRepository: ApplicationDBContext
    {
        public Configuration GetConfiguration()
        {
            return  Configurations.FirstOrDefault();

        }

        public async Task<PaginatedList<Artikull>> GetPageWithArtikuj(int index = 1)
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

        public async Task RuajArtikullAsync(Artikull artikull)
        {
            artikull.ProcessStatus = ProcessStatus.UnProcessed;
            Artikujt.AddOrUpdate(artikull);

            await SaveChangesAsync();

        }

        public async Task FshiArtikullAsync(Artikull artikull)
        {

            var currentArtikull = await Artikujt.FindAsync(artikull.Id);
            if (currentArtikull == null)
            {
                throw new ArgumentException($"Artikulli {artikull.Emri} nuk u gjet");
            }

            artikull.IsDeleted = true;
            artikull.ProcessStatus = ProcessStatus.UnProcessed;
            Artikujt.AddOrUpdate(artikull);

            var rowsNr = await SaveChangesAsync();

        }

        public async Task<Artikull[]> GetUnprocessedArtikujtAsync(bool isDeleted)
        {

            var artikujt = await Artikujt
                .Where(a => a.ProcessStatus == ProcessStatus.UnProcessed
                && a.IsDeleted == isDeleted)
                .ToArrayAsync();
            return artikujt;

        }

        public async Task MarkArtikujtAsProcessed(Artikull[] artikujt)
        {
            foreach(var artikull in artikujt)
            {
                artikull.ProcessStatus = ProcessStatus.Processed;
                Artikujt.AddOrUpdate(artikull);
            }

            await SaveChangesAsync();

            await CleanArtikujt();
        }

        public async Task CleanArtikujt()
        {
            var artikujt = await Artikujt
                .Where(a => a.IsDeleted && a.ProcessStatus == ProcessStatus.Processed)
                .ToArrayAsync();

            Artikujt.RemoveRange(artikujt);

            await SaveChangesAsync();
        }
    }
}
