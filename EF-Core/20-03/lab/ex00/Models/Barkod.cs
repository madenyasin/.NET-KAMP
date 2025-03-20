using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex00.Models
{
    internal class Barkod
    {
        public int BarkodID { get; set; }
        public string TekBoyutluBarkodPath { get; set; }
        public string IkiBoyutluBarkodPath { get; set; }
        public int KitapID { get; set; }

        public Kitap Kitap { get; set; }
    }
}
