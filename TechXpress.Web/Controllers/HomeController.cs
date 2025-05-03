using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechXpress.Domain.Entities;
using TechXpress.Web.Models;
using TechXpress.Web.ViewModel;


namespace TechXpress.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ProductViewModel> ProductVm = new List<ProductViewModel> {

            new ProductViewModel
            {
                Id = 1,
                Name = "tablet",
                Image = "25e0a5d6-5154-45ce-a9ca-161096acc032.jpeg",

                Price = 400f,
                ReviewCount = 50,
                Rating=1
            },
            new ProductViewModel
            {

                    Id = 2,
                Name = "pc device",
                Image = "71Hk-ZbQAuL.__AC_SY300_SX300_QL70_ML2_.jpg",

                Price =300f,
                ReviewCount = 30,
                Rating = 1
            },
            new ProductViewModel
            {

                    Id = 3,

                Name = "smart watch",
                Image = "613Ay8pU9zL.__AC_SX300_SY300_QL70_ML2_.jpg",

                Price = 540f,
                ReviewCount = 20,
                Rating = 3
            },
            new ProductViewModel
            {

                    Id = 4,

                Name = "canon camera",
                Image = "81RLTx5tIUL._AC_SL1500_.jpg",

                Price = 900,
                ReviewCount = 15,
                Rating = 5
            },
            new ProductViewModel
            {

                    Id = 5,
                Name = "headphone",
                Image = "da6eac57-b91b-45aa-81f8-6185d4f60a6c.jpeg",

                Price = 200f,
                ReviewCount = 29,
                Rating = 2
            },
            new ProductViewModel
            {

                    Id = 6,
                Name = "playstation",
                Image = "controller-6032446_640.jpg",

                Price = 340f,
                ReviewCount = 48,
                Rating = 4  
            },
            new ProductViewModel
            {

                    Id = 7,
                Name = "samsung tablet",
                Image = "5a666c35-7feb-4ac6-8e84-868d875094cd.jpeg",
                Price = 670f,
                ReviewCount = 90,
                Rating = 5
            },
            new ProductViewModel
            {
                Id = 8,
                Name = "mouse",
                Image = "ff07d5fd-2b23-4a90-890e-e2620eca3b21.jpeg",

                Price = 100,
                ReviewCount = 50,
                Rating=1
            }


            };
          
            var categoriesVm = new List<CategoryViewModel>
        {
            new CategoryViewModel { Id = "phones", Name = "Phones", IsSelected = false },
            new CategoryViewModel { Id = "computers", Name ="Computers", IsSelected = true },
            new CategoryViewModel { Id = "smartwatch", Name = "Smart Watches", IsSelected = false },
            new CategoryViewModel { Id = "camera", Name = "Cameras", IsSelected = false },
            new CategoryViewModel { Id = "headphones", Name = "Head Phones", IsSelected = false },
            new CategoryViewModel { Id = "gaming", Name = "Games", IsSelected = false },
            new CategoryViewModel { Id = "tablet", Name = "Tablet", IsSelected = false },
            new CategoryViewModel { Id = "accessories", Name = "Accessories", IsSelected = false },
            new CategoryViewModel { Id = "tv", Name = "TV", IsSelected = false },
            new CategoryViewModel { Id = "laptop", Name = "Laptops", IsSelected = false },
            new CategoryViewModel { Id = "printer", Name = "Printers", IsSelected = false },
            new CategoryViewModel { Id = "monitor", Name = "Monitors", IsSelected = false },
            new CategoryViewModel { Id = "speakers", Name = "Speakers", IsSelected = false },



        };
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
