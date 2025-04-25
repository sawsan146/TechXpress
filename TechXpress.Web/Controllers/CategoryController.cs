using Microsoft.AspNetCore.Mvc;
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
          
            return View();
        }
    }
}
