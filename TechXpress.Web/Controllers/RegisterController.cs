using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TechXpress.DAL.Entities; 
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RegisterController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User user = null;

            user = await _userManager.FindByNameAsync(model.EmailOrPhone);

            if (user == null)
            {
                if (model.EmailOrPhone.Contains("@"))
                {
                    user = await _userManager.FindByEmailAsync(model.EmailOrPhone);
                }
                else
                {
                    user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == model.EmailOrPhone.Trim());
                }
            }

            if (user == null)
            {
                ModelState.AddModelError("", "User not found.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Incorrect password.");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }



        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existingUser = await _userManager.FindByEmailAsync(model.EmailOrPhone);
            if (existingUser != null)
            {
                ModelState.AddModelError("", "User already exists.");
                ViewBag.ToLogin = true;
                return View(model);
            }

            var user = new User
            {
                UserName = model.EmailOrPhone,
                Email = model.EmailOrPhone.Contains("@") ? model.EmailOrPhone : null,
                PhoneNumber = !model.EmailOrPhone.Contains("@") ? model.EmailOrPhone : null,
                Fname = model.Name,
                User_Type = "Admin"
            };

            var createResult = await _userManager.CreateAsync(user, model.Password);
            if (!createResult.Succeeded)
            {
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new ApplicationRole("Admin"));
            }

            await _userManager.AddToRoleAsync(user, "Admin");

            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Register");
        }
    }
}
