using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Intro.Models
{
    internal class PersonelDetay
    {
        public int PersonelDetayID { get; set; } // Düzeltilmiş property adı
        public string SicilNotu { get; set; }


        // PersonelDetay birebir Personel ile ilişkilidir.
        // ForeignKey attribute'u Personel sınıfındaki PersonelID propertysine işaret etmeli.
        [ForeignKey("PersonelDetayID")]
        public Personel? personel { get; set; }

        // ForeignKey property'si. EF Core tarafından otomatik olarak anlaşılabilir,
        // ancak açıkça belirtmek daha iyi olabilir.
    }


}
