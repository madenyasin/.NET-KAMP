using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ToDoDbContext: IdentityDbContext<Uye, Rol, int>
    {
        public ToDoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ToDoDbContext()
        {
        }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Not> Notlar { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
