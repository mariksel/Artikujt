using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.RightsManagement;
using System.Web;

namespace ArtikutClient.Models
{
    [Table("Artikujt", Schema = "dbo")]
    public class Artikull
    {
        [NotMapped]
        public bool IsNew { get; set; }

        public int Id { get; set; }
        [Required(ErrorMessage = nameof(Emri) + " duhet plotesuar")]
        private string _emri;
        public string Emri {
            get => _emri;
            set
            {
                _emri = value;
                EmriChanged?.Invoke(value);
            }
        }
        [Required(ErrorMessage = nameof(Njesia) + " duhet plotesuar")]
        public string Njesia { get; set; }
        [Required(ErrorMessage = "Data Skadences duhet plotesuar")]
        public DateTime DataSkadences { get; set; }
        [Range(0, long.MaxValue, ErrorMessage = "Cmimi nuk mund te jete nje numer negativ ose nje numer shume i madh")]
        private double _cmimi;
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
        [Required(ErrorMessage = nameof(Barkod) + " duhet plotesuar")]
        public string Barkod { get; set; }

        private string _processStatus = ArtikutClient.Models.ProcessStatus.UnProcessed;
        public string ProcessStatus {
            get => _processStatus;
            set
            {
                _processStatus = value;
                ProcessStatusChanged?.Invoke(value);
            }
        }
        private bool _isDeleted = false;
        public bool IsDeleted
        {
            get => _isDeleted;
            set
            {
                _isDeleted = value;
                IsDeletedChanged?.Invoke(value);
            }
        }



        public bool IsProcessed => "P".Equals(ProcessStatus, StringComparison.OrdinalIgnoreCase);
        [NotMapped]
        public bool IsProcessing { get; private set; } = false;
        public void OnSave(bool isSaving = true){
            IsProcessing = isSaving;
            Saving?.Invoke(isSaving);
        }

        public event CmimiEventHandler CmimiChanged;
        public event EmriEventHandler EmriChanged;
        public event ProcessStatusEventHandler ProcessStatusChanged;
        public event IsDeletedEventHandler IsDeletedChanged;
        public event SaveEventHandler Saving;
    }

    public delegate void CmimiEventHandler(double cmimi);
    public delegate void EmriEventHandler(string emri);
    public delegate void ProcessStatusEventHandler(string status);
    public delegate void IsDeletedEventHandler(bool isDeleted);
    public delegate void SaveEventHandler(bool isSaving);
}