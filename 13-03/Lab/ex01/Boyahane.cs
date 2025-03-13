using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex01
{
    internal class Boyahane
    {
        public bool BoyaYap(Arac arac, ConsoleColor yeniRenk)
        {
            if (arac is IBoyanabilir)
            {
                arac.Renk = yeniRenk;
                return true;

            }

            return false;
        }
    }
}
