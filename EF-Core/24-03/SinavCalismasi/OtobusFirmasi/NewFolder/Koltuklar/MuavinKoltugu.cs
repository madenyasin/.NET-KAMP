using OtobusFirmasi.Abstracts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusFirmasi.Concretes.Koltuklar
{
    internal class MuavinKoltugu: Koltuk
    {
        public Personel Personel { get; set; }
        public bool AcikMi { get; set; }
    }
}
