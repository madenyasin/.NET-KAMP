using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Kitap
{
    public int Id { get; set; }

    public string Ad { get; set; } = null!;

    public decimal Fiyat { get; set; }

    public string KapakResmi { get; set; } = null!;

    public string Ozet { get; set; } = null!;

    public int SayfaSayisi { get; set; }

    public int YayinEviId { get; set; }

    public int KategoriId { get; set; }

    public int YazarId { get; set; }

    public virtual Kategori Kategori { get; set; } = null!;

    public virtual YayinEvi YayinEvi { get; set; } = null!;

    public virtual Yazar Yazar { get; set; } = null!;
}
