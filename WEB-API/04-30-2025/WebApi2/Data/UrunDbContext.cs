using Microsoft.EntityFrameworkCore;
using WebApi2.Models;

namespace WebApi2.Data
{
    public class UrunDbContext : DbContext
    {
        public UrunDbContext(DbContextOptions options) : base(options)
        {
        }

        protected UrunDbContext()
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
