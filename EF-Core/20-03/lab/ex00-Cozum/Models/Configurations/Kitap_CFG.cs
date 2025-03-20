using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ex00_Cozum.Models.Configurations
{
    internal class Kitap_CFG : IEntityTypeConfiguration<Kitap>
    {
        public void Configure(EntityTypeBuilder<Kitap> builder)
        {
            builder.Property(x => x.Fiyat)
                .HasColumnType("money");

            builder.Property(x => x.Ad)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.KapakResmiPath)
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .HasDefaultValue("bos.jpg");
        }
    }
}
