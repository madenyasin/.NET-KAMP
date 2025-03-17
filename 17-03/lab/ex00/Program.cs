/* soru: 1 ile 10 arası not verilen bir sistemde 100 öğrenci için rastgele notları oluştup
 * bir dosyaya yazınız.
 * sonra ise tüm not verilerini bu dosyadan okuyup her notun frekansını bulunuz.
 */

using System.Xml.Serialization;

string filePath = "notlar.txt";
Dictionary<int, int> notlar = new();

NotlariOlustur(filePath);
NotlariOku(filePath);
NotlariYazdir(notlar);


void NotlariOlustur(string path)
{
    Random rnd = new Random();
    StreamWriter sw = new(path);
    for (int i = 0; i < 100; i++)
    {
        int not = rnd.Next(1, 11);
        sw.WriteLine(not);
    }
    sw.Close();
}

void NotlariOku(string path)
{
    
    StreamReader sr = new(path);
    while (!sr.EndOfStream)
    {
        string line = sr.ReadLine();
        if (!int.TryParse(line, out int not))
        {
            Console.WriteLine("Notlar okunamadı");
        }

        // okunan not dictionary'de var mı kontrol et
        if (notlar.ContainsKey(not))
            notlar[not]++; // varsa 1 arttır
        else
            notlar[not] = 1; // yoksa sayacını oluştur

    }
    sr.Close();
}

void NotlariYazdir(Dictionary<int, int> notlar)
{
    foreach (var not in notlar)
    {
        Console.WriteLine($"{not.Key} : {not.Value}");
    }
}