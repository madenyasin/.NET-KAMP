using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02
{
    internal interface IBozukOlabilir
    {
        public bool BozukMu { get; }

        public DateTime SonTarih { get; set; }

    }
}
