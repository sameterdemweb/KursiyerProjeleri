using AlisverisFurkanOzden.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlisverisFurkanOzden.Models
{
    public class AlisverisFurkanOzdenDbContext :DbContext
    {
        public AlisverisFurkanOzdenDbContext(DbContextOptions<AlisverisFurkanOzdenDbContext> options):base(options)
        {

        }
        public DbSet<KullaniciAdresleri> KullaniciAdresleri  { get; set; }
        public DbSet<Kullanicilar> Kullanicilar  { get; set; }
        public DbSet<Siparisler> Siparisler  { get; set; }
        public DbSet<Urunler> Urunler  { get; set; }

    }
}
