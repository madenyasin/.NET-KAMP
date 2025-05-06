namespace ex02_LSP
{
    internal class Silindir : Daire
    {
        public Double Yukseklik { get; set; }
        public override double Hesapla()
        {
            return base.Hesapla() * Yukseklik;
        }
    }
}
