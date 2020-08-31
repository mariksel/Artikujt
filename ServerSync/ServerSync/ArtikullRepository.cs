using ArtikujtService.Artikujt.Models;
using ArtikutClient.Database;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ArtikujtClient
{
    public class ArtikullRepository: ApplicationDBContext
    {

        public async Task<int> CountunprocessedLogs()
        {
            var count = await ArtikullXmlLogs
                .Where(a => a.ProcessStatus == ProcessStatus.UnProcessed)
                .CountAsync();
            return count;
        }


        public async Task RuajArtikullAsync(Artikull artikull)
        {
            //artikull.ProcessStatus = ProcessStatus.UnProcessed;
            //Artikujt.AddOrUpdate(artikull);

            await SaveChangesAsync();

        }

        public async Task FshiArtikullAsync(Artikull artikull)
        {

            var currentArtikull = await Artikujt.FindAsync(artikull.Id);
            if (currentArtikull == null)
            {
                throw new ArgumentException($"Artikulli {artikull.Emri} nuk u gjet");
            }

            //artikull.IsDeleted = true;
            //artikull.ProcessStatus = ProcessStatus.UnProcessed;
            //Artikujt.AddOrUpdate(artikull);

            var rowsNr = await SaveChangesAsync();

        }

        public async Task<ArtikullXmlLog[]> GetUnprocessedArtikujtAsync(bool isDeleted)
        {
            
            var artikujt = await ArtikullXmlLogs
                .Where(a => a.ProcessStatus == ProcessStatus.UnProcessed
                && a.RecordType == RecordType.Delete)
                .ToArrayAsync();
            return artikujt;

        }

        public async Task ProcessInsertLogs()
        {
            var insertLogs = await ArtikullXmlLogs.
                Where(log => log.RecordType == RecordType.Insert
                    && log.ProcessStatus == ProcessStatus.UnProcessed)
                .ToListAsync();

            foreach(var inserLog in insertLogs)
            {
                var artikull = inserLog.ToArtikull();
                Artikujt.Add(artikull);
                inserLog.ProcessStatus = ProcessStatus.Processed;
            }

            await SaveChangesAsync();

        }

        public async Task ProcessUpdateLogs()
        {
            var updateLogs = await (from log in ArtikullXmlLogs
                                    where log.RecordType == RecordType.Update
                                        && log.ProcessStatus == ProcessStatus.UnProcessed
                                     join artikull in Artikujt on log.ArtikullId equals artikull.Id
                                     group log by log.ArtikullId into g
                                     select g.OrderByDescending(log => log.InsertDate).FirstOrDefault())
                                     .ToListAsync();

            foreach (var updateLog in updateLogs)
            {
                var artikull = updateLog.ToArtikull();
                Artikujt.AddOrUpdate(artikull);

                //mark other update logs as processed
                var previewsUpdateLogs = ArtikullXmlLogs
                    .Where(log => log.ArtikullId == updateLog.ArtikullId
                            && log.InsertDate < updateLog.InsertDate);
                foreach (var log in previewsUpdateLogs)
                {
                    log.ProcessStatus = ProcessStatus.Processed;
                }
                updateLog.ProcessStatus = ProcessStatus.Processed;
            }

            await SaveChangesAsync();

        }

        public async Task ProcessDeletedLogs()
        {
            var deletedLogs = await ArtikullXmlLogs.
                    Where(log => log.RecordType == RecordType.Delete
                        && log.ProcessStatus == ProcessStatus.UnProcessed)
                    .ToListAsync();

            foreach(var deletedLog in deletedLogs)
            {
                // delete the artikull
                var artikull = await Artikujt.FindAsync(deletedLog.ArtikullId);
                if(artikull != null)
                    Artikujt.Remove(artikull);

                //mark all associated logs as processed
                var logsOfThisArtikull = ArtikullXmlLogs
                    .Where(log => log.ArtikullId == deletedLog.ArtikullId);
                foreach(var log in logsOfThisArtikull)
                {
                    log.ProcessStatus = ProcessStatus.Processed;
                }
            }
            await SaveChangesAsync();
        }
    }
}
