using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Intro.Models
{
    //internal class Personel
    //{
    //    // pk için -> ID, PersonelId
    //    public int PersonelID { get; set; }
    //    public string Ad { get; set; }
    //    public string Soyad { get; set; }
    //    public decimal Maas { get; set; }
    //    public int BolumId { get; set; }

    //    public PersonelDetay? personelDetay { get; set; }
    //    public ICollection<Bolum>? Bolumler { get; set; }
    //}
    internal class Personel
    {
        // pk için -> ID, PersonelId
        public int PersonelID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public decimal Maas { get; set; }
        public int BolumID { get; set; } // Foreign Key Bolum tablosuna

        // Bir personel sadece bir bölüme ait olabilir.
        public PersonelDetay? personelDetay { get; set; }
        public Bolum? Bolum { get; set; }

        // Bir personelin sadece bir personel detayı olabilir (One-to-One ilişki)
    }
}
