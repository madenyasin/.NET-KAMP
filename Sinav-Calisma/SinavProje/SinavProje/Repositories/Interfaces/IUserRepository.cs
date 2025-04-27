using SinavProje.Models;

namespace SinavProje.Repositories.Interfaces
{
    public interface IUserRepository
    {
        AppUser? AktifKullaniciGetir();
    }
}
