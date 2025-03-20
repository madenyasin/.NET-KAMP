// LINQ to Object

//LINQ sorguları 2 şekilde yazılır.

// 1- LIKE SQL


//Sorgular
//1- Tüm ürünler

using LINQ;

var result = from u in UrunContext.Urunler
             select u;

var result2 = from urun in UrunContext.Urunler
              where urun.kategoriID == 3
              select urun;

var result3 = from u in UrunContext.Urunler
              orderby u.Fiyat descending
              select u;

var result4 = from u in UrunContext.Urunler
              join k in UrunContext.Kategoriler
              on u.kategoriID equals k.KategoriID
              select new { u.UrunID, u.UrunAdi, u.Fiyat, k.KategoriAdi };
var result5 = (from u in UrunContext.Urunler
              join k in UrunContext.Kategoriler
              on u.kategoriID equals k.KategoriID
              select new { u.UrunID, u.UrunAdi, u.Fiyat, k.KategoriAdi }).Take(3);

Yazdir(result5);
Console.WriteLine("----------------------------------");

// 2- Expression Tree
var sonuc = UrunContext.Urunler.Select(urun => urun);
var sonuc2 = UrunContext.Urunler.Where(urun => urun.kategoriID == 3);
var sonuc3 = UrunContext.Urunler.OrderByDescending(urun => urun.Fiyat);
var sonuc4 = UrunContext.Urunler.Join(
    UrunContext.Kategoriler,
    x => x.kategoriID,
    y => y.KategoriID,
    (x, y) => new { x.UrunID, x.UrunAdi, x.Fiyat, y.KategoriAdi });

Yazdir(sonuc4);
Console.WriteLine("----------------------------------");


void Yazdir<T>(IEnumerable<T> list)
{
    foreach (var item in list)
    {
        Console.WriteLine(item);
    }
}




/*
 * NŞA'da; LINQ sorguları Deffered modda çalışır.
 * Yani; Sorgu yazıldığı yerde değil, çağırıldığında derlenir.
 * ToList(), ToArray() vb gibi Immediate Mode olarak çalışır.
 * 
 * 
int id = 111;

var sorgu = (from u in UrunContext.Urunler
            where u.UrunID == id
            select u).ToList();
id = 117;
Yazdir(sorgu);
*/