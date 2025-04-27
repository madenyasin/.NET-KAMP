using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitapProje.Models.Configurations
{
    public class KitapKategori_CFG : IEntityTypeConfiguration<KitapKategori>
    {
        public void Configure(EntityTypeBuilder<KitapKategori> builder)
        {
            builder.HasData(
                    new KitapKategori { KategoriId = 1 , KitapId = 1},
                    new KitapKategori { KategoriId = 2 , KitapId = 1},
                    new KitapKategori { KategoriId = 2 , KitapId = 2}
                );
        }
    }
}
