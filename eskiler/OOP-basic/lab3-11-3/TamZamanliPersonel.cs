using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_11_3
{
    internal class TamZamanliPersonel : Personel
    {
        public double TabanUcret { get; set; } = 10_000;
        public double PrimHesapla()
        {
            if (base.ToplamSatis >= 0 && base.ToplamSatis < 250_000)
            {
                return base.ToplamSatis * 0.01;
            }
            else if (base.ToplamSatis < 500_000)
            {
                return base.ToplamSatis * 0.02;
            }
            return base.ToplamSatis * 0.03;
        }
        public double MaasHesapla()
        {
            return TabanUcret + PrimHesapla();
        }

        public override string ToString()
        {
            return base.ToString() + $"Prim: {PrimHesapla()}, Maas: {MaasHesapla()}";
        }
    }
}
