using ArtikujtClient.Models;
using ArtikutClient.Models;
using System.Data.Entity;

namespace ArtikutClient.Database
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Artikull> Artikujt { get; set; }
        public DbSet<Configuration> Configurations { get; set; }

        public ApplicationDBContext() :
            base("SqlServerConnectionString")
        {

        }

    }
}