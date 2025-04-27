using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinav_MVC.Models;

namespace Sinav_MVC.Configurations
{
    public class YazarConfiguration : IEntityTypeConfiguration<Yazar>
    {
        public void Configure(EntityTypeBuilder<Yazar> builder)
        {
            builder.HasData(
                new Yazar { Id = 1, FirstName = "Namık", LastName = "Kemal" },
                new Yazar { Id = 2, FirstName = "Ziya", LastName = "Gökalp" },
                new Yazar { Id = 3, FirstName = "Cengiz", LastName = "Aytmatov" },
                new Yazar { Id = 4, FirstName = "George", LastName = "Orwell" });
        }
    }
}
