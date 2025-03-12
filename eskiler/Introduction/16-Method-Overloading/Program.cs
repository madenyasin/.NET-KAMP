namespace _16_Method_Overloading
{
    internal class Program
    {
        public static void Main()
        {
            // Method Overloading (aşırı yükleme): bir metodun adının aynı imzalarının (parametrelerinin) farklı olduğu bir çok kullanım gerçekleştirebiliriz.

            //EkranaYaz(45);
            //EkranaYaz();
            //EkranaYaz("yasin");
            //EkranaYaz("Yasin", "Maden");


        

            Console.WriteLine(MailOlustur("Yasin"));
            Console.WriteLine(MailOlustur("Yasin", "maden"));
            Console.WriteLine(MailOlustur("Yasin", "maden", "bilgeadam.com"));

        }

        static string MailOlustur(string isim)
        {
            return $"{isim}@bilgeadam.com".ToLower();
        }

        static string MailOlustur(string isim, string soyIsim)
        {
            return $"{isim}.{soyIsim}@bilgeadam.com".ToLower();
        }

        static string MailOlustur(string isim, string soyIsim, string domain)
        {
            return $"{isim}.{soyIsim}@{domain}".ToLower();
        }




        static int EkranaYaz(int yas)
        {
            Console.WriteLine($"merhaba yaşınız: {yas}");
            return 1;
        }

        static void EkranaYaz()
        {
            Console.WriteLine("Mehrba dünya");
        }

        static void EkranaYaz(string ad)
        {
            Console.WriteLine($"Mehrba {ad}");
        }
        static void EkranaYaz(string ad, string soyad)
        {
            Console.WriteLine($"Merhaba {ad} {soyad}");
        }

    }
}