using ArtikujtClient.Models;
using ArtikutClient.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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