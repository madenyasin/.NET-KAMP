using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmaray_Revize
{
    public class GetInput
    {
        /// <summary>
        /// Kullanıcıdan integer bir sayı alır.
        /// </summary>
        /// <param name="message">Kullanıcıya consolda gösterilecek mesaj.</param>
        /// <returns>Kullanıcıdan alınan integer değeri döndürür.</returns>
        public static int GetInt(string message)
        {
            Console.Write(message);
            int input = 0;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                Console.Write(message);
            }
            return input;
        }

        /// <summary>
        /// Kullanıcıdan pozitif bir integer sayı alır.
        /// </summary>
        /// <param name="message">Kullanıcıya consolda gösterilecek mesaj.</param>
        /// <returns>Kullanıcıdan alınan pozitif integer değeri döndürür.</returns>
        public static int getPositiveInt(string message)
        {
            int input;
            do
            {
                input = GetInt(message);
            }
            while (input <= 0);
            return input;
        }

        /// <summary>
        /// Kullanıcıdan belirli bir aralıkta integer bir sayı alır.
        /// </summary>
        /// <param name="message">Kullanıcının girdiği integer sayıyı döner.</param>
        /// <param name="min">Girilebilecek minimum integer değer.</param>
        /// <param name="max">Girilebilecek maximum integer değer.</param>
        /// <returns>Kullanıcının girdiği integer sayıyı döner.</returns>
        public static int getChoice(string message, int min, int max)
        {
            int choice;
            do
            {
                choice = GetInt(message);
            }
            while (choice < min || choice > max);
            return choice;
        }

        /// <summary>
        /// Kullanıcıdan string bir değer alır.
        /// </summary>
        /// <param name="message">Kullanıcıya consolda gösterilecek mesaj.</param>
        /// <returns>Kullanicinin girdiği string veriyi döner.</returns>
        public static string GetString(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
