using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Urunler
{
    public int UrunId { get; set; }

    public string UrunAdi { get; set; } = null!;

    public int KategoriId { get; set; }

    public decimal Fiyat { get; set; }

    public string Aciklama { get; set; } = null!;

    public string Resim { get; set; } = null!;

    public virtual Kategoriler Kategori { get; set; } = null!;
}
