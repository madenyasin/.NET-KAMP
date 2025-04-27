using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitapProje.Models.Configurations
{
    public class Kategori_CFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasData(
                    new Kategori { Id = 1, Ad = "Deneme"},
                    new Kategori { Id = 2, Ad = "Hikaye"}
                );
        }
    }
}
