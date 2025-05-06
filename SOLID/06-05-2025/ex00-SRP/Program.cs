// SRP - Single Responsibility Principle

// Soru: JSON, XML dosyalarından veri okuyan yapıları yazınız.


// - SRP'ye uygun olmayan bir yapı
string DosyadanOku(string dosyaAdi)
{
    if (dosyaAdi.Contains("json"))
    {
        // JSON'dan oku
    }
    else if (dosyaAdi.Contains("xml"))
    {
        // XML'den oku
    }
    else
    {
        throw new Exception("Dosya tipi desteklenmiyor");
    }
    return "Okunan veri";
}

