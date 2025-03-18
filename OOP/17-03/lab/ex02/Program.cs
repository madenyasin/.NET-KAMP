using ex02;

List<Urun> urunler = new()
{
    new Urun{ UrunID = 1, UrunAd = "Laptop", Fiyat = 5000, Kategori = "Elektronik" },
    new Urun{ UrunID = 2, UrunAd = "Klavye", Fiyat = 100, Kategori = "Elektronik" },
    new Urun{ UrunID = 3, UrunAd = "Fare", Fiyat = 50, Kategori = "Elektronik" },
    new Urun{ UrunID = 4, UrunAd = "Bardak", Fiyat = 10, Kategori = "Ev" },
    new Urun{ UrunID = 5, UrunAd = "Tabak", Fiyat = 20, Kategori = "Ev" },
    new Urun{ UrunID = 6, UrunAd = "Çatal", Fiyat = 5, Kategori = "Ev" },
};

Urun FindById(int id)
{
    return urunler.FirstOrDefault(u => u.UrunID == id);
}

Console.WriteLine("----------------------------------");
Console.WriteLine(FindById(5));

IEnumerable<Urun> FindByCategory(string category)
{
    var filteredProducts = urunler.Where(urun =>
    {
        return urun.Kategori == category;
    });

    return filteredProducts;
}

Console.WriteLine("----------------------------------");
foreach (var item in FindByCategory("Ev"))
{
    Console.WriteLine(item);
}

IEnumerable<Urun> FindByInChar(char ch)
{
    var filteredProducts = urunler.Where(urun =>
    {
        return urun.UrunAd.Contains(ch);
    });

    return filteredProducts;
}
Console.WriteLine("----------------------------------");
foreach (var item in FindByInChar('a'))
{
    Console.WriteLine(item);
}


//----------------------------------------------------


Yazdir(Filtrele(x => x.UrunID == 5));
Yazdir(Filtrele(x => x.Kategori == "Ev"));
Yazdir(Filtrele(x => x.UrunAd.Contains('a')));


IEnumerable<Urun> Filtrele(Func<Urun, bool> where)
{
    return urunler.Where(where);
}

void Yazdir(IEnumerable<Urun> urunler)
{
    foreach (var item in urunler)
    {
        Console.WriteLine(item);
    }
}