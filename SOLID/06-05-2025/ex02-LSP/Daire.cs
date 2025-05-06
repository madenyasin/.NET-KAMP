namespace ex02_LSP
{
    internal class Daire
    {
        public double Yaricap { get; set; }
        public virtual double Hesapla()
        {
            return Math.PI * Yaricap * Yaricap;
        }

    }
}
