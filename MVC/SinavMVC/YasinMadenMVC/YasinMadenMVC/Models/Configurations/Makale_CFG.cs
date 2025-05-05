using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace YasinMadenMVC.Models.Configurations
{
    public class Makale_CFG : IEntityTypeConfiguration<Makale>
    {
        public void Configure(EntityTypeBuilder<Makale> builder)
        {
            builder.Property(x => x.Baslik)
                .HasMaxLength(100)
                .HasColumnName("Baslik")
                .HasColumnType("nvarchar");

            builder.Property(x => x.Icerik)
                .HasMaxLength(1000)
                .HasColumnName("Icerik")
                .HasColumnType("nvarchar");

            builder.Property(x => x.YayinlanmaTarihi)
                .HasColumnName("YayinlanmaTarihi")
                .HasColumnType("datetime");

            builder.HasData(
                    new Makale
                    {
                        Id = 1,
                        Baslik = "Yapay Zeka ve Geleceği",
                        Icerik = "Yapay zeka, son yıllarda hızla gelişen bir teknoloji alanıdır. Bu makalede yapay zekanın geleceği ve potansiyel etkileri ele alınacaktır.",
                        YayinlanmaTarihi = DateTime.Now.AddDays(-15),
                        UserId = 1
                    },
                    new Makale
                    {
                        Id = 2,
                        Baslik = "Sürdürülebilir Enerji Kaynakları",
                        Icerik = "Sürdürülebilir enerji kaynakları, çevre dostu ve yenilenebilir enerji üretimi için önemlidir. Bu makalede güneş, rüzgar ve hidroelektrik enerjisi gibi kaynaklar incelenecektir.",
                        YayinlanmaTarihi = DateTime.Now.AddDays(-10),
                        UserId = 1
                    }
                );
        }
    }
}
