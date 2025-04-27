using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinav_MVC.Models;

namespace Sinav_MVC.Configurations
{
    public class KitapConfiguration : IEntityTypeConfiguration<Kitap>
    {
        public void Configure(EntityTypeBuilder<Kitap> builder)
        {
            var userId = "root-user-id";

            builder.HasData(
                new Kitap
                {
                    Id = 1,
                    Title = "1984",
                    Description = "Totaliter rejimlerin eleştirisi.",
                    YazarId = 4,
                    YaynieviId = 1,
                    UserId = userId
                },
                new Kitap
                {
                    Id = 2,
                    Title = "Kızıl Elma",
                    Description = "Türk tarihi ve stratejisi üzerine bir eser.",
                    YazarId = 2,
                    YaynieviId = 2,
                    UserId = userId
                },
                new Kitap
                {
                    Id = 3,
                    Title = "İntibah",
                    Description = "Romantik bir Osmanlı romanı.",
                    YazarId = 1,
                    YaynieviId = 1,
                    UserId = userId
                },
                new Kitap
                {
                    Id = 4,
                    Title = "Toprak Ana",
                    Description = "II. Dünya Savaşı'nda kaybettikleriyle baş etmeye çalışan Tolgonay'ın hikayesi.",
                    YazarId = 4,
                    YaynieviId = 2,
                    UserId = userId
                });
        }
    }
}
