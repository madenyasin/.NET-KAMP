/*
 * 
 * başla
 * 1. sayıyı gir ve değişkene ata
 * 2. sayıyı gir ve değişkene ata
 * 3. sayıyı gir ve değişkene ata
 * toplam değişkeni oluştur ev tüm değerlerin toplamını ata
 * toplam / 3 sonucunu ekrana yazdır
 * bitir
 */

Console.Write("1. sayıyı giriniz: ");
int num1 = Convert.ToInt32(Console.ReadLine());

Console.Write("2. sayıyı giriniz: ");
int num2 = Convert.ToInt32(Console.ReadLine());

Console.Write("3. sayıyı giriniz: ");
int num3 = Convert.ToInt32(Console.ReadLine());

double toplam = num1 + num2 + num3;

Console.WriteLine($"ORTALAMA:  {toplam / 3}");


namespace MyNamespace
{
    // class, enum, struct, interface
    public class MyClass
    {
        /*
         * üyeler
         * property
         * methods
         * fields
         * constructors
         */

        public void Main()
        {
            Console.WriteLine("merhaba");
        }
    }
}