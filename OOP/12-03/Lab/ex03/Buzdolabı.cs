using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ex03
{
    internal class Buzdolabı : ElektronikEsya
    {
        public int BuzdolabiID { get; set; }
        public bool NoFrostMu { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"{BuzdolabiID} {NoFrostMu}";
        }
    }
}
