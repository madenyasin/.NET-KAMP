using ex00_JWT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ex00_JWT.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var user1 = new AppUser
            {
                Id = 1,
                UserName = "root",
                NormalizedUserName = "root",
                Email = "root@root.com",
                NormalizedEmail = "ROOT@ROOT@MAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            };

            var user2 = new AppUser
            {
                Id = 2,
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@mail.com",
                NormalizedEmail = "user@mail.com".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            };

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();

            user1.PasswordHash = passwordHasher.HashPassword(user1, "Root123!");
            user2.PasswordHash = passwordHasher.HashPassword(user2, "User123!");
            builder.Entity<AppUser>().HasData(user1, user2);

            var product1 = new Product
            {
                Id = 1,
                Name ="Çalar Saat",
                Price = 10.99m,
                Description = "Uyandırma Servisi"
            };


            var product2 = new Product
            {
                Id = 2,
                Name = "Kahve Makinesi",
                Price = 50.99m,
                Description = "Kahve Servisi"
            };
            var product3 = new Product
            {
                Id = 3,
                Name = "Buzdolabı",
                Price = 100.99m,
                Description = "Soğutma Servisi"
            };

            var product4 = new Product
            {
                Id = 4,
                Name = "Mikrodalga Fırın",
                Price = 200.99m,
                Description = "Isıtma Servisi"
            };
            builder.Entity<Product>().HasData(product1, product2, product3, product4);


        }
    }
}
