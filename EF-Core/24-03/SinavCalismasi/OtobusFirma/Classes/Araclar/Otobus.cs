using OtobusFirma.Classes.Hayvanlar;
using OtobusFirma.Classes.Insanlar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusFirma.Classes.Araclar
{
    internal class Otobus: Arac
    {
        public int OtobusID { get; set; }
        override public string PlakaNo { get; set; }
    }
}
