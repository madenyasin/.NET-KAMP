using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.Configurations
{
    public class Kategori_CFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.Property(x => x.KategoriAdi)
                .HasColumnType("varchar")
                .HasMaxLength(20);


            builder.HasData(
                    new Kategori() { KategoriID = 1, KategoriAdi = "Kirtasiye" },
                    new Kategori() { KategoriID = 2, KategoriAdi = "Hediyelik Eşya" },
                    new Kategori() { KategoriID = 3, KategoriAdi = "Hobi" },
                    new Kategori() { KategoriID = 4, KategoriAdi = "Ayakkabi" }
                );
        }
    }
}
