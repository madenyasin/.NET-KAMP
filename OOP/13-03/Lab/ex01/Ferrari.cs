using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex01
{
    internal class Ferrari : Arac, IBoyanabilir
    {
        override public string ToString()
        {
            return $"Ferrari {Marka} {Model} {Renk}";
        }
    }
}
