
using System;
using System.Collections.Generic;
using Domain.AutoShop;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Domain.Concrete
{
    public class EFDbContext : DbContext
    {public DbSet<Skoda> Skodas { get; set; }
        public DbSet<Auto> Autos { get; set; }
        public DbSet<BMW> BMWs { get; set; }
        public DbSet<Peugeot> Peugeot { get; set; }
        public DbSet<Lada> Lada { get; set; }
        public DbSet<Porshe> Porshe { get; set; }

    }
    

}
