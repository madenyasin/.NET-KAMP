using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmaray_Revize
{
    internal class Yolculuk
    {
        public Kisi Yolcu { get; set; }
        public Durak Binis { get; set; }
        public Durak Inis { get; set; }
        public AbonmanTuru Abonman { get; set; }
        public double Ucret { get; set; }
        public DateTime Tarih { get; set; }
        public bool IadeYapilacakMi { get; set; }

        public override string ToString()
        {
            return $"{Yolcu.AdSoyad} - {Binis.Name} - {Inis.Name} - {Abonman} - {Ucret:C} - {Tarih}";
        }
    }
}
