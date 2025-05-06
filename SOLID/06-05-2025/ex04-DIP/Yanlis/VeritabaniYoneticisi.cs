using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex04_DIP.Yanlis
{
    internal class VeritabaniYoneticisi
    {
        // PROBLEM?
        // Tightly Coupled
        SqlVeritabani vt = new SqlVeritabani();

        // ÇÖZÜM
        // Sınıfı Loosely Coupled hale getir

    }
}
