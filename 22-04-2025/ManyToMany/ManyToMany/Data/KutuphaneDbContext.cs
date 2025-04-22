using ManyToMany.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ManyToMany.Data
{
    public class KutuphaneDbContext: DbContext
    {
        public KutuphaneDbContext(DbContextOptions options) : base(options)
        {
        }

        protected KutuphaneDbContext()
        {
        }

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yazar> Yazarlar{ get; set; }
        public DbSet<KitapYazar> KitapYazar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
