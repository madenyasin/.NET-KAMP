using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex00_Cozum.Models
{
    internal class Kategori
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }

        public ICollection<Kitap>? Kitaplar { get; set; }

    }
}
