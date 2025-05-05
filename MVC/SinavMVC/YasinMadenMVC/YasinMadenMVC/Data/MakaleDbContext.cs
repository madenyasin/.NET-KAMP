using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YasinMadenMVC.Models;

namespace YasinMadenMVC.Data
{
    public class MakaleDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public DbSet<Makale> Makaleler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<KategoriMakale> KategoriMakale { get; set; }
        public MakaleDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MakaleDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<KategoriMakale>()
                .HasKey(km => new { km.MakaleId, km.KategoriId });

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
