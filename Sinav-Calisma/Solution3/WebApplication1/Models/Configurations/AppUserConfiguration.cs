using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var hasher = new PasswordHasher<AppUser>();
            var password = "Root123!";

            builder.HasData(
                    new AppUser
                    {
                        Id = 1,
                        Ad = "Super",
                        Soyad = "User",
                        UserName = "root",
                        NormalizedUserName = "ROOT",
                        Email = "root@mail.com",
                        NormalizedEmail = "ROOT@MAIL.COM",
                        PasswordHash = hasher.HashPassword(null, password),
                        SecurityStamp = Guid.NewGuid().ToString("D"),
                    }
                );
        }
    }
}
