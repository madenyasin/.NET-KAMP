using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kitap.Models.VM
{
    public class KitapGuncelleForm_VM
    {
        public SelectList Kategoriler { get; set; }
        public SelectList Yazarlar { get; set; }
        public SelectList YayinEvis { get; set; }
        public KitapGuncelle_VM Kitap { get; set; }
    }
}
