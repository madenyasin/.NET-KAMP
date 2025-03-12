using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_11_3
{
    internal class Kitap(int id, string isim, string yazar, string yayinEvi)
    {

        public int ID { get; set; }
        public string Isim { get; set; }
        public string Yazar { get; set; }
        public string YayınEvi { get; set; }

        //public Kitap(int id, string isim, string yazar, string yayinEvi)
        //{
        //    ID = id;
        //    Isim = isim;
        //    Yazar = yazar;
        //    YayınEvi = yayinEvi;
        //}
        public Kitap(int id, string isim, string yazar): this(id, isim, yazar, "") { }




        //// default
        //public Kitap()
        //{

        //}

        //public Kitap(int id)
        //{
        //    ID = id;
        //}
        //public Kitap(int id, string isim)
        //{
        //    ID = id;
        //    Yazar = isim;
        //}
        //public Kitap(int id, string isim, string yazar)
        //{
        //    ID = id;
        //    Isim = isim;
        //    Yazar = yazar;
        //}
        //public Kitap(int id, string isim, string yazar, string yayinEvi)
        //{
        //    ID = id;
        //    Isim = isim;
        //    Yazar = yazar;
        //    YayınEvi = yayinEvi;
        //}

    }
}
