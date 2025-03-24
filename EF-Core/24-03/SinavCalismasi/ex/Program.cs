/*
 * şehirler arası bir otobüs firması için bir oop uygulaması geliştirilecektir.
 * firmanın;
 * tek tip otobüsleri vardır.
 * her otobüs için 40 yolcu + 2 şoför + 1 muavin + 1 host/hostes  olmak üzere 4 personeli bulunmaktadır.
 * 
 * şoför koltuğuna sadece ehliyeti olan personel oturabilir. şoför yanı koltuğuna ise sadece personel oturabilir.
 * 
 * yolcular; yanlarında maksimum 20 kg bagaj alabilirler. 
 * Ayrıca otobüslerde küçük boyutlu 3 adet evcil hayvanlar için bagaj yeri bulunmaktadır.
 * personel ile ilgili; ad, soyad, yas, tecrube(yıl) bilgileri tutulacaktır.
 * yolcular için ise; ad, soyad, gideceği lokasyon, bagaj, varsa evcil hayvan,
 * 
 * evcil hayvanlar için ise; ad, yaş, cinsi
 * 
 * sadece tek otobüs için;
 * rastgele; personelleri oluşturunuz.
 * rastgele; yolcuları oluşturunuz.
 * 
 * uygulama çalıştığında;
 * 1- otobüsü oluştur.
 * 2- otobüsü listele
 * 3- otobüsün verilerini dosyaya json olarak yaz.
 * 
 * 
 * not: çalışma kısmı hariç tüm yapılar dll'de tutulmalı.
 */

using Newtonsoft.Json;
using OtobusFirma;



OtobusManager otobusManager = new OtobusManager();



while (true)
{
    Menu();
}


void Menu()
{
    Console.WriteLine("-----------------------------");
    Console.WriteLine("1: otobüsü oluştur");
    Console.WriteLine("2: otobüsü listele");
    Console.WriteLine("3: otobüsüs dosyaya yaz");

    int secim = GetIntNumber("Lütfen yapmak istediğiniz işlemi seçiniz: ");
    Console.Clear();

    switch (secim)
    {
        case 1:
            otobusManager.OtobusOlustur();

            break;
        case 2:
            foreach (var item in otobusManager.Data)
            {
                Console.WriteLine(item);
            }
            

            break;


        case 3:
            string json = JsonConvert.SerializeObject(otobusManager.Data.ToArray(), Formatting.Indented);

            //write string to file
            System.IO.File.WriteAllText(@"data.txt", json);

            break;
        
        default:
            break;
    }
}

static int GetIntNumber(string message)
{
    int number;
    Console.Write(message);
    while (!int.TryParse(Console.ReadLine(), out number))
    {
        Console.WriteLine("Lütfen sayısal bir veri giriniz.");
        Console.Write(message);
    }
    return number;
}
