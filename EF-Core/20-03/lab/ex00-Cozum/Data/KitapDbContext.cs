using ex00_Cozum.Models;
using ex00_Cozum.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ex00_Cozum.Data
{
    internal class KitapDbContext : DbContext
    {
        public DbSet<Barkod> Barkodlar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<KitapYazar> kitaplarYazarlar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data source=.;initial catalog=KutuphaneEFCore2;integrated security=true;trust server certificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Böyle kullanma! mecbur olmadıkça
            modelBuilder.Entity<Yayinevi>()
                .Property(x => x.YayinEviAdi)
                .HasMaxLength(150)
                .HasColumnType("varchar");




            // Configuration sınıflarını kulanmak
            // 1. yöntem
            // kaç tane cfg sınıfı varsa o kadarını tanımla
            //modelBuilder.ApplyConfiguration(new Kitap_CFG());
            //modelBuilder.ApplyConfiguration(new Kategori_CFG());



            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
