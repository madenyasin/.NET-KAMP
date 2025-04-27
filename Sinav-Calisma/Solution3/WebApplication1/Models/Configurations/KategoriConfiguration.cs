using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.Configurations
{
    public class KategoriConfiguration : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasData(
                new Kategori { Id = 1, Ad = "Roman" },
                new Kategori { Id = 2, Ad = "Deneme" },
                new Kategori { Id = 3, Ad = "Hikaye" }
            );
        }
    }
}
