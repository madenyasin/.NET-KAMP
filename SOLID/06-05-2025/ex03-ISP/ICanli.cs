using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex03_ISP
{
    // Yanlış
    internal interface ICanli
    {
        // Yanlış
        // ISP ihlal ediyor
        void Yuru();
        void Uc();
        void Yuz();
        void Kos();
    }
}
