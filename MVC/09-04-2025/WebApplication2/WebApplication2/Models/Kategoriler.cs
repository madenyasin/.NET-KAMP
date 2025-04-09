using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Kategoriler
{
    public int KategoriId { get; set; }

    public string KategoriAdi { get; set; } = null!;

    public virtual ICollection<Urunler> Urunlers { get; set; } = new List<Urunler>();
}
