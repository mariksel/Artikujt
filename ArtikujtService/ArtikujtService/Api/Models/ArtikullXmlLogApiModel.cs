using ArtikujtService.Artikujt.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ArtikujtService.Api.Models
{
    public class ArtikullXmlLogApiModel : ApiModel<ArtikullXmlLog>
    {
        [Required]
        [Range(0, long.MaxValue)]
        public long XmlLogId { get; set; }
        [Required]
        public string XmlData { get; set; }

        public ArtikullXmlLogApiModel() { }
        public ArtikullXmlLogApiModel(ArtikullXmlLog xmlLog)
        {
            XmlLogId = xmlLog.XmlLogId;
            XmlData = xmlLog.XmlData;
        }
        
        public ArtikullXmlLog GetModel()
        {
            return new ArtikullXmlLog
            {
                XmlLogId = XmlLogId,
                XmlData = XmlData,
            };
        }
    }
}
