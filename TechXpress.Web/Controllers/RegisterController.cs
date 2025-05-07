using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechXpress.Domain.Entities;
using TechXpress.Web.Models;
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        private readonly  List<LoginUserViewModel> _useres;
        public RegisterController()
        {
            _useres = new List<LoginUserViewModel>{ 
                new LoginUserViewModel{ Email="sawsanelsebay2@gmail.com", Fname="Sawsan", Lname="Elsba3y", Password="12345678", Phone="01000000000", User_ID=1, User_Type="Admin" },
                new LoginUserViewModel{ Email="Admin2@gmail.com", Fname="Admin", Lname="2", Password="12345678", Phone="01000000000", User_ID=4, User_Type="Admin" },
                new LoginUserViewModel{Email="user1@gmail.com" , Fname="User", Lname="1", Password="12345678", Phone="01000000001", User_ID=2, User_Type="User" },
                new LoginUserViewModel{Email="user2@gmail.com" , Fname="User", Lname="2", Password="12345678", Phone="01000000001", User_ID=3, User_Type="User" },

            };

        }

        [HttpPost]  
      public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _useres.FirstOrDefault(u =>
                    u.Email == model.EmailOrPhone || u.Phone == model.EmailOrPhone);

                if (user != null)
                {
                    if (user.Password == model.Password)
                    {
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Fname),
                    new Claim(ClaimTypes.NameIdentifier, user.User_ID.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.User_Type)
                };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect password.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User not found. Please register first.");
                    ViewBag.ShowRegisterLink = true;
                }
            }

            return View(model);
        }


        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _useres.FirstOrDefault(u =>
                    u.Email == model.EmailOrPhone || u.Phone == model.EmailOrPhone);

                if (existingUser != null)
                {
                    ViewBag.ToLogin = true;
                    ModelState.AddModelError("", "A user with this email or phone already exists.");
                    return View(model);
                }

                var newUser = new LoginUserViewModel
                {
                    Fname = model.Name,
                    Email = model.EmailOrPhone.Contains("@") ? model.EmailOrPhone : null,
                    Phone = model.EmailOrPhone.Contains("@") ? null : model.EmailOrPhone,
                    Password = model.Password,
                    User_Type = "Customer" 
                };

                _useres.Add(newUser);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, newUser.Fname),
                    new Claim(ClaimTypes.NameIdentifier, newUser.User_ID.ToString()),
                    new Claim(ClaimTypes.Email, newUser.Email ?? ""),
                    new Claim(ClaimTypes.Role, newUser.User_Type)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Register");
        }
    }
}