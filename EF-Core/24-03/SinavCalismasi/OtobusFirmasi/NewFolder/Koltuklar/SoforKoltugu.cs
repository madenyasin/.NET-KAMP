using OtobusFirmasi.Abstracts.Classes;
using OtobusFirmasi.Abstracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusFirmasi.Concretes.Koltuklar
{
    internal class SoforKoltugu : Koltuk
    {
        public IAracKullanabilir Sofor { get; set; }
        public sbyte KonforSeviyesi { get; set; }

    }
}
