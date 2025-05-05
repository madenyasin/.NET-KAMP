using Microsoft.EntityFrameworkCore;
using YasinMadenMVC.Abstracts;
using YasinMadenMVC.Data;
using YasinMadenMVC.Models;
using YasinMadenMVC.Models.ViewModels.MakaleViewModels;

namespace YasinMadenMVC.Repositories
{
    public class MakaleRepository : BaseRepository<Makale>
    {
        public MakaleRepository(MakaleDbContext dbContext) : base(dbContext)
        {
        }

        public MakaleDetay_VM MakaleDetayGetir(Makale makale)
        {
            var makaleDetay = ListeleQueryable()
                .Include(m => m.User)
                .Include(m => m.Kategoriler)
                .Select(m => new MakaleDetay_VM
                {
                    Id = m.Id,
                    Baslik = m.Baslik,
                    Icerik = m.Icerik,
                    YayinlanmaTarihi = m.YayinlanmaTarihi,
                    UserName = m.User.UserName,
                    Kategoriler = m.Kategoriler.Select(k => k.Kategori.Ad).ToList()
                }).FirstOrDefault(m => m.Id == makale.Id);

            return makaleDetay;

        }
    }
}
