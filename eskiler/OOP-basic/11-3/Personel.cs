using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_3
{
    internal class Personel
    {
        public int PersonelID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public Personel(int id)
        {
            PersonelID = id;
        }
        public Personel()
        {
            

        }
    }
}
