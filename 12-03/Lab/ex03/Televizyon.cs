using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex03
{
    internal class Televizyon: ElektronikEsya
    {
        public int TelevizyonID { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"{TelevizyonID}";
        }
    }
}
