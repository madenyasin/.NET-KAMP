using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_11_3
{
    internal abstract class Personel
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public double ToplamSatis { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Ad: {Ad}, Soyad: {Soyad}, Toplam Satis: {ToplamSatis} ";
        }

        //public abstract double MaasHesapla();
        //public abstract double PrimHesapla();
    }
}
