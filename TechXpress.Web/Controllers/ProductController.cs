using Microsoft.AspNetCore.Mvc;

namespace TechXpress.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {

            return View("AllProducts");
        }
    }
}
