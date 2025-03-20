using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex00.Models
{
    internal class Kitap
    {
        public int KitapID { get; set; }
        public string Ad { get; set; }
        public double Fiyat { get; set; }
        public string ISBN { get; set; }
        public int SayfaSayisi { get; set; }
        public DateTime BasimTarihi { get; set; }
        public int BaskiSayisi { get; set; }
        public string Ozet { get; set; }
        public string KapakResmiPath { get; set; }

        public int YazarID { get; set; }
        public int BarkodID { get; set; }
        public int KategoriID { get; set; }


        public Kategori Kategori { get; set; }
        public Barkod Barkod { get; set; }
        public ICollection<Yazar> Yazarlar { get; set; }
    }
}
