using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;

namespace WebApplication1.Models
{
    public class Arac
    {
        public int Id { get; set; } 
        public string Plaka { get; set; }
        public int MarkaId { get; set; }
        public string Model { get; set; }
        public decimal Fiyat { get; set; }
        public string Renk { get; set; }
        public string Aciklama { get; set; }

        public int EkleyenUyeId { get; set; }
        public Uye? EkleyenUye { get; set; }

        public Marka? Marka { get; set; }

    }
}
