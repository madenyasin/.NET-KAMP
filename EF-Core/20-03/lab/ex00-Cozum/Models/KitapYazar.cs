using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex00_Cozum.Models
{
    internal class KitapYazar
    {
        public int ID { get; set; }
        public int KitapID { get; set; }
        public int YazarID { get; set; }



        public Kitap? Kitap { get; set; }
        public Yazar? Yazar { get; set; }
    }
}
