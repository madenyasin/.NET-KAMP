using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;

namespace Kitap.Models.VM
{
    public class KitapEkleForm_VM
    {
        public SelectList Kategoriler { get; set; }
        public SelectList Yazarlar { get; set; }
        public SelectList YayinEvis { get; set; }
        public Kitap_VM Kitap { get; set; }

    }
}
