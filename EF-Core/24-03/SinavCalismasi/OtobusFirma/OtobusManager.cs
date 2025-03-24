using OtobusFirma.Classes.Araclar;
using OtobusFirma.Classes.Hayvanlar;
using OtobusFirma.Classes.Insanlar;
using OtobusFirma.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusFirma
{
    /// <summary>
    /// Otobüs firmasını yöneten sınıf
    /// </summary>
    public class OtobusManager
    {
        public Random rnd { get; set; } = new Random();
        private List<Sofor> Soforler { get; set; } = new();
        private Muavin Muavin { get; set; }
        private Hostes Hostes { get; set; }
        private List<Yolcu> Yolcular { get; set; } = new();
        private List<EvcilHayvan> EvcilHayvanlar { get; set; } = new();
        public List<object> Data { get; set; } = new();


        /// <summary>
        /// 
        /// </summary>
        public void OtobusOlustur()
        {
            // 2 adet şoför, 1 adet muavin, 1 adet host/hostes, 40 adet yolcu
            // 3 adet evcil hayvan
            // 1 adet otobüs
            Sofor sofor1 = new Sofor()
            {
                PersonelID = 1,
                Ad = "Ali",
                Soyad = "Veli",
                Yas = 35,
                TecrubeYili = 10,
                EhliyetiVarMi = true
            };
            Sofor sofor2 = new Sofor()
            {
                PersonelID = 2,
                Ad = "Ayşe",
                Soyad = "Fatma",
                Yas = 30,
                TecrubeYili = 5,
                EhliyetiVarMi = true
            };
            Soforler.Add(sofor1);
            Soforler.Add(sofor2);

            Data.Add(sofor1);
            Data.Add(sofor2); 
            Muavin muavin = new Muavin()
            {
                Ad = "Mehmet",
                Soyad = "Ahmet",
                Yas = 25,
                TecrubeYili = 2,
                EhliyetiVarMi = true
            };
            Muavin = muavin;
            Data.Add(Muavin);
            
            Hostes hostes = new Hostes()
            {
                Ad = "Zeynep",
                Soyad = "Kaya",
                Yas = 22,
                TecrubeYili = 1,
                EhliyetiVarMi = false
            };
            Hostes = hostes;
            Data.Add(hostes);

            for (int i = 0; i < 40; i++)
            {
                Yolcu yolcu = new Yolcu()
                {
                    Ad = "Yolcu" + i,
                    Soyad = "Soyad" + i,
                    Hedef = (Guzergahlar)rnd.Next((int)Guzergahlar.Istanbul, (int)Guzergahlar.Kutahya),
                    Bagaj = new Bagaj { BagajID = i, Agirlik = rnd.Next(0, 20) },
                    EvcilHayvan = null
                };
                Yolcular.Add(yolcu);
            }

            foreach (var item in Yolcular)
            {
                Data.Add(item);
            }
        }
 
    }
}
