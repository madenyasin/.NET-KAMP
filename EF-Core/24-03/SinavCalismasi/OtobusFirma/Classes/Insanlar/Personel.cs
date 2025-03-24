using OtobusFirma.Interfaces;

namespace OtobusFirma.Classes.Insanlar
{
    internal abstract class Personel : Insan, IEhliyetiOlabilir
    {
        public int PersonelID { get; set; }
        public int TecrubeYili { get; set; }
        public bool EhliyetiVarMi { get; set; }

        public override string ToString()
        {
            return $"PersonelID: {PersonelID}, Ad: {Ad}, Soyad: {Soyad}, Yas: {Yas}, TecrubeYili: {TecrubeYili}, EhliyetiVarMi: {EhliyetiVarMi}";
        }
    }
}
