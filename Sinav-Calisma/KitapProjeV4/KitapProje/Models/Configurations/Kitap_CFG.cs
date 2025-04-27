using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitapProje.Models.Configurations
{
    public class Kitap_CFG : IEntityTypeConfiguration<Kitap>
    {
        public void Configure(EntityTypeBuilder<Kitap> builder)
        {

            builder
                .Property(x => x.Fiyat)
                .HasColumnType("money");


            builder.HasData(
                    new Kitap
                    {
                        Id = 1,
                        Ad = "kitap1",
                        Fiyat = 100,
                        Ozet = "özet1",
                        SayfaSayisi = 1000,
                        UserId = 1
                    },
                    new Kitap
                    {
                        Id = 2,
                        Ad = "kitap2",
                        Fiyat = 200,
                        Ozet = "özet2",
                        SayfaSayisi = 2000,
                        UserId = 1
                    }
                );

        }
    }
}
