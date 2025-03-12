
//#region 2

//int number1, number2;

//do
//{
//    Console.Write("Sayı 1: ");
//}
//while (!int.TryParse(Console.ReadLine(), out number1));

//do
//{
//    Console.Write("Sayı 2: ");
//}
//while (!int.TryParse(Console.ReadLine(), out number2));

//Console.WriteLine(number1 + number2);
//#endregion


//#region 3
//int number1, number2;

//do
//{
//    Console.Write("Sayı 1: ");
//}
//while (!int.TryParse(Console.ReadLine(), out number1));

//do
//{
//    Console.Write("Sayı 2: ");
//}
//while (!int.TryParse(Console.ReadLine(), out number2));

//Console.WriteLine((number1 * number1) + (number2 * number2));
//#endregion

//#region 4
// * 1'den 100'e kadar olan sayılarının küplerinin toplamını bulan
//    programın algoritma ve akış diyagramını çiziniz
//*/

//int sum = 0;
//for (int i = 1; i <= 100; i++)
//{
//    sum += (i * i * i);
//}
//Console.WriteLine(sum);

//#endregion


//#region 5
//int age;
//DateTime date;
//do
//{
//    Console.WriteLine("Lütfen doğum tarihinizi giriniz: (GG.AA.YYYY)");
//}
//while (!DateTime.TryParse(Console.ReadLine(), out date));

//age = DateTime.Now.Year - date.Year;
//Console.WriteLine($"{age.ToString()} yaşındasınız.");
//#endregion




using System.Security.Cryptography.X509Certificates;

namespace Algoritma_Sorulari
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(FaktoriyelHesapla());
            //Console.WriteLine(CarpmaIslemi7());
            //Console.WriteLine(BolmeIslemi8());
            //Console.WriteLine(ManualModAlma9());
            //Console.WriteLine(BasamakHesapla10());
            //Console.WriteLine(Algoritma11());
            //Console.WriteLine(Algoritma12());
            //Algoritma13();
            //Algoritma14();
            //Algoritma15();
            //Console.WriteLine(Algoritma16());
            //Console.WriteLine(Algoritma17());
            //Algoritma18();
            //Algoritma19();
            //Algoritma20();
            //Algoritma21();
            LotoOdev();

        }
        public static void LotoOdev()
        {
            /*
             
                ÖDEV: sayısal loto
                kullanıcı kaç kolon oynayacağını seçecek
                8 kolonu aşamayacak
                her kolonda 6 sayı olacak
                sayılar 1-49 arasında olacak
                her bir kolondaki 6 sayı da birbirinden farklı olacak
                kolonların çıktısı
                */
            int kolonSayisi;
            Random random = new Random();
            do
            {
                kolonSayisi = GetIntegerNumber("Kolon sayisi: ");
            }
            while (kolonSayisi <= 0 || kolonSayisi > 8);


            for (int i = 0; i < kolonSayisi; i++)
            {
                var kolonList = new List<int>();
                for (int j = 0; j < 6; j++)
                {
                    int sayi = random.Next(1, 49);
                    while (kolonList.Contains(sayi))
                    {
                        sayi = random.Next(1, 49);
                    }
                    kolonList.Add(sayi);
                }
                Console.WriteLine(string.Join("\t", kolonList));
            }

        }
        public static void Algoritma21()
        {
            int sum = 0;
            for (int i = 0; i <= 100; i++)
            {
                sum += i;
            }
            var list = new List<int>();

            for (int i = 1; i < sum; i++)
            {
                if (sum % i == 0)
                {
                    list.Add(i);
                }
            }
            if (list.Sum() == sum)
                Console.WriteLine("mükemmel");
            else
                Console.WriteLine("değil");
        }

        public static void Algoritma20()
        {
            int sayi = GetIntegerNumber();
            var list = new List<int>();
            for (int i = 1; i < sayi; i++)
            {
                if (sayi % i == 0)
                {
                    list.Add(i);
                }
            }
            if (list.Sum() == sayi)
            {
                Console.WriteLine("mükemmel");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
        public static void Algoritma19()
        {
            int sayi = GetIntegerNumber();
            if (sayi < 0)
            {
                Console.WriteLine("-");
            }
            else if (sayi > 0)
            {
                Console.WriteLine("+");
            }
            else
            {
                Console.WriteLine(0);
            }
        }
        public static void Algoritma18()
        {
            var fibonacci = new List<int>();
            fibonacci.Add(0);
            fibonacci.Add(1);

            for (int i = 2; i < 10; i++)
            {
                int next = fibonacci[i - 2] + fibonacci[i - 1];
                fibonacci.Add(next);
            }

            Console.WriteLine(string.Join("-", fibonacci));
        }
        public static int Algoritma17()
        {
            int x = GetIntegerNumber();
            int y = GetIntegerNumber();

            var carpanlarX = new List<int>();
            var carpanlary = new List<int>();

            for (int i = 1; i < x; i++)
            {
                if (x % i == 0)
                {
                    carpanlarX.Add(i);
                }
            }

            for (int i = 1; i < y; i++)
            {
                if (y % i == 0)
                {
                    carpanlary.Add(i);
                }
            }

            if ((x == carpanlary.Sum()) && (y == carpanlarX.Sum()))
            {
                return 1;
            }
            return -1;
        }
        public static int Algoritma16()
        {
            int sayi = GetIntegerNumber();
            if (sayi % 5 == 0)
                return 1;
            else
                return -1;
        }
        public static void Algoritma15()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (global::System.Int32 j = 1; j < 10; j++)
                {
                    Console.WriteLine($"{i}x{j} = {i * j}");
                }
                Console.WriteLine();
            }
        }
        public static void Algoritma14()
        {
            int sumNegatives = 0;
            int multiplyEvens = 1;
            int counterForSeven = 0;
            List<int> list = new List<int>();

            for (int i = 1; i <= 25; i++)
            {
                list.Add(GetIntegerNumber($"{i}. sayıyı giriniz: "));
            }
            foreach (var item in list)
            {
                if (item < 0)
                {
                    sumNegatives += item;
                }
                else if (item % 2 == 0)
                {
                    multiplyEvens *= item;
                }

                if (item == 7)
                {
                    counterForSeven++;
                }
            }

            Console.WriteLine(sumNegatives);
            Console.WriteLine(multiplyEvens);
            Console.WriteLine(counterForSeven);
        }
        public static void Algoritma13()
        {
            for (int i = 10; i <= 10000; i++)
            {
                int sqrt = (int)Math.Sqrt(i);
                if (sqrt * sqrt == i)
                {
                    Console.WriteLine(i);
                }
            }
        }


        public static double Algoritma12()
        {
            List<int> list = new List<int>();
            int sumEvenNumber = 0;
            int sumOddNumber = 0;
            for (int i = 1; i <= 20; i++)
            {
                list.Add(GetIntegerNumber($"{i}. sayıyı giriniz: "));
            }
            foreach (var item in list)
            {
                if (item % 2 == 0)
                {
                    sumEvenNumber += item;
                }
                else
                {
                    sumOddNumber += item;
                }
            }
            Console.WriteLine(sumEvenNumber);
            Console.WriteLine(sumOddNumber);
            return (double)sumEvenNumber / (double)sumOddNumber;
        }

        public static int Algoritma11()
        {
            List<int> basamaklar = new List<int>();
            int sayi = GetIntegerNumber();
            int temp = sayi;
            while (temp > 0)
            {
                int basamak = temp % 10;
                basamaklar.Add(basamak);
                temp /= 10;
            }
            for (int i = 0; i < basamaklar.Count; i++)
            {
                basamaklar[i] = (int)Math.Pow(basamaklar[i], 3);
            }
            return (basamaklar.Sum() == sayi) ? 1 : -1;
        }

        public static int BasamakHesapla10()
        {
            // kaç defa 10'a bölünüyor?
            int sayac = 0;
            int sayi = GetIntegerNumber();
            if (sayi < 0)
            {
                sayi *= -1;
            }
            if (sayi == 0)
            {
                return 0;
            }
            while (sayi > 0)
            {
                sayi /= 10;
                sayac++;
            }

            return sayac;


        }

        public static int ManualModAlma9()
        {
            int sayi = GetIntegerNumber("Sayi: ");
            int mod = GetIntegerNumber("Mod: ");
            return sayi % mod;
        }

        public static int BolmeIslemi8()
        {

            int bolunen = GetIntegerNumber("Bölünen: ");
            int bolen = GetIntegerNumber("Bölen: ");

            int i = 1;

            for (; bolunen > bolen; i++)
            {
                bolunen = bolunen - bolen;
            }
            return i;
        }


        public static int CarpmaIslemi7()
        {
            int sum = 0;
            int number1 = GetIntegerNumber("Sayı 1: ");
            int number2 = GetIntegerNumber("Sayı 2: ");

            if (number1 == 0 || number2 == 0)
            {
                return 0;
            }

            for (int i = 0; i < number1; i++)
            {
                sum += number2;
            }
            return sum;
        }
        public static int FaktoriyelHesapla()
        {
            int result = 1;
            int number = GetIntegerNumber("Sayi: ");

            if (number == 0)
            {
                return 1;
            }
            else if (number < 0)
            {
                return -1;
            }

            for (int i = number; i >= 1; i--)
            {
                result *= i;
            }
            return result;

        }

        public static int GetIntegerNumber(string promptMessage = "Sayı: ")
        {
            while (true)
            {
                Console.Write(promptMessage);

                if (int.TryParse(Console.ReadLine(), out int inputValue))
                {
                    return inputValue;
                }
                Console.WriteLine();
            }
        }
    }


}
