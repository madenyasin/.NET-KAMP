
namespace _17_Method_ref_out_params
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ref out params
            #region ref

            //Ref, metotlara veya metodlardan değer tiplerin referanslarını iletmek veya döndürmek için kullanılır.
            //diğer bir deyişle referans yoluyla iletilen bir değerde yapılan herhangi bir değişikliğin yalnızca taşıdığı değeri değil, adresteki 
            /*(referans değerini de)
             * değiştirdiğiniz için bnu deüğişikliği yansıtacapı anlamına gelir.
             * 
             * 
             */


            //int a = 10, b = 12;
            //Console.WriteLine($"işlem öncesinde a: {a}");
            //Console.WriteLine($"işlem öncesinde b: {b}");

            //ToplamDeger(a);
            //FarkDeger(ref b);

            //Console.WriteLine($"işlem sonrasında a: {a}");
            //Console.WriteLine($"işlem sonrasında b: {b}");


            //int ToplamDeger(int a)
            //{
            //    return a += 10;
            //}

            //void FarkDeger(ref int b)
            //{
            //    b -= 5;
            //} 
            #endregion



            #region out


            //int i = -10, j = -20;



            //Toplam(out i, out j);

            //Console.WriteLine("toplam değer i :" + i);
            //Console.WriteLine("toplam değer j :" + j);

            //void Toplam(out int p, out int q)
            //{
            //    p = 40;
            //    q = 30;
            //    p += p;
            //    q += q;
            //}

            #endregion

            //double bolum;

            //int kalan = Bolum(25, 4, out bolum);
            //Console.WriteLine("bolum: " + bolum);
            //Console.WriteLine("kalan: " + kalan);

            //int farkSonuc;
            //int sonuc = Fark(90, 60, out farkSonuc);

            //Console.WriteLine("farkSonuc: " + farkSonuc);
            //Console.WriteLine("sonuc: " + sonuc);

            //int Fark(int s1, int s2, out int sonuc)
            //{
            //    sonuc = s1 - s2;
            //    return sonuc;
            //}

            //int Bolum(int bolunen, int bolen, out double bolum)
            //{
            //    bolum = bolunen / bolen;
            //    return bolunen % bolen;
            //}


            #region params

            int r1 = Topla(1, 2, 3, 4);
            int r2 = Topla(1, 247, 654156, 254524, 53, 454);


            int Topla(params int[] sayilar)
            {
                int toplam = 0;
                foreach (var item in sayilar)
                {
                    toplam += item;
                }
                return toplam;
            }

            string s1 = Birlestir("yasin", "maden", "yasinmaden");

            string Birlestir(params string[] kelimeler)
            {
                string result = "";
                foreach (var item in kelimeler)
                {
                    result += $"{item} ";
                }
                return result;
            }
            #endregion


            



        }


    }
}
