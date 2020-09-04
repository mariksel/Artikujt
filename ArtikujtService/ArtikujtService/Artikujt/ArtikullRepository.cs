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

        public Configuration GetConfiguration()
        {
            return _dbContext.Configurations.First();
        }

        public async Task<ServiceResult> SaveArtikullLogs(ArtikullXmlLog[] artikullLogs, string recordType)
        {
            foreach(var artikullLog in artikullLogs)
            {

                artikullLog.RecordType = recordType;

                await _dbContext.AddAsync(artikullLog);
                
            }
            await _dbContext.SaveChangesAsync();

            return ServiceResult.Success;
        }

    }
}
