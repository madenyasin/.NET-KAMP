/*
 *  bir depo sınıfında
 *  televizyon, buzdolabı, çamaşır makinesi tutulmaktadır
 *  bu depoyu simule eden sınıfları OOP kurallarına göre yazınız.
 *  
 *  tv - id,marka, model,aciklama,fiyat
 *  buzdolabı - id, marka, model, aciklama, fiyat, no frost mu
 *  çamaşır mak - id, marka, model, aciklama, fiyat, devir
 *
 *
 *  raporlar
 *  depodaki tüm ürünlerin listesi
 *  depodaki tüm ürünlerin toplam fiyatı
 *  
 * */


using ex03;

Depo depo = new Depo();
Televizyon tv = new Televizyon()
{
    TelevizyonID = 120,
    Marka = "Samsung",
    Model = "UE55NU8000",
    Aciklama = "4K UHD TV",
    Fiyat = 5000

};
Buzdolabı bd = new Buzdolabı()
{
    BuzdolabiID = 121,
    Marka = "Beko",
    Model = "RCNA365E30ZX",
    Aciklama = "No Frost Buzdolabı",
    Fiyat = 3000,
    NoFrostMu = true
};
CamasirMakinesi cm = new CamasirMakinesi()
{
    CamasirMakinesiID = 122,
    Marka = "Arçelik",
    Model = "LFS 1000",
    Aciklama = "1000 Devir Çamaşır Makinesi",
    Fiyat = 2000,
    DevirSayisi = 1000
};

depo.Ekle(tv);
depo.Ekle(cm);
depo.Ekle(bd);

foreach (var item in depo.EsyaListesiGetir())
{
    Console.WriteLine(item);
}

Console.WriteLine(depo.ToplamFiyat());
//----------------------------------------------------------------

