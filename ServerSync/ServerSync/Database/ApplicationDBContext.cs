using ArtikujtService.Artikujt.Models;
using System.Data.Entity;

namespace ArtikutClient.Database
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Artikull> Artikujt { get; set; }
        public DbSet<ArtikullXmlLog> ArtikullXmlLogs { get; set; }

        public ApplicationDBContext() :
            base("SqlServerConnectionString")
        {

        }

    }
}