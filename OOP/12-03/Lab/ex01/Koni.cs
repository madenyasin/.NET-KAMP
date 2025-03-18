using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex01
{
    internal class Koni : Silindir
    {      
        public override double HacimHesaapla()
        {
            return base.HacimHesaapla() * 0.3333;
        }
    }
}
