using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class UrunDbContext : IdentityDbContext<Uye, Rol, int>
    {
        public UrunDbContext(DbContextOptions options) : base(options)
        {
        }

        protected UrunDbContext()
        {
        }

        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<IdentityUserRole<int>>()
                .HasData(
                    new IdentityUserRole<int> { UserId = 1, RoleId = 1 }
                );
        }
    }
}
