using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Intro.Models
{
    internal class Bolum
    {
        public int BolumID { get; set; }
        public string BolumAd { get; set; }
 
        public ICollection<Personel>? Personeller { get; set; }
    }
}
