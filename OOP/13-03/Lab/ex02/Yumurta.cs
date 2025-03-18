using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02
{
    internal class Yumurta : Urun, IKirikOlabilir, IBozukOlabilir
    {
        public bool KirikMi { get; set; }
        public DateTime SonTarih { get; set; }
        public bool BozukMu
        {
            get { return DateTime.Now < SonTarih; }
        }

        public override string ToString()
        {
            return $"{ID} - {Ad} - {Fiyat} - {SonTarih} - {BozukMu}";
        }
    }
}
