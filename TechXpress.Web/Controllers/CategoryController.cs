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
                new CategoryViewModel { Id = "1", Name = "Electronics", Description="this is c1" },
                new CategoryViewModel { Id = "2", Name = "Clothing", Description="This is c2" },
                new CategoryViewModel { Id = "3", Name = "Home Appliances",  Description="This is c3"},
                new CategoryViewModel { Id = "4", Name = "Books", Description="This is c4"},
            };

            return View(categories);
        }
    }
}
