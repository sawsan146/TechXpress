using Microsoft.AspNetCore.Mvc;

namespace TechXpress.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult MyAccount()
        {
            return View();
        }
    }
}
