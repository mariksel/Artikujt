using ArtikujtServerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtikujtClient.Models
{
    public class ClientArtikull
    {
        public string Id { get; set; }
        public string Emri { get; set; }
        public string Njesia { get; set; }
        public string DataSkadences { get; set; }
        public double Cmimi { get; set; }
        public string Lloj { get; set; }
        public bool KaTvsh { get; set; }
        public string Tipi { get; set; }
        public string Barkod { get; set; }

        public ClientArtikull() { }
        public ClientArtikull(Artikull artikull)
        {
            Id = artikull.Id;
            Emri = artikull.Emri;
            Njesia = artikull.Njesia;
            DataSkadences = artikull.DataSkadences.ToString("yyyy-MM-dd");
            Cmimi = artikull.Cmimi;
            Lloj = artikull.Lloj;
            KaTvsh = artikull.KaTvsh;
            Tipi = artikull.Tipi;
            Barkod = artikull.Barkod;
        }
    }
}
