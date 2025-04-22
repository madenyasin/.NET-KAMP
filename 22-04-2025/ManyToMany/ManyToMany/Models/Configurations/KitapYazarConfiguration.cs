using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManyToMany.Models.Configurations
{
    public class KitapYazarConfiguration : IEntityTypeConfiguration<KitapYazar>
    {
        public void Configure(EntityTypeBuilder<KitapYazar> builder)
        {
            builder.HasData(
                 new KitapYazar {Id = 1,  KitapId = 1, YazarId = 1 },
                new KitapYazar { Id = 2, KitapId = 2, YazarId = 2 },
                new KitapYazar { Id = 3, KitapId = 3, YazarId = 3 });
        }
    }
}
