using YasinMadenMVC.Models;

namespace YasinMadenMVC.Abstracts.Interfaces
{
    public interface IUserRepository
    {
        AppUser? AktifKullaniciGetir();
    }
}
