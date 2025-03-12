// See https://aka.ms/new-console-template for more information
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _14_Hesap_Makinesi
{
    public class Program
    {
        public static void Main()
        {
            do
            {
                try
                {
                    Hesapla();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (DevamMi());
        }

        private static void Hesapla()
        {
            int sayi1 = getInteger("Sayi 1: ");
            int sayi2 = getInteger("Sayi 2: ");
            char op = getOperator("İşlem: ");

            var result = op switch
            {
                '+' => Topla(sayi1, sayi2),
                '-' => Cikart(sayi1, sayi2),
                '/' => Bolme(sayi1, sayi2),
                '*' => Carp(sayi1, sayi2),
                _ => throw new Exception("Lütfen geçerli bir işlem giriniz.")
            };
            Console.WriteLine(result);
        }

        private static bool DevamMi()
        {
            Console.WriteLine("Devam mı: (e-h)");
            return Console.ReadLine().ToLower() == "e";
        }

        private static void Hata()
        {
            Console.WriteLine("hatalı giris");
        }
        private static char getOperator(string message)
        {
            char op;
            do
            {
                Console.Write(message);
            }
            while (!char.TryParse(Console.ReadLine(), out op));
            return op;
        }
        private static int getInteger(string message)
        {
            int number;
            do
            {
                Console.Write(message);
            }
            while (!int.TryParse(Console.ReadLine(), out number)); ;
            return number;
        }

        private static double Topla(double sayi1, double sayi2)
        {
            return sayi1 + sayi2;
        }
        private static double Cikart(double sayi1, double sayi2)
        {
            return sayi1 - sayi2;
        }
        private static double Bolme(double sayi1, double sayi2)
        {
            return sayi1 / sayi2;
        }
        private static double Carp(double sayi1, double sayi2)
        {
            return sayi1 * sayi2;
        }
    }
}