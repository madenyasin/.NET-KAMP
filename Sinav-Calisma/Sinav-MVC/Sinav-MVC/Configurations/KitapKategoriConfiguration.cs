using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinav_MVC.Models;

namespace Sinav_MVC.Configurations
{
    public class KitapKategoriConfiguration : IEntityTypeConfiguration<KitapKategori>
    {
        public void Configure(EntityTypeBuilder<KitapKategori> builder)
        {
            builder.HasKey(kk => new { kk.KitapId, kk.KategoriId });


            builder.HasData(
                new KitapKategori { KitapId = 1, KategoriId = 6 },
                new KitapKategori { KitapId = 2, KategoriId = 7 },
                new KitapKategori { KitapId = 4, KategoriId = 3 },
                new KitapKategori { KitapId = 3, KategoriId = 3 });
        }
    }
}
