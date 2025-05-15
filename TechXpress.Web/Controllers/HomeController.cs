using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.DAL.Entities;
using TechXpress.Web.Models;
using TechXpress.Web.ViewModel;


namespace TechXpress.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductAppService _ProductAppService;
        private readonly ICategoryAppService _CategoryAppService;

        public HomeController(ILogger<HomeController> logger, IProductAppService productAppService, ICategoryAppService categoryAppService)
        {
            _logger = logger;
            _ProductAppService = productAppService;
           _CategoryAppService = categoryAppService;
        }

     
        public IActionResult Index()
        {
        
          var productDTOList = _ProductAppService.GetAllProducts();

            var ProductVm = productDTOList.Select(
                p => new ProductViewModel
                {
                    Id = p.ProductID,
                    Name = p.Name,
                    Image = p.UploadedImages.First(),
                    Price = p.Price,
                    Category = p.CategoryName
                }).ToList();     

         
           
            var categoriesVm= _CategoryAppService.GetAllCategories()
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    IsSelected = false
                }).ToList();

            ViewBag.ProductVm = ProductVm;
            ViewBag.categoriesVm = categoriesVm;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
