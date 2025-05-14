using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.DTOs.TechXpress.Web.DTO;
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CategoryDashboard()
        {
            ViewData["ActivePage"] = "Category";
            var categories = _categoryAppService.GetAllCategories();
            var viewModelList = categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                IsSelected = c.IsSelected
            }).ToList();

            return View(viewModelList);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddCategory()
        {
            var userName = Request.Cookies["UserName"] ?? "Guest";
            ViewBag.UserName = userName;

            return View(new CategoryViewModel());
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            ModelState.Remove("Id"); // Because Id is generated automatically

            if (!ModelState.IsValid)
                return View(model);

            var dto = new CategoryDto
            {
                Id = Guid.NewGuid().ToString(), // or let your DB handle it
                Name = model.Name,
                Description = model.Description,
                IsSelected = model.IsSelected
            };

            _categoryAppService.AddCategory(dto);
            TempData["SuccessMessage"] = "Category added successfully.";

            return RedirectToAction("CategoryDashboard");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult UpdateCategory(string id)
        {
            var dto = _categoryAppService.GetCategoryById(id);
            if (dto == null) return NotFound();

            var viewModel = new CategoryViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                IsSelected = dto.IsSelected
            };

            return View("UpdateCategory", viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UpdateCategory(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dto = new CategoryDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                IsSelected = model.IsSelected
            };

            _categoryAppService.UpdateCategory(dto);
            TempData["SuccessMessage"] = "Category updated successfully.";

            return RedirectToAction("CategoryDashboard");
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var category = _categoryAppService.GetCategoryById(id);
            if (category != null)
            {
                _categoryAppService.DeleteCategory(id);
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
