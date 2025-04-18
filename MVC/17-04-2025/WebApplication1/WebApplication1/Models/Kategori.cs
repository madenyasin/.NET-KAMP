using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Kategori
{
    public int Id { get; set; }

    public string Ad { get; set; } = null!;

    public virtual ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
}
