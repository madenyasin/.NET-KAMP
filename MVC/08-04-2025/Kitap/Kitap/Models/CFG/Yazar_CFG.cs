using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kitap.Models.CFG
{
    public class Yazar_CFG : IEntityTypeConfiguration<Yazar>
    {
        public void Configure(EntityTypeBuilder<Yazar> builder)
        {
            builder.Property(y => y.Ad).IsRequired().HasMaxLength(50);
            builder.Property(y => y.Soyad).IsRequired().HasMaxLength(50);
            builder.Property(y => y.Biyografi).HasMaxLength(1000);

            builder.HasData(
                new Yazar { Id = 1, Ad = "Orhan", Soyad = "Pamuk", Biyografi = "Nobel Edebiyat Ödüllü Yazar" },
                new Yazar { Id = 2, Ad = "Sabahattin", Soyad = "Ali", Biyografi = "Kürk Mantolu Madonna'nın Yazarı" },
                new Yazar { Id = 3, Ad = "Yaşar", Soyad = "Kemal", Biyografi = "İnce Memed Serisinin Yazarı" }
            );
        }
    }
}
