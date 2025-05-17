using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.DTOs;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Infrastructure;
using TechXpress.Web.ViewModel;

namespace TechExpress.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IMapper _mapper;

        public ProductController(IProductAppService productAppService, ICategoryAppService categoryAppService, IMapper mapper)
        {
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
            _mapper = mapper;
        }
      

        public IActionResult Index(string category, string search)
        {

            var allProducts = _productAppService.GetAllProductsWithCategories();

            if (!string.IsNullOrEmpty(category) && category != "All Products")
            {
                allProducts = allProducts
                    .Where(p => p.CategoryName == category)
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                allProducts = allProducts
                    .Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            var viewModel = new ProductListViewModel
            {
                Products = _mapper.Map<List<ProductDashBoardViewModel>>(allProducts),                

                Categories = _categoryAppService.GetAllCategories().Select(c => c.Name).ToList(),
                SelectedCategory = category ?? "All Products",
                SearchQuery = search ?? string.Empty
            };

            return View("AllProduct", viewModel);
        }

        public IActionResult HomeProductSection()
        {
            var products = _productAppService.GetAllProducts();

            var viewModel = products.Select(p => new ProductViewModel
            {
                Id = p.ProductID,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                //Category = p.Category != null ? p.Category.Name : "",
                Image = p.UploadedImages != null && p.UploadedImages.Any()
                ? p.UploadedImages.FirstOrDefault()
                : "/images/placeholder.jpg",
                //ReviewCount = p.Reviews != null ? p.Reviews.Count : 0,
                //Rating = p.Reviews != null && p.Reviews.Any() ? p.Reviews.Average(r => r.Rating) : 0
            }).ToList();

            return PartialView("_HomeProductSection", viewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ProductDashBoard()
        {
            var products = _productAppService.GetAllProducts();
            var viewModels = products.Select(p => _mapper.Map<ProductDashBoardViewModel>(p)).ToList();
            ViewBag.categories = _categoryAppService.GetAllCategories().Select(c => new { c.Name ,c.Id} ).ToList();
            return View(viewModels);
        }
    

        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct()
        {
            var userName = Request.Cookies["UserName"] ?? "Guest";
            ViewBag.UserName = userName;

            ProductDashBoardViewModel vm = new ProductDashBoardViewModel()
            {
                Categories = _categoryAppService.GetAllCategories().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList(),


            };

            return View("AddProductDashBoard", vm);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProduct(ProductDashBoardViewModel vm)
        {
            ModelState.Remove("Categories");
            ModelState.Remove("CategoryName");
            ModelState.Remove("ImageNamesForDisplay");

            if (ModelState.IsValid)
            {
                var productDto = _mapper.Map<ProductDTO>(vm);

                if (vm.UploadedImages != null && vm.UploadedImages.Any())
                {
                    productDto.UploadedImages = new List<string>();
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/product");

                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    foreach (var image in vm.UploadedImages)
                    {
                        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                        }

                        productDto.UploadedImages.Add(uniqueFileName);
                    }
                }

                _productAppService.AddProduct(productDto);

                TempData["SuccessMessage"] = "Product added successfully!";
                return RedirectToAction("ProductDashBoard");
            }

            vm.Categories = _categoryAppService.GetAllCategories().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            return View("AddProductDashBoard", vm);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult UpdateProduct(int id)
        {
            var product = _productAppService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<ProductDashBoardViewModel>(product);

            viewModel.Categories = _categoryAppService.GetAllCategories().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            ViewBag.ExistingImages = product.UploadedImages?.Select(img => img).ToList();

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult UpdateProduct(ProductDashBoardViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var categories = _categoryAppService.GetAllCategories();
                viewModel.Categories = _categoryAppService.GetAllCategories().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
                return View(viewModel);
            }

            var productDto = _mapper.Map<ProductDTO>(viewModel);
            _productAppService.UpdateProduct(productDto);

            return RedirectToAction("ProductDashBoard");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(int id)
        {
            _productAppService.DeleteProduct(id);
            return RedirectToAction("ProductDashBoard");
        }

        public IActionResult ProductDetails(int id)
        {
            var product = _productAppService.GetAllProductsWithCategoriesAndImages().FirstOrDefault(p => p.ProductID == id);
       
                var vm= _mapper.Map<ProductDetailsViewModel>(product);
            if (product == null)
            {
                return NotFound();
            }
            return View(vm);
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

