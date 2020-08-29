using ArtikujtService.Artikujt.Models;
using ArtikujtService.Results;
using ArtikutClient.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtikujtService.Artikujt
{
    public class ArtikullRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ArtikullRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<ServiceResult> SaveArtikullLogs(ArtikullXmlLog[] artikullLogs)
        {
            foreach(var artikullLog in artikullLogs)
            {
                var countLogs = await _dbContext.ArtikullXmlLogs
                    .Where(log => log.ArtikullId == artikullLog.ArtikullId &&
                        (log.RecordType == RecordType.Insert || log.RecordType == RecordType.Delete))
                    .CountAsync();

                artikullLog.RecordType = RecordType.Insert;
                if (countLogs > 0)
                {
                    artikullLog.RecordType = RecordType.Update;
                    if(countLogs == 2)
                    {
                        throw new ArgumentException("Artikulli eshte fshire");
                    }
                }


                await _dbContext.AddAsync(artikullLog);
                
            }
            await _dbContext.SaveChangesAsync();

            return ServiceResult.Success;
        }

        public async Task<ServiceResult> DeleteArtikujtLogs(string[] artikujtIds)
        {

            foreach(var id in artikujtIds)
            {
                var countLogs = await _dbContext.ArtikullXmlLogs
                    .Where(log => log.ArtikullId == id && log.RecordType == RecordType.Delete)
                    .CountAsync();
                if(countLogs == 0)
                {
                    var deleteLog = new ArtikullXmlLog
                    {
                        ArtikullId = id,
                        RecordType = RecordType.Delete,
                    };
                    _dbContext.Add(deleteLog);
                }
            }

            await _dbContext.SaveChangesAsync();

            return ServiceResult.Success;
        }
    }
}
