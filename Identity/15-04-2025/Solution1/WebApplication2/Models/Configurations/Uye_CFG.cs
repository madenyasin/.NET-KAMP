using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.Models.Configurations
{
    public class Uye_CFG : IEntityTypeConfiguration<Uye>
    {
        public void Configure(EntityTypeBuilder<Uye> builder)
        {

            Uye root = new Uye
            {
                Id = 1,
                Ad = "Super",
                Soyad = "User",
                Adres = "Server",
                UserName = "sprUser",
                NormalizedUserName = "SPRUSER",
                Email = "super@user.com",
                NormalizedEmail = "SUPER@USER.COM",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            // superuser - root

            PasswordHasher<Uye> hasher = new PasswordHasher<Uye>();
            root.PasswordHash = hasher.HashPassword(root, "spRuser_123");

            builder.HasData(root);
        }
    }
}
