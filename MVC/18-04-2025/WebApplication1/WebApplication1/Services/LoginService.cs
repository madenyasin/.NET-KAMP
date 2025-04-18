using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Services
{
    public class LoginService
    {
        private readonly UserManager<Uye> _userManager;
        private readonly SignInManager<Uye> _signInManager;
        private readonly IMapper _mapper;

        public LoginService(UserManager<Uye> userManager, SignInManager<Uye> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<bool> LoginAsync(LoginViewModel login)
        {
            var result = _userManager.FindByNameAsync(login.UserName).Result;

            if (result is not null) // üye var
            {
                var sifreDogruMu = _userManager.CheckPasswordAsync(result, login.Password).Result;
                if (sifreDogruMu)
                {// sifre doğru
                    await _signInManager.SignInAsync(result, false);
                    return true;
                }
                else
                {// sifre yanlış
                    return false;
                }
            }
            else
            {// üye yok
                return false;
            }
        }

        public async Task<bool> RegisterAsync(RegisterViewModel register)
        {

            Uye yeniUye = _mapper.Map<Uye>(register);

            var result = await _userManager.CreateAsync(yeniUye, register.Sifre);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<int> GetCurrentUserId()
        {
            var user = await _userManager.GetUserAsync(_signInManager.Context.User);
            if (user != null)
            {
                return user.Id;
            }
            else
            {
                return -1; // Kullanıcı bulunamadı
            }
        }
    }
}
