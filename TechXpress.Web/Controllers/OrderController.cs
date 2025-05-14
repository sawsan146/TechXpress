using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TechXpress.Web.ViewModel;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Infrastructure; // Assuming your entities are in the DAL namespace

namespace TechXpress.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        // Inject AppDbContext into the controller
        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        // Fetch all orders for admin
        public IActionResult Index()
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role != "Admin")
            {
                return Unauthorized();
            }

            ViewData["ActivePage"] = "Order";

            // Get orders from database
            var orders = _context.Orders
                .Include(o => o.User) // Include user data
                .Select(o => new OrderViewModel
                {
                    OrderId = o.Order_ID,
                    CustomerName = o.User.Fname + " " + o.User.Lname,
                    OrderDate = o.CreationTime,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status
                })
                .ToList();

            return View("AllOrdersForAdmin", orders);
        }

        // Filter orders based on status
        public IActionResult Filter(string status)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role != "Admin")
            {
                return Unauthorized();
            }

            // Get filtered orders from database
            var orders = _context.Orders
                .Include(o => o.User)
                .Where(o => string.IsNullOrEmpty(status) || status == "All" || o.Status == status)
                .Select(o => new OrderViewModel
                {
                    OrderId = o.Order_ID,
                    CustomerName = o.User.Fname + " " + o.User.Lname,
                    OrderDate = o.CreationTime,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status
                })
                .ToList();

            return PartialView("_OrdersTablePartial", orders);
        }

        // Show order summary
        public IActionResult OrderSummary(int orderId)
        {
            // Fetch the order with details and products from the database
            var order = _context.Orders
                .Include(o => o.User) // Get the user for the order
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product) // Include product details for each order detail
                .FirstOrDefault(o => o.Order_ID == orderId);

            if (order == null)
            {
                return NotFound(); // Return 404 if the order doesn't exist
            }

            var viewModel = new OrderSummaryViewModel
            {
                FirstName = order.User.Fname,
                LastName = order.User.Lname,
                Street = order.ShippingGoal ?? "N/A", // You can replace it with actual address if available
                City = "N/A", // Add logic to fetch city from the address if available
                Country = order.User.Country ?? "N/A",
                PhoneNumber = order.User.Phone,
                OrderItems = order.OrderDetails.Select(item => new OrderItemViewModel
                {
                    ProductName = item.Product?.Name ?? "Unknown", // Handle null product gracefully
                    Price = item.Price,
                    Quantity = item.Quantity
                }).ToList()
            };

            return View(viewModel); // Pass the view model to the view
        }
    }
}
