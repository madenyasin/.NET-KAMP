using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02
{
    internal class Bulgur : Urun, IBozukOlabilir
    {
        public DateTime SonTarih { get; set; }
        public bool BozukMu
        {
            get { return DateTime.Now < SonTarih; }
        }

        override public string ToString()
        {
            return $"{ID} - {Ad} - {Fiyat} - {SonTarih} - {BozukMu}";
        }
    }
}
