namespace lab00
{
    public class Program
    {
        public static void Main()
        {
            int[] a = { 1, 2, 3 };
            int[] b = reverseArray(a);
            foreach (var item in b)
            {
                Console.WriteLine(item);
            }
        }

        private static int MaxOfArray(int[] array)
        {
            return array.Max();
        }
        private static int HarfSay(string cumle, char harf)
        {
            int counter = 0;
            foreach (var item in cumle)
            {
                if (item == harf)
                {
                    counter++;
                }
            }
            return counter;
        }

        private static int[] reverseArray(int[] array)
        {
            int[] newArray = new int[array.Length];
            int j = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                newArray[j] = array[i];
                j++;
            }

            return newArray;
        }


        private static double Algoritma0(int s1, int s2)
        {
            return Math.Sqrt(s1 * s2);
        }

        private static int[] Algoritma1(int[] array)
        {
            List<int> list = new List<int> { };

            foreach (var item in array)
            {
                if(item % 2 == 1)
                {
                    list.Add(item);
                }
            }

            return [];
            
        }

    }
}