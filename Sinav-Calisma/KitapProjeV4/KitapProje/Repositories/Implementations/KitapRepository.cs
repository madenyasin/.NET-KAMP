using KitapProje.Data;
using KitapProje.Models;
using KitapProje.Models.ViewModels.KitapViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Kerberos;

namespace KitapProje.Repositories.Implementations
{
    public class KitapRepository : BaseRepository<Kitap>
    {
        public KitapRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public KitapDetayVM KitapDetayGetir(Kitap kitap)
        {
            var kitapDetay = ListeleQueryable()
                .Include(k => k.User)
                .Include(k => k.Kategoriler)
                .Select(k => new KitapDetayVM
                {
                    Id = k.Id,
                    Ad = k.Ad,
                    Fiyat = k.Fiyat,
                    Ozet = k.Ozet,
                    SayfaSayisi = k.SayfaSayisi,
                    UserName = k.User.UserName,
                    Kategoriler = k.Kategoriler.Select(kat => kat.Kategori.Ad).ToList()
                }).FirstOrDefault(x=>x.Id == kitap.Id);
            

            return kitapDetay;
        }
    }
}
