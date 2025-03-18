using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex00
{
    internal class Urun : IComparable
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public double Fiyat { get; set; }

        public int CompareTo(object? obj)
        {
            Urun urun = obj as Urun;
            if (urun != null)
            {
                return this.UrunID.CompareTo(urun.UrunID);
            }
            return 0;
        }


        public override string ToString()
        {
            return $"UrunID: {UrunID}, UrunAdi: {UrunAdi}, Fiyat: {Fiyat}";
        }
    }
}
