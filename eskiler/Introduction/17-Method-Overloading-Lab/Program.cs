
namespace _17_Method_Overloading_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] calisanlar = new string[] { "yasin", "ahmet", "tuğba", "nigar", "maden" };
            int[] maaslar = new int[5];
            do
            {


                for (int i = 0; i < calisanlar.Length; i++)
                {
                    Console.WriteLine($"{i}\t{calisanlar[i]}");
                }
                Console.Write("ÇALIŞAN SEÇ: ");
                int index = int.Parse(Console.ReadLine());

                Console.Write("ÇALIŞMA SAATİ: ");
                int saat = int.Parse(Console.ReadLine());

                Console.Write("SAATLİK ÜCRET: ");
                int saatlikUcret = int.Parse(Console.ReadLine());

                if (saat <= 270)
                {
                    maaslar[index] = MaasHesapla(saat, saatlikUcret);
                }
                else
                {
                    double mesai = MesaiHesapla(saat);
                    maaslar[index] = (int)MaasHesapla(saat, saatlikUcret, mesai);

                }

                Console.WriteLine("devam etmek istiyor musunuz? (e-h)");
            }
            while (Console.ReadLine().ToLower() == "e");
            

            for (int i = 0; i < calisanlar.Length; i++)
            {
                Console.WriteLine($"{calisanlar[i]}, maas: {maaslar[i]}");
            }


        }

        private static double MesaiHesapla(int saat, double mesaiUcreti = 550)
        {
            return saat - 270;
        }

        private static int MaasHesapla(int saat, int ucret)
        {
            if (saat >= 0)
            {
                return saat * ucret;

            }
            else
            {
                throw new Exception("çalışma saati sıfırdan küçük olamaz.");
            }
        }

        private static double MaasHesapla(int saat, int ucret, double mesai)
        {
            return (saat * ucret) + (550 * mesai);
        }
    }
}
