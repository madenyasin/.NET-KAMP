using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex01
{
    internal abstract class Arac
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public ConsoleColor Renk { get; set; }

        protected Arac()
        {
            Renk = (ConsoleColor)new Random().Next(1, 16);
        }

        override public string ToString()
        {
            return $"{Marka} {Model} {Renk}";
        }
    }
}
