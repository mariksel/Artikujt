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
        private readonly Configuration _configuration;
        public ArtikullController(ArtikullService artikullService, Configuration configuration)
        {
            _artikullService = artikullService;
            _configuration = configuration;
        }

        [HttpGet("/")]
        public ActionResult<Configuration> GetConfiguration()
        {

            return _configuration;
        }

        /// <summary>
        /// Create Artikull Xml Logs
        /// </summary>
        /// <param name="clientArtikujt"></param>
        /// <returns></returns>
        [HttpPost("logs/create")]
        public async Task<ActionResult<ApiResponse>> CreateArtikullXmlLogs(ClientArtikull[] clientArtikujt)
        {
            
            var result = await _artikullService.CreatArtikullLogs(clientArtikujt);

            return new ApiResponse(result);
        }

        /// <summary>
        /// Update Artikull Xml Logs
        /// </summary>
        /// <param name="clientArtikujt"></param>
        /// <returns></returns>
        [HttpPost("logs/update")]
        public async Task<ActionResult<ApiResponse>> UpdateArtikullXmlLogs(ClientArtikull[] clientArtikujt)
        {

            var result = await _artikullService.UpdateArtikullLogs(clientArtikujt);

            return new ApiResponse(result);
        }

        /// <summary>
        /// Delete Artikull Xml Logs
        /// </summary>
        /// <param name="artikullIds"></param>
        /// <returns></returns>
        [HttpPost("logs/delete")]
        public async Task<ActionResult<ApiResponse>> DleteArtikullLogs(string[] artikullIds)
        {
            var result = await _artikullService.DeleteArtikujtLogs(artikullIds);
            return new ApiResponse(result);
        }

    }
}