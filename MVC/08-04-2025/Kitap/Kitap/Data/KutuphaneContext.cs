
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
            optionsBuilder.UseSqlServer(@"Data source=.;initial catalog=KitapDBB;integrated security=true;trust server certificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
