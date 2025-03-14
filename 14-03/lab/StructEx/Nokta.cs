using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructEx
{
    internal struct Nokta
    {
        public int x { get; set; }
        public int y { get; set; }

        public string KoordinatGetir()
        {
            return x + " " + y;
        }
    }
}
