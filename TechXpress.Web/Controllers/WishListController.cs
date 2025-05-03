using Microsoft.AspNetCore.Mvc;

namespace TechXpress.Web.Controllers
{
    public class WishListController : Controller
    {
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Register");
            }
            else
            {
                return View();
            }
        }
    }
}
