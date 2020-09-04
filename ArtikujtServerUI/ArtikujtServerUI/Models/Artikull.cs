using ArtikujtClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.RightsManagement;
using System.Web;

namespace ArtikujtServerUI.Models
{
    [Table("Artikujt", Schema = "dbo")]
    public class Artikull
    {
        [NotMapped]
        public string Prefix => Id.Split('_').FirstOrDefault();

        [NotMapped]
        public bool IsNew { get; set; }

        public string Id { get; set; }
        private string _emri;
        [MaxLength(256)]
        [Required(ErrorMessage = nameof(Emri) + " duhet plotesuar")]
        public string Emri {
            get => _emri;
            set
            {
                _emri = value;
                EmriChanged?.Invoke(value);
            }
        }
        [MaxLength(256)]
        [Required(ErrorMessage = nameof(Njesia) + " duhet plotesuar")]
        public string Njesia { get; set; }
        [Required(ErrorMessage = "Data Skadences duhet plotesuar")]
        public DateTime DataSkadences { get; set; }
        private double _cmimi;
        [Range(0, long.MaxValue, ErrorMessage = "Cmimi nuk mund te jete nje numer negativ ose nje numer shume i madh")]
        public double Cmimi
        {
            get => _cmimi;
            set
            {
                _cmimi = value;
                CmimiChanged?.Invoke(value);
            }
        }
        [Required(ErrorMessage = nameof(Lloj) + " duhet plotesuar")]
        public string Lloj { get; set; }
        public bool KaTvsh { get; set; }
        [Required(ErrorMessage = nameof(Tipi) + " duhet plotesuar")]
        public string Tipi { get; set; }
        [MaxLength(256)]
        [Required(ErrorMessage = nameof(Barkod) + " duhet plotesuar")]
        public string Barkod { get; set; }

        [NotMapped]
        public bool IsMyArtikull => Id == null || Id.StartsWith(ArtikullService.Configuration.Prefix);


        public void OnSave(bool isSaving = true)
        {
            Saving?.Invoke(isSaving);
        }



        public event CmimiEventHandler CmimiChanged;
        public event EmriEventHandler EmriChanged;
        public event SaveEventHandler Saving;
    }

    public delegate void CmimiEventHandler(double cmimi);
    public delegate void EmriEventHandler(string emri);
    public delegate void SaveEventHandler(bool isSaving);
}