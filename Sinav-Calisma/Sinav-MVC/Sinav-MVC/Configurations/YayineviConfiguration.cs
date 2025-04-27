using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinav_MVC.Models;

namespace Sinav_MVC.Configurations
{
    public class YayineviConfiguration : IEntityTypeConfiguration<Yayinevi>
    {
        public void Configure(EntityTypeBuilder<Yayinevi> builder)
        {
            builder.HasData(
                new Yayinevi { Id = 1, Name = "Can Yayınları", Address = "İstanbul, Türkiye" },
                new Yayinevi { Id = 2, Name = "İthaki Yayınları", Address = "Ankara, Türkiye" },
                new Yayinevi { Id = 3, Name = "Yapı Kredi Yayınları", Address = "İzmir, Türkiye" });
        }
    }
}
