using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitapProje.Models.Configurations
{
    public class AppUser_CFG : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var hasher = new PasswordHasher<AppUser>();
            builder.HasData(new AppUser
            {
                Id = 1,
                UserName = "rott",
                NormalizedUserName = "ROOT",
                Email = "root@mail.com",
                NormalizedEmail = "ROOT@MAIL.COM",
                PasswordHash = hasher.HashPassword(null, "Root123!"),
                SecurityStamp = Guid.NewGuid().ToString(),
            });
        }
    }
}
