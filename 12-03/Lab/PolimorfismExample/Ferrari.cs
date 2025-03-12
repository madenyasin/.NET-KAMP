using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolimorfismExample
{
    internal class Ferrari : Araba
    {
        public override void Sur()
        {
            Console.WriteLine("Ferrari sürüyor...");
        }
    }
}
