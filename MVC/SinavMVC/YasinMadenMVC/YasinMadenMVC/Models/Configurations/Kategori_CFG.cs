using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace YasinMadenMVC.Models.Configurations
{
    public class Kategori_CFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.Property(x => x.Ad)
                .HasMaxLength(50)
                .HasColumnName("Ad")
                .HasColumnType("nvarchar");



            builder.HasData(
                    new Kategori { Id = 1, Ad = "Teknoloji" },
                    new Kategori { Id = 2, Ad = "Eğitim" },
                    new Kategori { Id = 3, Ad = "Sağlık" },
                    new Kategori { Id = 4, Ad = "Ekonomi" },
                    new Kategori { Id = 5, Ad = "Spor" },
                    new Kategori { Id = 6, Ad = "Hava Durumu" }
                );
        }
    }
}
