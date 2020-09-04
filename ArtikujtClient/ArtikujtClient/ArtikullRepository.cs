using ArtikujtClient.Models;
using ArtikutClient.Database;
using ArtikutClient.Models;
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
            var currentProcessStatus = artikull.ProcessStatus;
            try
            {
                artikull.ProcessStatus = ProcessStatus.UnProcessed;
                if (string.IsNullOrWhiteSpace(artikull.Id))
                    artikull.Id = await GenerateId();


                Artikujt.AddOrUpdate(artikull);

                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                artikull.ProcessStatus = currentProcessStatus;
                throw ex;
            }
            

        }

        public async Task FshiArtikullAsync(Artikull artikull)
        {

            var currentArtikull = await Artikujt.FindAsync(artikull.Id);
            if (currentArtikull == null)
            {
                throw new ArgumentException($"Artikulli {artikull.Emri} nuk u gjet");
            }

            artikull.RecordType = RecordType.Delete;
            artikull.ProcessStatus = ProcessStatus.UnProcessed;
            Artikujt.AddOrUpdate(artikull);

            var rowsNr = await SaveChangesAsync();

        }

        public async Task<Artikull[]> GetUnprocessedArtikujtAsync(string recordType)
        {

            var artikujt = await Artikujt
                .Where(a => a.ProcessStatus == ProcessStatus.UnProcessed
                && a.RecordType == recordType)
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
                .Where(a => a.RecordType == RecordType.Delete && a.ProcessStatus == ProcessStatus.Processed)
                .ToArrayAsync();

            Artikujt.RemoveRange(artikujt);

            await SaveChangesAsync();
        }
    }
}
