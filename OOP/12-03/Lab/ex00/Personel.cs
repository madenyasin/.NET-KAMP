using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ex00
{
    internal class Personel : Insan
    {
        public int PersonelID { get; set; }
        public double Maas { get; set; }

        public override string ToString()
        {
            return $"PersonelID: {PersonelID}, Ad: {base.Ad}, Soyad: {base.Soyad}, Maas: {Maas}";
        }
    }
}
