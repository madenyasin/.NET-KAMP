using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication3.Models.Configurations
{
    public class HaberConfiguration : IEntityTypeConfiguration<Haber>
    {
        public void Configure(EntityTypeBuilder<Haber> builder)
        {

            builder.HasData(
                 new Haber
                 {
                     Id = 1,
                     Baslik = "Yeni Seçimler Açıklandı",
                     Detay = "YSK, 2025 genel seçim tarihini duyurdu.",
                     ResimYolu = "secim.jpg",
                     EklendigiTarih = new DateTime(2025, 4, 15),
                     UyeId = 1,
                     KategoriId = 1
                 },
                new Haber
                {
                    Id = 2,
                    Baslik = "Şampiyon Belli Oldu!",
                    Detay = "Süper Lig şampiyonu 2025 sezonu tamamlandı.",
                    ResimYolu = "spor.jpg",
                    EklendigiTarih = new DateTime(2025, 4, 10),
                    UyeId = 1,
                    KategoriId = 2
                },
                new Haber
                {
                    Id = 3,
                    Baslik = "Yeni Telefon Tanıtıldı",
                    Detay = "X markası yeni amiral gemisi modelini duyurdu.",
                    ResimYolu = "teknoloji.jpg",
                    EklendigiTarih = new DateTime(2025, 4, 12),
                    UyeId = 1,
                    KategoriId = 3
                });
        }
    }
}
