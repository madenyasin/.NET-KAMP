using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex04_DIP.Dogru
{
    internal class OracleDatabase : ICrud
    {
        public List<string> Listele()
        {
            // Oracle veritabanından veri listeleme işlemleri
            // Örnek olarak, bir liste döndürüyoruz
            return new List<string> { "Oracle Verisi 1", "Oracle Verisi 2", "Oracle Verisi 3" };
        }
    }
}
