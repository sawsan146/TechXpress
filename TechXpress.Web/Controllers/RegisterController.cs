using Microsoft.AspNetCore.Mvc;
using TechXpress.Web.Models;

namespace TechXpress.Web.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}