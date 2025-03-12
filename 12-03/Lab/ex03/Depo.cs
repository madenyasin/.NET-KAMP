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

        public List<ElektronikEsya> EsyaListesiGetir()
        {
            return elektronikEsyalar;
        }
    }
}
