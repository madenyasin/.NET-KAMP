using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_3
{
    internal class Kitap
    {
        ~Kitap()
        {
            Console.WriteLine("object destroyed!");
        }
    }
}
