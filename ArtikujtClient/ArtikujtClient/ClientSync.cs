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
        private readonly string _serverUrl;

        public ClientSync()
        {
            using(var repo = new ArtikullRepository())
            {
                Configuration = repo.GetConfiguration();

                if (Configuration.ServerUrl is null)
                    throw new ArgumentNullException(nameof(Configuration.ServerUrl));
                    
                _serverUrl = Configuration.ServerUrl.TrimEnd('/');

                
            }
        }

        public string GetUrl(string path)
        {
            return $"{_serverUrl}/{path}";
        }

        private string ArtikujtToXml(Artikull[] artikujt)
        {
            var serverArtikujt = artikujt.Select(a => new ClientArtikull(a)).ToArray();

            var xmlSerializer = new XmlSerializer(serverArtikujt.GetType());
            var artikujtXml = "";
            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream))
            {
                xmlSerializer.Serialize(writer, serverArtikujt);
                artikujtXml = stream.ToString();
            }
            return artikujtXml;
        }

        public async Task CreateArtikujtAsync(params Artikull[] artikujt)
        {
            await Task.Run(async () => {

                var artikujtXml = ArtikujtToXml(artikujt);

                var httpContent = new StringContent(artikujtXml, Encoding.Unicode, "application/xml");
                HttpResponseMessage response = null;
                try
                {
                    response = await HttpClient.PostAsync(GetUrl("api/artikujt/logs/create"), httpContent);
                } catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return;
                }
                if (response.IsSuccessStatusCode)
                {
                    using (var repo = new ArtikullRepository())
                    {
                        foreach (var artikull in artikujt)
                            artikull.RecordType = RecordType.Update;

                        await repo.MarkArtikujtAsProcessed(artikujt);
                    }
                }
            });
            
        }

        public async Task UpdateArtikujtAsync(params Artikull[] artikujt)
        {
            await Task.Run(async () => {

                var artikujtXml = ArtikujtToXml(artikujt);

                var httpContent = new StringContent(artikujtXml, Encoding.Unicode, "application/xml");
                HttpResponseMessage response = null;
                try
                {
                    response = await HttpClient.PostAsync(GetUrl("api/artikujt/logs/update"), httpContent);
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
                }
            });

        }

        public async Task DeleteArtikujtAsync(params Artikull[] artikujt)
        {
            await Task.Run(async () => {
                var artikullIds = artikujt.Select(a =>  a.Id).ToArray();

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
