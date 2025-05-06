using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex04_DIP.Dogru
{
    internal class SqlDatabase : ICrud
    {
        public List<string> Listele()
        {
            // SQL veritabanından veri listeleme işlemleri
            // Örnek olarak, bir liste döndürüyoruz
            return new List<string> { "SQL Verisi 1", "SQL Verisi 2", "SQL Verisi 3" };
        }
    }
}
