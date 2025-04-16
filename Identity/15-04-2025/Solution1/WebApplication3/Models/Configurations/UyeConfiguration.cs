using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication3.Models.Configurations
{
    public class UyeConfiguration : IEntityTypeConfiguration<Uye>
    {
        public void Configure(EntityTypeBuilder<Uye> builder)
        {

            Uye root = new Uye
            {
                Id = 1,
                Ad = "Root",
                Soyad = "Root",
                UserName = "root",
                NormalizedUserName = "ROOT",
                Email = "root@user.com",
                NormalizedEmail = "ROOT@USER.COM",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            // superuser - root

            PasswordHasher<Uye> hasher = new PasswordHasher<Uye>();
            root.PasswordHash = hasher.HashPassword(root, "Root123*");

            builder.HasData(root);
        }
    }
}
