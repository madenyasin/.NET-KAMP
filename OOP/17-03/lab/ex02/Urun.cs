using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02
{
    internal class Urun
    {
        public int UrunID { get; set; }
        public string UrunAd { get; set; }
        public double Fiyat { get; set; }
        public string Kategori { get; set; }

        override public string ToString()
        {
            return $"UrunID: {UrunID}, UrunAd: {UrunAd}, Fiyat: {Fiyat}, Kategori: {Kategori}";
        }
    }
}
