using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Areas.Admin.Models;  // ViewModel namespace

namespace WebApplication3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<IdentityUser> userManager,
                               RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: /Admin/Admin/UserList
        public async Task<IActionResult> UserList()
        {
            var users = _userManager.Users.ToList();
            var model = new List<UserRolesViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                model.Add(new UserRolesViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Roles = roles
                });
            }

            return View(model);
        }

        // GET: /Admin/Admin/EditRoles?userId=...
        public async Task<IActionResult> EditRoles(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return BadRequest();

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            var vm = new EditRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                AvailableRoles = allRoles,
                SelectedRoles = userRoles
            };

            return View(vm);
        }

        // POST: /Admin/Admin/EditRoles
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRoles(EditRolesViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = await _userManager.FindByIdAsync(vm.UserId);
            if (user == null)
                return NotFound();

            var currentRoles = await _userManager.GetRolesAsync(user);
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeResult.Succeeded)
                ModelState.AddModelError("", "Roller silinirken hata oluştu.");

            var addResult = await _userManager.AddToRolesAsync(user, vm.SelectedRoles);
            if (!addResult.Succeeded)
                ModelState.AddModelError("", "Roller eklenirken hata oluştu.");

            if (!ModelState.IsValid)
                return View(vm);

            return RedirectToAction(nameof(UserList));
        }
    }
}


// UserRolesViewModel.cs
namespace WebApplication3.Areas.Admin.Models
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IList<string> Roles { get; set; }
    }
}

// EditRolesViewModel.cs
namespace WebApplication3.Areas.Admin.Models
{
    public class EditRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        // Sistemdeki tüm roller
        public List<string> AvailableRoles { get; set; }

        // Kullanıcının o anki rolleri
        public IList<string> SelectedRoles { get; set; }
    }
}
