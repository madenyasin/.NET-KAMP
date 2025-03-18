/*
 
 
 
 
 
 */
using ex00;

List<int> sayilar = new List<int> { 1, 2, 23, 56, 22, 14, 66, 48, 29 };

sayilar.Sort();

foreach (var item in sayilar)
{
    Console.WriteLine(item);
}

Urun urun1 = new Urun() { UrunID = 24, UrunAdi = "Kalem", Fiyat = 50 };
Urun urun2 = new Urun() { UrunID = 14, UrunAdi = "Silgi", Fiyat = 20 };
Urun urun3 = new Urun() { UrunID = 66, UrunAdi = "Defter", Fiyat = 100 };

List<Urun> urunler = new List<Urun> { urun1, urun2, urun3 };

urunler.Sort();

foreach (var item in urunler)
{
    Console.WriteLine(item);
}

