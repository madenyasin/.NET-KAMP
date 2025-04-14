using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.CFG
{
    public class Arac_CFG : IEntityTypeConfiguration<Arac>
    {
        public void Configure(EntityTypeBuilder<Arac> builder)
        {
            builder.HasData(
            new Arac
            {
                Id = 1,
                Plaka = "34ABC123",
                MarkaId = 1,
                Model = "Corolla",
                Fiyat = 250000,
                Renk = "Beyaz",
                Aciklama = "2020 model, az kullanılmış",
                EkleyenUyeId = 1
            },
        new Arac
        {
            Id = 2,
            Plaka = "06XYZ456",
            MarkaId = 2,
            Model = "Focus",
            Fiyat = 180000,
            Renk = "Siyah",
            Aciklama = "2018 model, full paket",
            EkleyenUyeId = 2
        },
        new Arac
        {
            Id = 3,
            Plaka = "35DEF789",
            MarkaId = 3,
            Model = "320i",
            Fiyat = 450000,
            Renk = "Mavi",
            Aciklama = "2021 model, 20.000 km",
            EkleyenUyeId = 3
        },
        new Arac
        {
            Id = 4,
            Plaka = "16GHI012",
            MarkaId = 4,
            Model = "C200",
            Fiyat = 520000,
            Renk = "Gri",
            Aciklama = "2022 model, premium paket",
            EkleyenUyeId = 1
        },
        new Arac
        {
            Id = 5,
            Plaka = "07JKL345",
            MarkaId = 5,
            Model = "Civic",
            Fiyat = 320000,
            Renk = "Kırmızı",
            Aciklama = "2019 model, hibrit",
            EkleyenUyeId = 2
        }
            );
        }
    }
}
