using OtobusFirmasi.Abstracts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusFirmasi.Concretes.Koltuklar
{
    internal class YolcuKoltugu : Koltuk
    {
        public int KoltukNo { get; set; }
        public Yolcu.Yolcu Yolcu { get; set; }
    }
}
