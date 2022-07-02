using FerhatProje.Entities;
using Microsoft.EntityFrameworkCore;

namespace FerhatProje.Models
{
    public class SalonDatabaseContext : DbContext
    {
        public SalonDatabaseContext(DbContextOptions<SalonDatabaseContext>options) : base(options)
        {

        }

        public DbSet<Salonlar> Salonlar { get; set; }
        public DbSet<Filmler> Filmler { get; set; }
    }
}
