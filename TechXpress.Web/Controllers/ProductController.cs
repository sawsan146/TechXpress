using Microsoft.AspNetCore.Mvc;
using TechXpress.Domain.Entities;
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {

            return View("AllProducts");
        }

        // Logic to fetch product details by id
        // This is a placeholder. In a real application, you would fetch the product details from a database or service.
        public IActionResult ProductDetails()
        {



            return View("ProductDetails");
        }

     
    }
}
