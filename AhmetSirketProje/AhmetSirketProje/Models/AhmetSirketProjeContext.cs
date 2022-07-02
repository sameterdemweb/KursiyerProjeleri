using AhmetSirketProje.Entities;
using Microsoft.EntityFrameworkCore;

namespace AhmetSirketProje.Models
{
    public class AhmetSirketProjeContext:DbContext
    {
        public AhmetSirketProjeContext(DbContextOptions<AhmetSirketProjeContext>options):base(options)
        {

        }

        public DbSet<Kategoriler> Kategoriler { get; set; }
        public DbSet<Sirketler> Sirketler { get; set; }
        public DbSet<Calisanlar> Calisanlar { get; set; }
        public DbSet<Isler> Isler { get; set; }
    }


}
