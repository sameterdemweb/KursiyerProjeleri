using GamzeArici.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamzeArici.Models
{
    public class GamzeAriciContext :DbContext
    {
        public GamzeAriciContext(DbContextOptions<GamzeAriciContext> options) : base(options)
        {

        }
        public DbSet<Kitaplar> Kitaplar { get; set; }
        public DbSet<Okuyucular> Okuyucular { get; set; }
        public DbSet<Raflar> Raflar { get; set; }
        public DbSet<Islemler> Islemler { get; set; }
    }
}
