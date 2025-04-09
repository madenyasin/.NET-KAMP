using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kitap.Models.CFG
{
    public class Kategori_CFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.Property(x => x.Ad)
                .HasColumnType("nvarchar")
                .HasMaxLength(50);


            builder.HasData(
                new Kategori { Id = 1, Ad = "Roman" },
                new Kategori { Id = 2, Ad = "Bilim Kurgu" },
                new Kategori { Id = 3, Ad = "Tarih" },
                new Kategori { Id = 4, Ad = "Biyografi" },
                new Kategori { Id = 5, Ad = "Hikaye" },
                new Kategori { Id = 6, Ad = "Deneme" }
            );
        }
    }
}
