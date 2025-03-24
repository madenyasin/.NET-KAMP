using OtobusFirma.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusFirma.Classes.Insanlar
{
    internal class Muavin : Personel, IOtobusKullanabilir
    {
        public override string ToString()
        {

            return base.ToString() + $"EhliyetiVarMi: {EhliyetiVarMi}";
        }
    }
}
