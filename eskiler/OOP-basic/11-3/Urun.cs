using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _11_3
{
    internal class Urun(int id, string ad)
    {
        public int UrunID { get; set; } = id;
        public string UrunAdis { get; set; } = ad;
    }
}
