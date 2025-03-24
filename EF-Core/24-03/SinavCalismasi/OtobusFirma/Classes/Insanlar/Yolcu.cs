using OtobusFirma.Classes.Araclar;
using OtobusFirma.Classes.Hayvanlar;
using OtobusFirma.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusFirma.Classes.Insanlar
{
    internal class Yolcu: Insan
    {
        public int YolcuID { get; set; }
        public Guzergahlar Hedef { get; set; }
        public Bagaj Bagaj { get; set; }
        public EvcilHayvan? EvcilHayvan { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"YolcuID: {YolcuID}, Hedef: {Hedef}, Bagaj: {Bagaj}, EvcilHayvan: {EvcilHayvan}";
        }
    }
}
