using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManyToMany.Models.Configurations
{
    public class YazarConfiguration : IEntityTypeConfiguration<Yazar>
    {
        public void Configure(EntityTypeBuilder<Yazar> builder)
        {
            builder.HasData(
                new Yazar { Id = 1, Ad = "Orhan", Soyad = "Pamuk", DogumTarihi = new DateTime(1952, 6, 7) },
                new Yazar { Id = 2, Ad = "Yaşar", Soyad = "Kemal", DogumTarihi = new DateTime(1923, 10, 6) },
                new Yazar { Id = 3, Ad = "Sabahattin", Soyad = "Ali", DogumTarihi = new DateTime(1907, 2, 25) });
        }
    }
}
