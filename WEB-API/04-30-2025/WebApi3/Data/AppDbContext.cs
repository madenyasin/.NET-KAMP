using Microsoft.EntityFrameworkCore;
using WebApi3.Models;

namespace WebApi3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kategori>()
                .HasData(
                    new Kategori { KategoriID = 1, KategoriAdi = "Elektronik" },
                    new Kategori { KategoriID = 2, KategoriAdi = "Hediyelik Eşya" },
                    new Kategori { KategoriID = 3, KategoriAdi = "Televizyon" }
                );

        }
    }
}
