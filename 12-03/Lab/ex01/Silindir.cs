using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex01
{
    internal class Silindir : Daire
    {
        public double Yukseklik { get; set; }
        public virtual double HacimHesaapla()
        {
            return base.AlanHesapla() * Yukseklik;
        }
    }
}
