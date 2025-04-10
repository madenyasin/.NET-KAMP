
using Kitap.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Kitap.Data
{
    public class KutuphaneContext: DbContext
    {

        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<YayinEvi> YayinEvis { get; set; }
        public DbSet<Kitapp> Kitaplar { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-A9QK5E9\\SQLEXPRESS;Database=SeninVeritabaniAdi4;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
