using ArtikujtClient.Models;
using ArtikujtServerUI.Models;
using System.Data.Entity;

namespace ArtikujtServerUI.Database
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