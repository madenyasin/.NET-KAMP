using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusFirmasi.Abstracts.Classes
{
    internal abstract class Personel: Kisi
    {
        public int PersonelID { get; set; }
        public int Yas { get; set; }
        public int Tecrube { get; set; }
    }
}
