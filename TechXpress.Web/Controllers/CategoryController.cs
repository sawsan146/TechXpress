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


        private List<CategoryViewModel> categories = new List<CategoryViewModel>
            {
                new CategoryViewModel { Id = "1", Name = "Electronics", Description="this is c1" },
                new CategoryViewModel { Id = "2", Name = "Clothing", Description="This is c2" },
                new CategoryViewModel { Id = "3", Name = "Home Appliances",  Description="This is c3"},
                new CategoryViewModel { Id = "4", Name = "Books", Description="This is c4"},
            };


        [Authorize(Roles = "Admin")]
        public IActionResult CategoryDashboard()
        {
            ViewData["ActivePage"] = "Category";


            return View(categories);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddCategory()
        {
            var userName = Request.Cookies["UserName"] ?? "Guest";
            ViewBag.UserName = userName;

            var category = new CategoryViewModel();
            return View("AddCategory",category);
        }


        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            ModelState.Remove("Id"); // Remove Id from ModelState validation
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var newCategory = new CategoryViewModel
            {
                Id = (categories.Count + 1).ToString(),
                Name = model.Name,
                Description = model.Description
            };
            categories.Add(newCategory);
            TempData["SuccessMessage"] = "Category added successfully.";
            return RedirectToAction("CategoryDashboard");
        }


        [Authorize(Roles = "Admin")]
        public IActionResult UpdateCategory(int id)
        {

            var category = categories.FirstOrDefault(c => c.Id == id.ToString());
            return View("UpdateCategory", category);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [HttpPost]
        public IActionResult UpdateCategory(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = categories.FirstOrDefault(c => c.Id == model.Id);
            if (category == null)
            {
                return NotFound();
            }

            category.Name = model.Name;
            category.Description = model.Description;

            TempData["SuccessMessage"] = "Category updated successfully.";

            return RedirectToAction("CategoryDashboard");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id.ToString());
            if (category != null)
            {
                categories.Remove(category);
                TempData["SuccessMessage"] = "Category deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Category not found.";
            }
            return RedirectToAction("CategoryDashboard");

        }
    }
}
