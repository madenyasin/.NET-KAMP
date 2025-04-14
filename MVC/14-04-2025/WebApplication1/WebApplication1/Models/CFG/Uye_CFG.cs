using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Utilities;

namespace WebApplication1.Models.CFG
{
    public class Uye_CFG : IEntityTypeConfiguration<Uye>
    {
        public void Configure(EntityTypeBuilder<Uye> builder)
        {
            builder.Property(x => x.Sifre)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.HasData(
                new Uye
                {
                    Id = 1,
                    Ad = "Ahmet",
                    Soyad = "Yılmaz",
                    KullaniciAdi = "ahmet",
                    Sifre = Md5Hasher.HashOlustur("ahmet","123456")
                },
            new Uye
            {
                Id = 2,
                Ad = "Mehmet",
                Soyad = "Kaya",
                KullaniciAdi = "mehmet",
                Sifre = Md5Hasher.HashOlustur("mehmet","654321")
            },
            new Uye
            {
                Id = 3,
                Ad = "Ayşe",
                Soyad = "Demir",
                KullaniciAdi = "ayse",
                Sifre = Md5Hasher.HashOlustur("ayse", "abc123")
            },
            new Uye
            {
                Id = 4,
                Ad = "Fatma",
                Soyad = "Çelik",
                KullaniciAdi = "fatma",
                Sifre = Md5Hasher.HashOlustur("fatma", "123abc")
            },
            new Uye
            {
                Id = 5,
                Ad = "Ali",
                Soyad = "Şahin",
                KullaniciAdi = "ali",
                Sifre = Md5Hasher.HashOlustur("ali", "password")
            });
        }
    }
}
