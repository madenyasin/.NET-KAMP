namespace _13_Methods
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine();
            Random rnd = new Random();
            EkranaYaziYaz();
            EkranaIsimYaz("yasin", 23);
            string fullName = AdSoyadBirlestir();
            Console.WriteLine(fullName);
            string[] mailAdresleri = Ayristirici("maden.yasin@hotmail.com;zafer.dorter@gmail.com,blabla@mail.com");
            Console.WriteLine(string.Join("\n", mailAdresleri));

            Console.WriteLine(Topla(10, 2));
            Console.WriteLine(Bolme(10, 2));
            Console.WriteLine(CiftMi(21));
            Console.WriteLine(CiftMi(20));
        }


        private static int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
        private static double Bolme(double sayi1, double sayi2)
        {
            return sayi1 / sayi2;
        }
        private static bool CiftMi(int sayi)
        {
            return sayi % 2 == 0;
        }


        // değer döndürmeyen - parametresiz

        private static void EkranaYaziYaz()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("merhaba");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        // değer döndürmeyen - parametreli
        private static void EkranaIsimYaz(string isim, int yas)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(isim);
            Console.WriteLine("yas: " + yas);
            Console.ForegroundColor = ConsoleColor.White;
        }

        // değer döndüren - parametresiz

        private static string AdSoyadBirlestir()
        {
            return "Yasin" + ' ' + "Maden";
        }

        // değer döndüren - parametreli
        private static string[] Ayristirici(string mailAdresleri)
        {
            return mailAdresleri.Split(',', ';');
        }


        /*
       * erişimBelirleyicisi - niteleyici - dönüşTipi - metodAdı
       * {kodlar}
      */

        /*
         * 
         * 1) erişim belirleyicisi (access modifier): metota kullanım yetkisi verir.
         * 
         * metotların default eb'si private'tır
         * private: bu metoda sadece kendi sınıfı içerisinden erişilebilir
         * public: projenin her noktasından erişilebilir.
         * 
         * 2) niteleyici (static): oluşturduğumuz methodu bellekte sabit hale getirir.
         * static değilse nesne oluşturup methoda erişirilir.
         * statc ise nesne oluşturmadan direkt sınıf adıyla methoda erişebiliriz.
         * 
         * 3) dönüş tipi: metodun çalışması sonucu kendisinin bir bilgi verip veremeyeceğini belirlediğimiz yerdir.
         * 
         */
    }
}