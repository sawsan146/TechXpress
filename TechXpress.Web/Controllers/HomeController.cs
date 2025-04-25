using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
                Name = "Product 1",
                Image = "Laptop.jpg",
                Price = 400f,
                ReviewCount = 5,
                Rating=1
            },
            new ProductViewModel
            {

                    Id = 2,
                Name = "Product 2",
                Image = "Laptop.jpg",
                Price =300f,
                ReviewCount = 5,
                Rating = 1
            },
            new ProductViewModel
            {

                    Id = 3,
                Name = "Product 1",
                Image = "Laptop.jpg",
                Price = 540f,
                ReviewCount = 23,
                Rating = 3
            },
            new ProductViewModel
            {

                    Id = 4,
                Name = "Product 1",
                Image = "Laptop.jpg",
                Price = 900,
                ReviewCount = 54,
                Rating = 5
            },
            new ProductViewModel
            {

                    Id = 5,
                Name = "Product 1",
                Image = "Laptop.jpg",
                Price = 200f,
                ReviewCount = 29,
                Rating = 2
            },
            new ProductViewModel
            {

                    Id = 6,
                Name = "Product 1",
                Image = "Laptop.jpg",
                Price = 340f,
                ReviewCount = 48,
                Rating = 4  
            },
            new ProductViewModel
            {

                    Id = 7,
                Name = "Product 1",
                Image = "Laptop.jpg",
                Price = 670f,
                ReviewCount = 90,
                Rating = 5
            },
            new ProductViewModel
            {

                Id = 8,
                Name = "Product 1",
                Image = "Laptop.jpg",
                Price = 100,
                ReviewCount = 50,
                Rating=1
            }


            };
            ViewBag.ProductVm = ProductVm;
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
