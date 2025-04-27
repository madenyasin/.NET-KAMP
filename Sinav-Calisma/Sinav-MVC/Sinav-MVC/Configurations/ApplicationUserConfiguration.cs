using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinav_MVC.Models;

namespace Sinav_MVC.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var userId = "root-user-id";
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = userId,
                     UserName = "root",
                     NormalizedUserName = "ROOT",
                     Email = "root@mail.com",
                     NormalizedEmail = "ROOT@MAIL.COM",
                     PasswordHash = hasher.HashPassword(null, "Password123!"),
                     SecurityStamp = Guid.NewGuid().ToString("D"),
                 }
            );
        }
    }
}
