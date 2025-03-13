/*
 bir market için uygulama yazılacaktır.

market; yumurta, şişe süt, bulgur, kağıt havlu, bardak, ürünlerini satmaktadır.

ürünlerin=> id,ad,fiyat ortak nitelikleri

ürün ekleme
ürün silme
raporlar
*** tüm ürünlerin listesi
*** bozuk ürünlerin listesi
*** kırık ürünlerin listesi
*** kullanma tarihi geçmiş olan ürünlerin listesi
 */

using ex02;
UrunYonetim urunYonetim = new UrunYonetim();

urunYonetim.UrunEkle(new Bardak()
{
    ID = 1,
    Ad = "Bardak",
    Fiyat = 10,
    KirikMi = true
});

urunYonetim.UrunEkle(new Bardak()
{
    ID = 2,
    Ad = "Bardak",
    Fiyat = 10,
    KirikMi = false
});

urunYonetim.UrunEkle(new Bulgur
{
    ID = 3,
    Ad = "Bulgur",
    Fiyat = 5,
    SonTarih = DateTime.Now.AddDays(-1)
});

urunYonetim.UrunEkle(new Bulgur
{
    ID = 4,
    Ad = "Bulgur",
    Fiyat = 5,
    SonTarih = DateTime.Now.AddDays(1)
});

urunYonetim.UrunEkle(new Yumurta
{
    ID = 5,
    Ad = "Yumurta",
    Fiyat = 2,
    SonTarih = DateTime.Now.AddDays(-1)
});

urunYonetim.UrunEkle(new Yumurta
{
    ID = 6,
    Ad = "Yumurta",
    Fiyat = 2,
    KirikMi = true,
    SonTarih = DateTime.Now.AddDays(1)
});

urunYonetim.UrunEkle(new SiseSut
{
    ID = 7,
    Ad = "Sise Sut",
    Fiyat = 3,
    KirikMi = false,
    SonTarih = DateTime.Now.AddDays(-1)
});

urunYonetim.UrunEkle(new SiseSut
{
    ID = 8,
    Ad = "Sise Sut",
    Fiyat = 3,
    KirikMi = true,
    SonTarih = DateTime.Now.AddDays(1)
});

urunYonetim.UrunEkle(new KagitHavlu
{
    ID = 9,
    Ad = "Kagit Havlu",
    Fiyat = 1
});



Console.WriteLine("---------------------TÜM ÜRÜNLER-----------------------------");
foreach (var urun in urunYonetim.UrunleriGetir())
{
    Console.WriteLine(urun);
}

Console.WriteLine("--------------------BOZUK ÜRÜNLER------------------------------");

foreach (var item in urunYonetim.BozukUrunleriGetir)
{
    Console.WriteLine(item);
}

Console.WriteLine("--------------------KIRIK ÜRÜNLER------------------------------");

foreach (var item in urunYonetim.KirikUrunleriGetir)
{
    Console.WriteLine(item);
}

Console.WriteLine("--------------------SKT GEÇMİŞ ÜRÜNLER------------------------------");

foreach (var item in urunYonetim.BozukUrunleriGetir)
{
    Console.WriteLine(item);
}