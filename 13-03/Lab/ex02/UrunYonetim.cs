using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02
{
    internal class UrunYonetim
    {
        private List<Urun> urunler = new List<Urun>();
        public void UrunEkle(Urun urun)
        {
            // Urunu ekle
            urunler.Add(urun);
        }
        public void UrunSil(Urun urun)
        {
            urunler.Remove(urun);
        }

        public List<Urun> UrunleriGetir()
        {
            return urunler;
        }


        public IEnumerable<IKirikOlabilir> KirikUrunleriGetir
        {
            get
            {
                foreach (var item in urunler)
                {
                    if (item is IKirikOlabilir kirikOlabilir && kirikOlabilir.KirikMi)
                    {
                        yield return kirikOlabilir;
                    }
                }
            }
        }


        public IEnumerable<IBozukOlabilir> BozukUrunleriGetir
        {
            get
            {
                foreach (var item in urunler)
                {
                    if (item is IBozukOlabilir bozukOlabilir && bozukOlabilir.BozukMu)
                    {
                        yield return bozukOlabilir;
                    }
                }

            }
        }
    }
}
