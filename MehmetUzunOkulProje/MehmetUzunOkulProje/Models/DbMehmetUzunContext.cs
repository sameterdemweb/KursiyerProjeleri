using MehmetUzunOkulProje.Entities;
using Microsoft.EntityFrameworkCore;

namespace MehmetUzunOkulProje.Models
{
    public class DbMehmetUzunContext : DbContext
    {
        public DbMehmetUzunContext(DbContextOptions<DbMehmetUzunContext> options ):base(options)
        {

        }
        public DbSet<Sinif> Sinif { get; set; }
        public DbSet<Ogrenci> Ogrenci { get; set; }
        public DbSet<Bolum> Bolum { get; set; } 
    }
}
