using Microsoft.AspNetCore.Mvc;
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult MyAccount()
        {
            return View();
        }
        public IActionResult Orders()
        {
            var orders = new List<OrderViewModel>
        {
            new OrderViewModel
            {
                OrderId = 1,
                OrderDate = new DateTime(2025, 3, 19, 15, 17, 0), 
                TotalAmount = 350.00m,
                Status = "Delivered"
            },
            new OrderViewModel
            {
                OrderId = 2,
                OrderDate = new DateTime(2025, 3, 19, 15, 17, 0),
                TotalAmount = 575.00m,
                Status = "Delivered"
            }
        };
            return View(orders);
        }
        public IActionResult Returns()
        {
            var userEmail = User.Identity.Name;
            var returns = new List<OrderViewModel>
    {
        new OrderViewModel
        {
            OrderId = 1,
            OrderDate = new DateTime(2025, 3, 30, 18, 18, 0),
            TotalAmount = 350.00m,
            Status = "RETURNED"
        }
    };

            return View(returns);
        }
    }
}
