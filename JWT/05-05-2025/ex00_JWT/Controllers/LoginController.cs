using ex00_JWT.Models;
using ex00_JWT.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ex00_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public LoginController(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> LoginprocessAsync(LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user is null)
            {
                return Unauthorized();
            }

            if (!await _userManager.CheckPasswordAsync(user, login.Password))
            {
                return Unauthorized();
            }

            // Generate JWT token and return it
            return Ok(new { token = GetToken(user.Email) });
        }

        private string GetToken(string email)
        {
            var authClaims = new List<Claim> {
                new Claim(ClaimTypes.Email, email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:secretKey"]));
            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                authClaims.ToString(),
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signin
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


}
