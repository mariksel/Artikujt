using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ArtikujtService.Artikujt.Models
{
    [XmlRoot(ElementName = "ClientArtikull")]
    [Table("Artikujt", Schema = "dbo")]
    public class Artikull
    {
        [NotMapped]
        public bool IsNew { get; set; }
        [Required(ErrorMessage = nameof(Id) +" duhet plotesuar")]
        public string Id { get; set; }
        [Required(ErrorMessage = nameof(Emri) +" duhet plotesuar")]
        public string Emri { get; set; }
        [Required(ErrorMessage = nameof(Njesia) +" duhet plotesuar")]
        public string Njesia { get; set; }
        [Required(ErrorMessage = "Data Skadences duhet plotesuar")]
        public DateTime DataSkadences { get; set; }
        [Range(0, long.MaxValue, ErrorMessage = "Cmimi nuk mund te jete nje numer negativ ose nje numer shume i madh")]
        public double Cmimi { get; set; }
        [Required(ErrorMessage = nameof(Lloj) + " duhet plotesuar")]
        public string Lloj { get; set; }
        public bool KaTvsh { get; set; }
        [Required(ErrorMessage = nameof(Tipi) + " duhet plotesuar")]
        public string Tipi { get; set; }
        [Required(ErrorMessage = nameof(Barkod) + " duhet plotesuar")]
        public string Barkod { get; set; }
    }
}