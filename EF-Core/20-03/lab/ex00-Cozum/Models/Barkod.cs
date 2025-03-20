using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ex00_Cozum.Models
{
    internal class Barkod
    {
        [ForeignKey("Kitap")]
        public int BarkodID { get; set; }
        public string BarkodNo { get; set; }
        public string Karekod { get; set; }

        public Kitap? Kitap { get; set; }
    }
}
