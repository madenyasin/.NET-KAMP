using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class HaberDbContext : IdentityDbContext<Uye, Rol, int>
    {
        public HaberDbContext(DbContextOptions options) : base(options)
        {
        }

        protected HaberDbContext()
        {
        }

        public DbSet<Haber> Haberler { get; set; }
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
