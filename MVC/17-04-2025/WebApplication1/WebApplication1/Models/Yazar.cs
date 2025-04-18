using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public partial class Yazar
{
    public int Id { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string Biyografi { get; set; } = null!;

    [NotMapped]
    public string AdSoyad => Ad + " " + Soyad;
    public virtual ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
}
