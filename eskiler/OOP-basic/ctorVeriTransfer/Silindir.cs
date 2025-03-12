using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ctorVeriTransfer
{
    internal class Silindir:Daire
    {
        public Silindir(double r, double h): base(r)
        {
            Console.WriteLine("Silindir nesnesi oluşturuldu.");
        }
    }
}
