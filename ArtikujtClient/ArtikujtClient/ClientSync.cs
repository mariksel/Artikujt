using ArtikujtClient.Models;
using ArtikutClient.Models;
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
    public delegate void SyncEventHandler();
    public class ClientSync
    {
        public event SyncEventHandler Synchronized;

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

        public async Task SaveArtikujtAsync(params Artikull[] artikujt)
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
                HttpResponseMessage response = null;
                try
                {
                    response = await HttpClient.PostAsync(GetUrl("api/artikujt/logs"), httpContent);
                } catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return;
                }
                if (response.IsSuccessStatusCode)
                {
                    using (var repo = new ArtikullRepository())
                    {
                        await repo.MarkArtikujtAsProcessed(artikujt);
                    }
                }
            });
            
        }

        public async Task DeleteArtikujtAsync(params Artikull[] artikujt)
        {
            await Task.Run(async () => {
                var artikullIds = artikujt.Select(a =>  $"{Configuration.Prefix}_{a.Id}").ToArray();

                var xmlSerializer = new XmlSerializer(artikullIds.GetType());
                var artikujtXml = "";
                using (var stream = new StringWriter())
                using (var writer = XmlWriter.Create(stream))
                {
                    xmlSerializer.Serialize(writer, artikullIds);
                    artikujtXml = stream.ToString();
                }
                var httpContent = new StringContent(artikujtXml, Encoding.Unicode, "application/xml");
                HttpResponseMessage response = null;
                try
                {
                    response = await HttpClient.PostAsync(GetUrl("api/artikujt/logs/delete"), httpContent);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return;
                }
                if (response.IsSuccessStatusCode)
                {
                    using (var repo = new ArtikullRepository())
                    {
                        await repo.MarkArtikujtAsProcessed(artikujt);
                    }
                    Synchronized();
                }
            });

        }
    }
}
