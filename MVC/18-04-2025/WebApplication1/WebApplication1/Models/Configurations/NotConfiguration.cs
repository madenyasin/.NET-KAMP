using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.Configurations
{
    public class NotConfiguration : IEntityTypeConfiguration<Not>
    {
        public void Configure(EntityTypeBuilder<Not> builder)
        {
            builder.HasData(
               new Not
               {
                   Id = 1,
                   Ad = "Sunumu Hazırla",
                   Aciklama = "Proje sunum dosyası hazırla",
                   OlusturmaTarihi = DateTime.Now,
                   BitisTarihi = DateTime.Now.AddDays(2),
                   Durum = false,
                   KategoriId = 1,
                   UyeId = 1
               },
               new Not
               {
                   Id = 2,
                   Ad = "Markete Git",
                   Aciklama = "Alışveriş listesiyle markete git",
                   OlusturmaTarihi = DateTime.Now,
                   BitisTarihi = DateTime.Now.AddDays(1),
                   Durum = false,
                   KategoriId = 3,
                   UyeId = 2
               },
               new Not
               {
                   Id = 3,
                   Ad = "Kitap Oku",
                   Aciklama = "Günde en az 30 sayfa",
                   OlusturmaTarihi = DateTime.Now,
                   BitisTarihi = DateTime.Now.AddDays(5),
                   Durum = true,
                   KategoriId = 2,
                   UyeId = 3
               }
           );
        }
    }
}
