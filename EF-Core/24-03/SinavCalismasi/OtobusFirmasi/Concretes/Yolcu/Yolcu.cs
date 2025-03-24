using OtobusFirmasi.Abstracts.Classes;
using OtobusFirmasi.Concretes.Bagajlar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusFirmasi.Concretes.Yolcu
{
    internal class Yolcu : Kisi
    {
        public string VarisYeri { get; set; }
        //bagaj, evcil h
        public Bagaj? Bagaj { get; set; }
        public EvcilHayvan? EvcilHayvan { get; set; }
    }
}
