using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sinav_MVC.Models;

namespace Sinav_MVC.Data
{
    public class KutuphaneDbContext : IdentityDbContext
    {
        public KutuphaneDbContext(DbContextOptions options) : base(options)
        {
        }

        protected KutuphaneDbContext()
        {
        }

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Yayinevi> Yayinevleri { get; set; }
        public DbSet<KitapKategori> KitapKategori { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
