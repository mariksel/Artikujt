using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ServerSync.Models
{
    [Table("xml_log", Schema = "dbo")]
    public class ArtikullXmlLog
    {
        [Column("xml_logId")]
        [Key]
        public long XmlLogId { get; set; }
        [Column("xml_data")]
        public string XmlData { get; set; }
        [Column("insert_date")]
        public DateTime InsertDate { get; set; }
        [Column("record_type")]
        public string RecordType { get; set; }
        [Column("process_status")]
        public string ProcessStatus { get; set; } 

        public ArtikullXmlLog() { }

        public Artikull ToArtikull()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Artikull));
            StringReader rdr = new StringReader(XmlData);
            Artikull artikull = (Artikull)serializer.Deserialize(rdr);

            return artikull;
        }
    }
}
