using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02
{
    internal class Bardak: Urun, IKirikOlabilir
    {
        public bool KirikMi { get; set; }
        override public string ToString()
        {
            return $"{ID} - {Ad} - {Fiyat} - KirikMi: {KirikMi}";
        }
    }
}
