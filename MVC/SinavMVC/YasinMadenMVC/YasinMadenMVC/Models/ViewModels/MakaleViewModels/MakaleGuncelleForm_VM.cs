using System.Reflection.Metadata.Ecma335;

namespace YasinMadenMVC.Models.ViewModels.MakaleViewModels
{
    public class MakaleGuncelleForm_VM
    {
        public MakaleGuncelle_VM Makale { get; set; }
        public List<Kategori> Kategoriler { get; set; }
    }
}
