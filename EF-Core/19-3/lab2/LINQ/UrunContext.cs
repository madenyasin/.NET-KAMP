using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class UrunContext
    {
        public static List<Kategori> Kategoriler => new List<Kategori>
        {
            new Kategori{KategoriID = 1, KategoriAdi="Kırtasiye"},
            new Kategori{KategoriID = 2, KategoriAdi="Hobi"},
            new Kategori{KategoriID = 3, KategoriAdi="Hediyelik Eşya"},
            new Kategori{KategoriID = 4, KategoriAdi="Elektronik"},
        };

        public static List<Urun> Urunler => new()
        {
            new Urun {UrunID = 111, UrunAdi="Defter", Fiyat = 50, kategoriID = 1},
            new Urun {UrunID = 117, UrunAdi="Pergel", Fiyat = 155, kategoriID = 1},
            new Urun {UrunID = 118, UrunAdi="Maket Bıçak", Fiyat = 2500, kategoriID = 2},
            new Urun {UrunID = 119, UrunAdi="Puzzle", Fiyat = 500, kategoriID = 2},
            new Urun {UrunID = 112, UrunAdi="Vazo", Fiyat = 750, kategoriID = 3},
            new Urun {UrunID = 113, UrunAdi="Magnet", Fiyat = 50, kategoriID = 3},
            new Urun {UrunID = 114, UrunAdi="Anahtarlık", Fiyat = 30, kategoriID = 3},
            new Urun {UrunID = 115, UrunAdi="Hesap Makinesi", Fiyat = 1500, kategoriID = 4},
        };
    }
}
