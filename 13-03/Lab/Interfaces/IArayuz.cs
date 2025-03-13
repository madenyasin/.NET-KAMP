using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal interface IArayuz
    {
        void Islem();
        string Test()
        {
            // Gövdeli metoda arayüz tipinde bir nesne üzerinden erişilebilir.
            return "Arayüz içinde gövdeli yapılar olur mu?";
        }

        
    }
}
