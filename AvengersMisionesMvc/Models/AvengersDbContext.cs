using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AvengersMisionesMvc.Models
{
    public class AvengersDbContext : DbContext
    {
        public AvengersDbContext() : base("name=AvengersDbContext") { }

        public DbSet<Heroe> Heroes { get; set; }
        public DbSet<Mision> Misiones { get; set; }
    }
}