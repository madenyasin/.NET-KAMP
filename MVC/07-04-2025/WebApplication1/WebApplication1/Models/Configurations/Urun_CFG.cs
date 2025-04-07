using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.Configurations
{
    public class Urun_CFG : IEntityTypeConfiguration<Urun>
    {
        public void Configure(EntityTypeBuilder<Urun> builder)
        {
            builder.Property(x => x.Fiyat)
                .HasColumnType("money");

            builder.Property(x => x.Resim)
                .HasColumnType("varchar")
                .HasMaxLength(100);
        }
    }
}
