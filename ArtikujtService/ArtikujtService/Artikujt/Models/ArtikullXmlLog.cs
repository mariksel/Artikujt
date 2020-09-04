using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ArtikujtService.Artikujt.Models;
using ArtikujtService.Api.Models;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace ArtikujtService.Artikujt.Models
{
    [Table("xml_log", Schema = "dbo")]
    public class ArtikullXmlLog
    {
        [Column("xml_logId")]
        public long XmlLogId { get; set; }
        [Column("xml_data")]
        public string XmlData { get; set; }
        [Column("insert_date")]
        public DateTime InsertDate { get; set; } = DateTime.Now;
        [Column("record_type")]
        public string RecordType { get; set; } = ArtikujtService.Artikujt.Models.RecordType.Insert;
        [Column("process_status")]
        public string ProcessStatus { get; set; } = ArtikujtService.Artikujt.Models.ProcessStatus.UnProcessed;

        public ArtikullXmlLog() { }

        public static ArtikullXmlLog CreateArtikullXmlLog(ClientArtikull clientArtikull)
        {
            var xmlSerializer = new XmlSerializer(clientArtikull.GetType());
            var artikullXml = "";
            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream))
            {
                xmlSerializer.Serialize(writer, clientArtikull);
                artikullXml =  stream.ToString();
            }
            return new ArtikullXmlLog
            {
                //ArtikullId = clientArtikull.Id,
                XmlData = artikullXml
            };
        }
    }
}
