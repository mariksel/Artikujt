using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArtikujtMVC.Models
{
    [Table("Artikujt", Schema = "dbo")]
    public class Artikull
    {
        [NotMapped]
        public bool IsNew { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = nameof(Emri) +" duhet plotesuar")]
        public string Emri { get; set; }
        [Required(ErrorMessage = nameof(Njesia) +" duhet plotesuar")]
        public string Njesia { get; set; }
        [Required(ErrorMessage = "Data Skadences duhet plotesuar")]
        public DateTime DataSkadences { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Cmimi nuk mund te jete nje numer negativ")]
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