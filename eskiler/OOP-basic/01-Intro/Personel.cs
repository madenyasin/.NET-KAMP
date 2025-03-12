using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Intro
{
    internal class Personel
    {
        private int id;

        // c# > 3.0 auto property
        public int Yas { get; set; }

        // c# 3.0 öncesi property tanımlama
        private string ad;
        public string Ad
        {
            get { return ad; }
            set { ad = value; }
        }





        public int Get____ID()
        {
            return id;
        }
        public void Set____ID(int value)
        {
            id = value;
        }

    }
}
