using KitapProje.Models;
using KitapProje.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace KitapProje.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public AppUser? AktifKullaniciGetir()
        {
            // Kullanıcı giriş yapmış mı kontrol et
            if (_signInManager.IsSignedIn(_signInManager.Context.User))
            {
                // Giriş yapmış kullanıcıyı al
                return _userManager.GetUserAsync(_signInManager.Context.User).Result;
            }
            // Giriş yapmamışsa null döndür
            return null;
        }
    }
}
