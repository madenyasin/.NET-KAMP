using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication3.Models.Configurations
{
    public class KategoriConfiguration : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasData(
                new Kategori { Id = 1, Ad = "Gündem", Aciklama = "Güncel haberler" },
                new Kategori { Id = 2, Ad = "Spor", Aciklama = "Spor haberleri" },
                new Kategori { Id = 3, Ad = "Teknoloji", Aciklama = "Teknolojiye dair gelişmeler" });
        }
    }
}
