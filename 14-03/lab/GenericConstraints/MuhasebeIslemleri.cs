using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericConstraints
{
    // birden fazla constraint varsa; new constraint'ı en sonda yazmalıyız.
    internal class MuhasebeIslemleri<T> where T : Personel, new()
    {

    }
}
