using OtobusFirma.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OtobusFirma.Classes.Hayvanlar
{
    internal class EvcilHayvan: Hayvan
    {
        public int EvcilHayvanID { get; set; }
        public string Ad { get; set; }
        public string Cins { get; set; }
        public Boyut Boyut { get; set; }
    }
}
