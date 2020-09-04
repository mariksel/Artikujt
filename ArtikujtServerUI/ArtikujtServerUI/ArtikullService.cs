using ArtikujtClient.Models;
using ArtikujtServerUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ArtikujtClient
{
    public delegate void ServiceEventHandler();
    public class ArtikullService
    {
        public event ServiceEventHandler ServiceChange;

        public static Configuration Configuration { get; private set; }
        private static readonly Lazy<ArtikullService> lazyClient = new Lazy<ArtikullService> (() => new ArtikullService());
        public static ArtikullService Instance { get { return lazyClient.Value; } }



        public ArtikullService()
        {
            using(var repo = new ArtikullRepository())
            {
                Configuration = repo.GetConfiguration();
            }
        }



        public async Task CreateArtikujtAsync(Artikull artikull)
        {
            IsOnValidState(artikull);

            using (var repo = new ArtikullRepository())
            {
                artikull.OnSave();

                await repo.RuajArtikullAsync(artikull);
            }

            artikull.OnSave(false);
        }


        private void IsOnValidState(Artikull artikull)
        {
            if (string.IsNullOrWhiteSpace(artikull.Emri))
                throw new ArgumentException($"{nameof(artikull.Emri)} duhet plotesuar");
            if (string.IsNullOrWhiteSpace(artikull.Njesia))
                throw new ArgumentException($"{nameof(artikull.Njesia)} duhet plotesuar");
            if (artikull.Cmimi < 0)
                throw new ArgumentException($"{nameof(artikull.Cmimi)} nuk mund te jete numer negativ");
            if (string.IsNullOrWhiteSpace(artikull.Lloj))
                throw new ArgumentException($"{nameof(artikull.Lloj)} duhet plotesuar");
            if (string.IsNullOrWhiteSpace(artikull.Tipi))
                throw new ArgumentException($"{nameof(artikull.Tipi)} duhet plotesuar");
            if (string.IsNullOrWhiteSpace(artikull.Barkod))
                throw new ArgumentException($"{nameof(artikull.Barkod)} duhet plotesuar");
        }


        public async Task DeleteArtikullAsync( Artikull artikull)
        {
            using (var repo = new ArtikullRepository())
            {
                await repo.FshiArtikullAsync(artikull);
                ServiceChange();
            }

        }
    }
}
