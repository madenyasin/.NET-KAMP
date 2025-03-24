using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusFirma.Classes.Insanlar
{
    internal abstract class Insan
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }
        public override string ToString()
        {
            return $"Ad: {Ad}, Soyad: {Soyad}, Yas: {Yas}";
        }
    }
}
