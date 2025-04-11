using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class InputHelper
    {
        /// <summary>
        /// Kullanıcıdan int bir veri alır.
        /// </summary>
        /// <param name="message">Kullanıcıya consolda gösterilen mesaj.</param>
        /// <returns>Alınan int değeri döndürür.</returns>
        public static int GetIntNumber(string message)
        {
            int number;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Lütfen sayısal bir veri giriniz.");
                Console.Write(message);
            }
            return number;
        }

        /// <summary>
        /// Kullanıcıdan double bir veri alır.
        /// </summary>
        /// <param name="message">Kullanıcıya consolda gösterilen mesaj.</param>
        /// <returns>Alınan double değeri döndürür.</returns>
        public static double GetDoubleNumber(string message)
        {
            double number;
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Lütfen sayısal bir veri giriniz.");
                Console.Write(message);
            }
            return number;
        }
        /// <summary>
        /// Kullanıcıdan string bir veri alır.
        /// </summary>
        /// <param name="message">Kullanıcıya consolda gösterilen mesaj.</param>
        /// <returns>Alınan string değeri döndürür.</returns>
        public static string GetString(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? string.Empty;
            return input;
        }
    }
}
