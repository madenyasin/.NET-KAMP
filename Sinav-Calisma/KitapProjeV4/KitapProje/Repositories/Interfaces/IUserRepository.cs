using KitapProje.Models;

namespace KitapProje.Repositories.Interfaces
{
    public interface IUserRepository
    {
        AppUser? AktifKullaniciGetir();
    }
}
