using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex01
{
    internal class Daire
    {
        public double Yaricap { get; set; }
        public double AlanHesapla()
        {
            return Math.PI * Yaricap * Yaricap;
        }
    }
}
