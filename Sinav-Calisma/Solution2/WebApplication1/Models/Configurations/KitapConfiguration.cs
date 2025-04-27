using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.Configurations
{
    public class KitapConfiguration : IEntityTypeConfiguration<Kitap>
    {
        public void Configure(EntityTypeBuilder<Kitap> builder)
        {
            builder.Property(x => x.Fiyat)
                .HasColumnType("money");

            builder.HasData(
                    new Kitap
                    {
                        Id = 1,
                        Ad = "Toprak Ana",
                        Fiyat = 100,
                        Ozet = "Tologonay'ın acılı hikayesi...",
                        SayfaSayisi = 152,
                        UserId = "1"
                    },
                    new Kitap
                    {
                        Id = 2,
                        Ad = "Beyaz Gemi",
                        Fiyat = 120,
                        Ozet = "...",
                        SayfaSayisi = 252,
                        UserId = "1"
                    }
                );
        }
    }
}
