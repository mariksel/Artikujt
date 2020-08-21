using ArtikujtMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArtikujtMVC.Database
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Artikull> Artikujt { get; set; }

        public ApplicationDBContext() :
            base("SqlServerConnectionString")
        {

        }

    }
}