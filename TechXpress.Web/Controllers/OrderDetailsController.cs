using Microsoft.AspNetCore.Mvc;
using TechXpress.Domain.Entities;
using TechXpress.Domain.Infrastructure;

namespace TechXpress.Web.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public OrderDetailsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OrderSummary()
        {
            var orderDetails = new List<OrderDetails>
            {
                new OrderDetails { Order_ID = 1, Product_ID = 1, Quantity = 1, Price = 800, Order = new Order { Order_ID = 1 }, Product = new Product { Product_ID = 1 } },
                new OrderDetails { Order_ID = 1, Product_ID = 2, Quantity = 2, Price = 200, Order = new Order { Order_ID = 1 }, Product = new Product { Product_ID = 2 } },
                new OrderDetails { Order_ID = 1, Product_ID = 3, Quantity = 2, Price = 100, Order = new Order { Order_ID = 1 }, Product = new Product { Product_ID = 3 } }
            };
            ViewData["FirstName"] = "Md"; 
            ViewData["LastName"] = "Rimel"; 
            ViewData["Street"] = "Kingston, 5236, United States"; 
            ViewData["City"] = "LA"; 
            ViewData["Country"] = "United State"; 
            ViewData["PhoneNumber"] = "0123456789";
            ViewData["ProductName_1"] = "Laptop "; 
            ViewData["ProductName_2"] = "Headphones "; 
            ViewData["ProductName_3"] = "Mouse ";
            return View(orderDetails);
        }
    }
}