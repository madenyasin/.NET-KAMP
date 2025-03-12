#region Clean Code
using System.Runtime.CompilerServices;

namespace _19_Clean_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * sınıflara ayırmal
             * yorum satırı kullanmak
             * summary kullanmak
             * boişluk kullanımı
             * hata yönetimi
             * 
             */

            // 1- isimlendirme
            // değişken ve metot isimleri kısa ve anlamlı olmalıdır.

            // 2- metot uzunluğu
            // metotları olabildiğince kısa tutalım. birinci sorumluluk üzerine odaklanın.

            // 3- yorumlar
            // kodun hedefine odaklanan yorumlar yazın.

            // 4- boşluk kullanın

            // 5- hata yönetimi

            //try
            //{
            //    // sadece exception fırlatabilecek kodlar
            //}
            //catch (OverflowException ex)
            //{
            //    // belirli durumlarda hata fırlat
            //}
            //catch (DivideByZeroException ex)
            //{
            //    // belirli durumlarda hata fırlat
            //}





            int sayi, sayac = 0, maksimumSayi = 0, ciftMaksimumSayi = 0;

            bool sayiMi = KullanıcıdanSayiAl(out sayi);

            if (sayiMi && sayi >= 0 && sayi != 1)
            {
                DegerleriBul(out ciftMaksimumSayi, out maksimumSayi, sayi, out sayac);

                DegerleriEkranaYaz(maksimumSayi, ciftMaksimumSayi, sayac);
            }
            else if (!sayiMi)
            {
                Console.WriteLine("girilen değer bir sayı değil.");
            }
            else if (sayi < 0)
            {
                Console.WriteLine("sayı negatif.");
            }
            else if (sayi == 1)
            {
                Console.WriteLine("sayıyı 1 girdiniz.");
            }





        }


        /// <summary>
        /// Gerekli döngüyü kullanarak değerleri bulur.
        /// </summary>
        /// <param name="ciftMaksimumSayi">Çift maksiumum sayı değerini alır.</param>
        /// <param name="maksimumSayi">Maksimum sayı değerini alır.</param>
        /// <param name="sayi">Sayı değerini alır.</param>
        /// <param name="sayac">Sayaç değerini alır.</param>
        /// <exception cref="NotImplementedException"></exception>
        private static void DegerleriBul(out int ciftMaksimumSayi, out int maksimumSayi, int sayi, out int sayac)
        {
            ciftMaksimumSayi = maksimumSayi = sayac = 0;
            while (sayi >= 2)
            {
                sayac++;
                if (sayi % 2 == 1)
                {
                    sayi = (sayi * 3) + 1;
                    sayac++;
                    ciftMaksimumSayi = 0;


                }

                ciftMaksimumSayi = ciftMaksimumSayi < sayac ? sayi : ciftMaksimumSayi;
                sayi /= 2;
            }


        }

        static void DegerleriEkranaYaz(int maksimumSayi, int ciftMaksimumSayi, int sayac)
        {
            Console.WriteLine($"Bu işlem sırasında ulaşılan maksimum sayı: {maksimumSayi}");
            Console.WriteLine($"Bu işlem sırasında sürekli çift olarak 1'e ulaşılan maksimum sayı: {ciftMaksimumSayi}");
            Console.WriteLine($"Bu işlem bitene kadarki adım sayısı: {sayac}");
        }

        static bool KullanıcıdanSayiAl(out int sayi)
        {
            Console.WriteLine("lütfen pozitif sayı giriniz: ");
            return int.TryParse(Console.ReadLine(), out sayi);
        }
        #endregion



