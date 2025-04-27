using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinav_MVC.Models;

namespace Sinav_MVC.Configurations
{
    public class KategoriConfiguration : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasData(
                new Kategori { Id = 1, Name = "Deneme" },
                new Kategori { Id = 2, Name = "Hikaye" },
                new Kategori { Id = 3, Name = "Roman" },
                new Kategori { Id = 4, Name = "Bilim Kurgu" },
                new Kategori { Id = 5, Name = "Fantastik" },
                new Kategori { Id = 6, Name = "Distopya" },
                new Kategori { Id = 7, Name = "Tarih" });
        }
    }
}
