using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex03
{
    internal class Depo
    {
        private List<ElektronikEsya> elektronikEsyalar = new List<ElektronikEsya>();

        public void Ekle(ElektronikEsya esya)
        {
            elektronikEsyalar.Add(esya);
        }

        public List<string> EsyaListesiGetir()
        {
            List<string> esyaListesi = new List<string>();
            foreach (var item in elektronikEsyalar)
            {
                esyaListesi.Add(item.ToString());
            }
            return esyaListesi;
        }

        public double ToplamFiyat()
        {
            double toplamFiyat = 0;
            foreach (var item in elektronikEsyalar)
            {
                toplamFiyat += item.Fiyat;
            }
            return toplamFiyat;
        }
    }
}
