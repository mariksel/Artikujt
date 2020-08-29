using ArtikujtService.Api.Models;
using ArtikujtService.Artikujt.Models;
using ArtikujtService.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtikujtService.Artikujt
{
    public class ArtikullService
    {
        private readonly ArtikullRepository _repository;
        public ArtikullService(ArtikullRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult> SaveArtikullLogs(ClientArtikull[] clientArtikujt)
        {
            var artikullLogs = new List<ArtikullXmlLog>();
            foreach (var clientArtikull in clientArtikujt)
            {
                artikullLogs.Add(ArtikullXmlLog.CreateArtikullXmlLog( clientArtikull));
            }
            return await _repository.SaveArtikullLogs(artikullLogs.ToArray());
        }

        public async Task<ServiceResult> DeleteArtikujtLogs(string[] artikujtIds)
        {
            return await _repository.DeleteArtikujtLogs(artikujtIds);
        }
    }
}
