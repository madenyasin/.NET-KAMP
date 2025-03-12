




namespace _25_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            convertToEnglish("Fıstıkçı şahap");

            Console.WriteLine(IsValidTurkishIDNumber("11111111111"));

        }

        private static void convertToEnglish(string s)
        {
            string[] turkish = { "ç", "ğ", "ı", "ö", "ş", "ü" };
            string[] english = { "c", "g", "i", "o", "s", "u" };
            for (int i = 0; i < turkish.Length; i++)
            {
                s = s.Replace(turkish[i], english[i]);
            }
            Console.WriteLine(s);

        }
        private static bool IsValidTurkishIDNumber(string id)
        {
            if (!HasValidLength(id))
                return false;
            if (!ContainsOnlyDigits(id))
                return false;
            if (!StartsWithNonZero(id))
                return false;
            if (!ValidateTenthDigit(id))
                return false;
            if (!ValidateEleventhDigit(id))
                return false;
            return true;
        }

        private static bool ValidateEleventhDigit(string id)
        {
            int sumOfFirstTenDigit = 0;
            for (int i = 0; i < 10; i++)
            {
                sumOfFirstTenDigit += int.Parse(id[i].ToString());
            }
            return sumOfFirstTenDigit % 10 == int.Parse(id[10].ToString());
        }
        

        private static bool ValidateTenthDigit(string id)
        {
            int oddSum = 0;
            int evenSum = 0;

            for (int i = 0; i < 9; i++)
            {
                if (i % 2 == 0)
                {
                    evenSum += int.Parse(id[i].ToString());
                }
                else
                {
                    oddSum += int.Parse(id[i].ToString());
                }
            }

            int tenthDigit = ((oddSum * 7) - evenSum) % 10;
            if (tenthDigit != int.Parse(id[9].ToString()))
            {
                return false;
            }
            return true;

        }

        private static bool StartsWithNonZero(string id)
        {
            if (id[0] == 0)
            {
                return false;
            }
            return true;
        }

        private static bool ContainsOnlyDigits(string id)
        {
            foreach (var item in id)
            {
                if (!char.IsDigit(item))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool HasValidLength(string id)
        {
            return id.Length == 11;
        }
    }


}
