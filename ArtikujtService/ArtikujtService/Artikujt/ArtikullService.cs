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

        public async Task<ServiceResult> CreatArtikullLogs(ClientArtikull[] clientArtikujt)
        {
            var artikullLogs = new List<ArtikullXmlLog>();
            foreach (var clientArtikull in clientArtikujt)
            {
                artikullLogs.Add(ArtikullXmlLog.CreateArtikullXmlLog( clientArtikull));
            }
            return await _repository.SaveArtikullLogs(artikullLogs.ToArray(), RecordType.Insert);
        }

        public async Task<ServiceResult> UpdateArtikullLogs(ClientArtikull[] clientArtikujt)
        {
            var artikullLogs = new List<ArtikullXmlLog>();
            foreach (var clientArtikull in clientArtikujt)
            {
                artikullLogs.Add(ArtikullXmlLog.CreateArtikullXmlLog(clientArtikull));
            }
            return await _repository.SaveArtikullLogs(artikullLogs.ToArray(), RecordType.Update);
        }

        public async Task<ServiceResult> DeleteArtikujtLogs(string[] artikujtIds)
        {
            var artikullLogs = new List<ArtikullXmlLog>();
            foreach (var id in artikujtIds)
            {
                var artikull = new ClientArtikull
                {
                    Id = id
                };
                artikullLogs.Add(ArtikullXmlLog.CreateArtikullXmlLog(artikull));
            }

            return await _repository.SaveArtikullLogs(artikullLogs.ToArray(), RecordType.Delete);
        }
    }
}
