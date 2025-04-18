using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.Configurations
{
    public class UyeConfiguration : IEntityTypeConfiguration<Uye>
    {
        public void Configure(EntityTypeBuilder<Uye> builder)
        {
            var hasher = new PasswordHasher<Uye>();

            var uye1 = new Uye
            {
                Id = 1,
                UserName = "ali",
                NormalizedUserName = "ALI",
                Email = "ali@example.com",
                NormalizedEmail = "ALI@EXAMPLE.COM",
                EmailConfirmed = true,
                Ad = "Ali",
                Soyad = "Kaya",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            uye1.PasswordHash = hasher.HashPassword(uye1, "Password123!");

            var uye2 = new Uye
            {
                Id = 2,
                UserName = "ayse",
                NormalizedUserName = "AYSE",
                Email = "ayse@example.com",
                NormalizedEmail = "AYSE@EXAMPLE.COM",
                EmailConfirmed = true,
                Ad = "Ayşe",
                Soyad = "Yıldız",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            uye2.PasswordHash = hasher.HashPassword(uye2, "Password123!");

            var uye3 = new Uye
            {
                Id = 3,
                UserName = "mehmet",
                NormalizedUserName = "MEHMET",
                Email = "mehmet@example.com",
                NormalizedEmail = "MEHMET@EXAMPLE.COM",
                EmailConfirmed = true,
                Ad = "Mehmet",
                Soyad = "Demir",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            uye3.PasswordHash = hasher.HashPassword(uye3, "Password123!");

            builder.HasData(uye1, uye2, uye3);
        }
    }
}
