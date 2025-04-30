using Microsoft.AspNetCore.Mvc;

namespace TechXpress.Web.ViewModel
{
    public class WishListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
