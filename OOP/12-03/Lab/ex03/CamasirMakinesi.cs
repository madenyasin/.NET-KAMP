using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex03
{
    internal class CamasirMakinesi: ElektronikEsya
    {
        public int CamasirMakinesiID { get; set; }
        public int DevirSayisi { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"{CamasirMakinesiID} {DevirSayisi}";
        }
    }
}
