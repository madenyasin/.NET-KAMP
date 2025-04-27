using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SinavProje.Models.Configurations
{
    public class AppUser_CFG : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var hasher = new PasswordHasher<AppUser>();
            builder.HasData(new AppUser
            {
                Id = 1,
                UserName = "root",
                NormalizedUserName = "ROOT",
                Email = "root@mail.com",
                NormalizedEmail = "ROOT@MAIL.COM",
                PasswordHash = hasher.HashPassword(new AppUser { UserName = "root" }, "Root123!"),
                SecurityStamp = Guid.NewGuid().ToString("D"),
            });
        }
    }
}
