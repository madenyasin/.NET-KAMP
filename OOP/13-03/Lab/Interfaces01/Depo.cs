using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces01
{
    internal class Depo:IEnumerable
    {
        List<string> urunler = new List<string> { "defter", "kalem", "silgi" };

        public IEnumerator GetEnumerator()
        {
            return urunler.GetEnumerator();
        }

        
    }
}
