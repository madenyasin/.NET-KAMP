using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02
{
    internal abstract class Urun
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public double Fiyat { get; set; }

        override public string ToString()
        {
            return $"{ID} - {Ad} - {Fiyat}";
        }
    }
}
