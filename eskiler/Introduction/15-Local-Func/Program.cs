
namespace _15_Local_Func
{
    public class Program
    {
        static void Main()
        {
            int[] sayilar1 = { 1, 2, 3 };
            Console.WriteLine(KarekokHesapla(sayilar1));
        
            double KarekokHesapla(int[] sayilar)
            {
                return Math.Sqrt(sayilar.Sum());
            }
        
        
        }

        //private static bool KarekokHesapla(int[] sayilar1)
        //{
        //    throw new NotImplementedException();
        //}
    }
}