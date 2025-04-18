using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Repositories
{
    public class KitapRepository : BaseRepository<Kitap>
    {
        private readonly IMapper _mapper;
        public KitapRepository(KitapDbbContext dbContext ,IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        //kitapdetayvm getir.
        public KitapDetayViewModel GetKitapDetay(int id)
        {
            var kitap = _table.Include(x => x.Kategori)
                .Include(x => x.Yazar)
                .Include(x => x.YayinEvi)
                .FirstOrDefault(x => x.Id == id);
            if (kitap == null) return null;
            return new KitapDetayViewModel
            {
                Ad = kitap.Ad,
                Fiyat = kitap.Fiyat,
                KapakResmi = kitap.KapakResmi,
                Ozet = kitap.Ozet,
                SayfaSayisi = kitap.SayfaSayisi,
                KategoriAdi = kitap.Kategori.Ad,
                YazarAdi = kitap.Yazar.Ad,
                YayinEviAdi = kitap.YayinEvi.Ad
            };
        }

        public KitapDetayViewModel KitapDetayGetir(int id)
        {
            var kitap= Bul(id);
            _dbContext.Entry(kitap).Navigation("Kategori").Load();
            _dbContext.Entry(kitap).Navigation("Yazar").Load();
            _dbContext.Entry(kitap).Navigation("YayinEvi").Load();

            // Mapper'ın özel kullanımını anlatmak için burada Mapper kullandık.
            // NŞA'da repository'de mapper kullanmıyoruz.


            KitapDetayViewModel kitapDetay = new();
            _mapper.Map(kitap, kitapDetay);
            return kitapDetay;

        }
    }
}
