using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.CFG
{
    public class Marka_CFG : IEntityTypeConfiguration<Marka>
    {
        public void Configure(EntityTypeBuilder<Marka> builder)
        {
            builder.Property(x => x.Ad)
               .HasColumnType("nvarchar")
               .HasMaxLength(50);


            builder.HasData(
                new Marka
                {
                    Id = 1,
                    Ad = "Toyota"
                },
                new Marka
                {
                    Id = 2,
                    Ad = "Ford"
                },
                new Marka
                {
                    Id = 3,
                    Ad = "BMW"
                },
                new Marka
                {
                    Id = 4,
                    Ad = "Mercedes"
                },
                new Marka
                {
                    Id = 5,
                    Ad = "Honda"
                }
             );
        }
    }
}
