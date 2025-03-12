using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_11_3
{
    internal class yariZamanliPersonel: Personel
    {
        public double CalismaSaati { get; set; }
        public double SaatUcreti { get; set; }
        public double PrimHesapla()
        {
            return base.ToplamSatis * 0.01;
        }
        public double MaasHesapla()
        {
            return (CalismaSaati * SaatUcreti) + PrimHesapla(); 
        }
        public override string ToString()
        {
            return base.ToString() + $"Prim: {PrimHesapla()}, Maas: {MaasHesapla()}";
        }
    }
}
