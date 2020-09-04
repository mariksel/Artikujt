using ArtikujtService.Artikujt.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtikutClient.Database
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Artikull> Artikujt { get; set; }
        public DbSet<ArtikullXmlLog> ArtikullXmlLogs { get; set; }
        public DbSet<Configuration> Configurations { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtikullXmlLog>()
                             .HasKey(a => a.XmlLogId);
        }
    }
}