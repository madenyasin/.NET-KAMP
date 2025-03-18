using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex03
{
    internal class ElektronikEsya
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Aciklama { get; set; }
        public double Fiyat { get; set; }

        public override string ToString()
        {
            return $"{Marka} {Model} {Aciklama} {Fiyat}";
        }
    }
}
