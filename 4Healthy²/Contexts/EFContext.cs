using _4Healthy_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _4Healthy_.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>(
                new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        public DbSet<Alimento> Alimento { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
    }
}