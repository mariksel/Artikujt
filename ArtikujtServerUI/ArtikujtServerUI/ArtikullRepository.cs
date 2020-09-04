using ArtikujtClient.Models;
using ArtikujtServerUI.Database;
using ArtikujtServerUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

        public void CheckConnection()
        {
            if (!Database.Exists())
                throw new Exception("Database not found");
            var artikujt = Artikujt.Where(a => a.Id == "1").Count();
            var config = Configurations.Where(c => c.Id == 1).Count();
            return;
        }

        public async Task<string> GenerateId()
        {
            var config = await Configurations.FirstAsync();
            var id = $"{config.Prefix}_{config.Sequence}";
            config.Sequence++;
            await SaveChangesAsync();
            return id;
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
            if (string.IsNullOrWhiteSpace(artikull.Id))
                artikull.Id = await GenerateId();
                 

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

            Artikujt.Remove(currentArtikull);

            var rowsNr = await SaveChangesAsync();

        }

    }
}
