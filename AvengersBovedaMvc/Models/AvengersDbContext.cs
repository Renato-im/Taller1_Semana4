using AvengersBovedaMvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AvengerBovedaMvc.Models
{
    public class AvengersDbContext : DbContext
    {
        public AvengersDbContext() : base("name=AvengersDbContext") { }

        public DbSet<Boveda> Bovedas { get; set; }
        public DbSet<Artefacto> Artefactos { get; set; }
    }
}
