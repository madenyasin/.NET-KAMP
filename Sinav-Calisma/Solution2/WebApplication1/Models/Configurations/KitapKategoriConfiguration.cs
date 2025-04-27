using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.Configurations
{
    public class KitapKategoriConfiguration : IEntityTypeConfiguration<KitapKategori>
    {
        public void Configure(EntityTypeBuilder<KitapKategori> builder)
        {

            builder.HasKey(kk => new { kk.KitapId, kk.KategoriId });

            builder.HasData(
                    new KitapKategori { KitapId = 1, KategoriId = 1 },
                    new KitapKategori { KitapId = 2, KategoriId = 3 }
                );
        }
    }
}
