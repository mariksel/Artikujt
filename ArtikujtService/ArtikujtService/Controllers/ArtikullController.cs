using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtikujtService.Api.Models;
using ArtikujtService.Api.Responses;
using ArtikujtService.Artikujt;
using ArtikujtService.Artikujt.Models;
using ArtikutClient.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtikujtService.Controllers
{

    [Route("api/artikujt")]
    [ApiController]
    public class ArtikullController : ControllerBase
    {
        private readonly ArtikullService _artikullService;
        public ArtikullController(ArtikullService artikullService)
        {
            _artikullService = artikullService;
        }

        
        /// <summary>
        /// Save Artikull Xml Logs
        /// </summary>
        /// <param name="clientArtikujt"></param>
        /// <returns></returns>
        [HttpPost("logs")]
        public async Task<ActionResult<ApiResponse>> SaveArtikullXmlLogs(ClientArtikull[] clientArtikujt)
        {
            
            var result = await _artikullService.SaveArtikullLogs(clientArtikujt);

            return new ApiResponse(result);
        }

        /// <summary>
        /// Delete Artikull Xml Logs
        /// </summary>
        /// <param name="artikullIds"></param>
        /// <returns></returns>
        [HttpDelete("logs")]
        public async Task<ActionResult<ApiResponse>> DleteArtikullLogs(string[] artikullIds)
        {
            var result = await _artikullService.DeleteArtikujtLogs(artikullIds);
            return new ApiResponse(result);
        }

        [HttpGet("logs")]
        public ActionResult<List<ClientArtikull>>GetArtikullXmlLogs()
        {
            var artikullLogs = new List<ClientArtikull>();

            artikullLogs.Add(new ClientArtikull
            {
                Id = "Client1_1",
                Emri = "artikull 1",
                Njesia = "kg",
                DataSkadences = "2020-01-01",
                Cmimi = 54454,
                Lloj = Lloj.Importuar,
                KaTvsh = true,
                Tipi = Tipi.Pije,
                Barkod = "sfsjflsdfj"
            });
            artikullLogs.Add(new ClientArtikull
            {
                Id = "Client1_2",
                Emri = "artikull 2",
                Njesia = "ml",
                DataSkadences = "2020-01-02",
                Cmimi = 54456,
                Lloj = Lloj.Vendi,
                KaTvsh = true,
                Tipi = Tipi.Ushqimore,
                Barkod = "sfsjflsdfj"
            });

            return artikullLogs;
        }

        [HttpGet("str")]
        public string[] str()
        {
            return new string[] { "Client_1", "Clinet_2"};
        }
    }
}