using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex00
{
    internal class Musteri:Insan
    {
        public int MusteriID { get; set; }
        public double CariDurum { get; set; }

        public override string ToString()
        {
            return $"MusteriID: {MusteriID}, Ad: {base.Ad}, Soyad: {base.Soyad}, CariDurum: {CariDurum}";
        }
    }
}
