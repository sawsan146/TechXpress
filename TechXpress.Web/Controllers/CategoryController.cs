using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin")]
        public IActionResult CategoryDashboard()
        {
            ViewData["ActivePage"] = "Category";
            var categories = new List<CategoryViewModel>
            {
                new CategoryViewModel { Id = "1", Name = "Electronics", IsSelected = true },
                new CategoryViewModel { Id = "2", Name = "Clothing", IsSelected = false },
                new CategoryViewModel { Id = "3", Name = "Home Appliances", IsSelected = true },
                new CategoryViewModel { Id = "4", Name = "Books", IsSelected = false },
            };

            return View(categories);
        }
    }
}
