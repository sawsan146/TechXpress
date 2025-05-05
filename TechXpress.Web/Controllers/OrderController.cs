using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Controllers
{
    public class OrderController : Controller
    {

        //List<OrderViewModel> orders = new List<OrderViewModel>
        //{
        //    new OrderViewModel { OrderId = 1, CustomerName = "Ahmed Ali", OrderDate = DateTime.Now.AddDays(-2), TotalAmount = 245.50m, Status = "Pending" },
        //    new OrderViewModel { OrderId = 2, CustomerName = "Sara Mostafa", OrderDate = DateTime.Now.AddDays(-1), TotalAmount = 100.00m, Status = "Shipped" },
        //    new OrderViewModel { OrderId = 3, CustomerName = "Youssef Kamal", OrderDate = DateTime.Now, TotalAmount = 500.00m, Status = "Delivered" }
        //};

        public IActionResult Index()
        {

            List<OrderViewModel> orders=GetFakeOrders();
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role != "Admin")
            {
                return Unauthorized(); 
            }
            ViewData["ActivePage"] = "Order";



            return View("AllOrdersForAdmin", orders);
        }

        public IActionResult Filter(string status)
        {
            var fakeOrders = GetFakeOrders();

            if (!string.IsNullOrEmpty(status) && status != "All")
            {
                fakeOrders = fakeOrders.Where(o => o.Status == status).ToList();
            }

            return PartialView("_OrdersTablePartial", fakeOrders);
        }

        private List<OrderViewModel> GetFakeOrders()
        {
            return new List<OrderViewModel>
    {
        new OrderViewModel { OrderId = 1, CustomerName = "Ali", OrderDate = DateTime.Today.AddDays(-1), TotalAmount = 120, Status = "Pending" },
        new OrderViewModel { OrderId = 2, CustomerName = "Sara", OrderDate = DateTime.Today.AddDays(-3), TotalAmount = 80, Status = "Delivered" },
        new OrderViewModel { OrderId = 3, CustomerName = "Omar", OrderDate = DateTime.Today.AddDays(-2), TotalAmount = 50, Status = "Shipped" },
        new OrderViewModel { OrderId = 4, CustomerName = "Lina", OrderDate = DateTime.Today.AddDays(-5), TotalAmount = 200, Status = "Cancelled" },
        new OrderViewModel { OrderId = 5, CustomerName = "Mona", OrderDate = DateTime.Today.AddDays(-4), TotalAmount = 150, Status = "Delivered" }
    };
        }

        public IActionResult OrderSummary()
        {
            var viewModel = new OrderSummaryViewModel
            {
                FirstName = "Md",
                LastName = "Rimel",
                Street = "Kingston, 5236, United States",
                City = "LA",
                Country = "United State",
                PhoneNumber = "0123456789",
                OrderItems = new List<OrderItemViewModel>
        {
            new OrderItemViewModel { ProductName = "Laptop", Price = 800, Quantity = 1 },
            new OrderItemViewModel { ProductName = "Headphones", Price = 200, Quantity = 2 },
            new OrderItemViewModel { ProductName = "Mouse", Price = 100, Quantity = 2 },
        }
            };

            return View(viewModel);
        }


    }
}
