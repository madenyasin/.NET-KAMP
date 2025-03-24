using OtobusFirmasi.Abstracts.Classes;
using OtobusFirmasi.Concretes.Bagajlar;
using OtobusFirmasi.Concretes.Koltuklar;
using OtobusFirmasi.Concretes.Personeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusFirmasi.Concretes
{
    internal class Otobus
    {
        public SoforKoltugu SoforKoltugu { get; set; }
        public MuavinKoltugu MuavinKoltugu { get; set; }
        public List<YolcuKoltugu> Koltuklar { get; set; }
        public List<Bagaj> Bagajlar { get; set; }
        public List<EvcilHayvan> EvcilHayvanlar { get; set; }
        public List<Personel> Personeller { get; set; }
        public Otobus(int koltukKapasitesi)
        {
            SoforKoltugu = new();
            MuavinKoltugu = new();
            Koltuklar = new(koltukKapasitesi);
            Bagajlar = new();
            EvcilHayvanlar = new(3);
            Personeller = new();
        }
    }
}
