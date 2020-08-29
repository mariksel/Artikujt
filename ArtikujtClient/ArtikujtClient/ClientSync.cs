using ArtikujtClient.Models;
using ArtikutClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ArtikujtClient
{
    public class ClientSync
    {
        public static Configuration Configuration { get; private set; }
        private static readonly Lazy<ClientSync> lazyClient = new Lazy<ClientSync> (() => new ClientSync());
        public static ClientSync Instance { get { return lazyClient.Value; } }

        public static HttpClient HttpClient = new HttpClient();

        public ClientSync()
        {
            using(var repo = new ArtikullRepository())
            {
                Configuration = repo.GetConfiguration();
            }
        }

        public string GetUrl(string path)
        {
            return $"https://localhost:5001/{path}";
        }

        public async void SaveArtikujt(Artikull[] artikujt)
        {
            await Task.Run(async () => {
                var serverArtikujt = artikujt.Select(a => new ClientArtikull(a)).ToArray();

                var xmlSerializer = new XmlSerializer(serverArtikujt.GetType());
                var artikujtXml = "";
                using (var stream = new StringWriter())
                using (var writer = XmlWriter.Create(stream))
                {
                    xmlSerializer.Serialize(writer, serverArtikujt);
                    artikujtXml = stream.ToString();
                }
                var httpContent = new StringContent(artikujtXml, Encoding.Unicode, "application/xml");
                var response = await HttpClient.PostAsync(GetUrl("api/artikujt/logs"), httpContent);
                if (response.IsSuccessStatusCode)
                {
                    using (var repo = new ArtikullRepository())
                    {
                        await repo.MarkArtikujtAsProcessed(artikujt);
                    }
                }
            });
            
        }
    }
}
