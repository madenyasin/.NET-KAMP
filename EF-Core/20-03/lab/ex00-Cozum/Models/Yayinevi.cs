using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex00_Cozum.Models
{
    internal class Yayinevi
    {
        public int YayineviID { get; set; }
        public string YayinEviAdi { get; set; }

        public ICollection<Kitap>? Kitaplar { get; set; }
    }
}
