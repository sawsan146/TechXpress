using Microsoft.AspNetCore.Mvc;

namespace TechXpress.Web.Controllers
{
    public class WishListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
