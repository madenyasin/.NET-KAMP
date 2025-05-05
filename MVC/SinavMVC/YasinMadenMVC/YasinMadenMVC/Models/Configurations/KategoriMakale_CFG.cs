using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace YasinMadenMVC.Models.Configurations
{
    public class KategoriMakale_CFG : IEntityTypeConfiguration<KategoriMakale>
    {
        public void Configure(EntityTypeBuilder<KategoriMakale> builder)
        {
            builder.HasData(
                new KategoriMakale { MakaleId = 1, KategoriId = 1 },
                new KategoriMakale { MakaleId = 1, KategoriId = 4 },
                new KategoriMakale { MakaleId = 2, KategoriId = 4 }
            );
        }
    }
}
