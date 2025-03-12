using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmaray_Revize
{
    internal class Kisi
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }

        public override string ToString()
        {
            return $"{Id} - {AdSoyad}";
        }
    }
}
