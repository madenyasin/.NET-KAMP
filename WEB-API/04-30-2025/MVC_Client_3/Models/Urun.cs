﻿namespace MVC_Client_3.Models
{
    public class Urun
    {
        public int UrunID { get; set; }
        public string? UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int KategoriID { get; set; }
        public Kategori? Kategori { get; set; }
    }
}
