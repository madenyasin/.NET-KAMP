using OtobusFirmasi.Abstracts.Classes;
using OtobusFirmasi.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusFirmasi.Utilities
{
    internal static class OtobusuDoldur
    {
        private static string[] adlar = { "ahmet", "mehmet", "ziya" };
        private static string[] soyadlar = { "maden", "bayrak", "öztürk" };
        private static string[] evcilHayvanlar = { "bardak", "pati", "kedi", "karabas" };
        public static void Doldur(Otobus otobus)
        {
            Random rnd = new Random();

            //otobus.Personeller.Add(new );
        }


    }
}
