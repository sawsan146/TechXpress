using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Infrastructure;
using TechXpress.Web.ViewModel;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.DTOs;

namespace TechXpress.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly AppDbContext _context;

        public CartController(IProductAppService productAppService, AppDbContext context)
        {
            _productAppService = productAppService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cartItemsJson = Request.Cookies["CartItems"];
            var cartItems = string.IsNullOrEmpty(cartItemsJson)
                ? new List<CartitemsViewModel>()
                : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);

            var viewModel = new ShoppingCartViewModel
            {
                ShoppingCartList = cartItems,
                OrderTotal = cartItems.Sum(i => i.Quantity * i.Product.Price)
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(int product_id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Register");
            }
            else
            {
                var productDto = _productAppService.GetProductById(product_id);
                if (productDto != null)
                {
                    var cartItemsJson = Request.Cookies["CartItems"];
                    var cartItems = string.IsNullOrEmpty(cartItemsJson)
                        ? new List<CartitemsViewModel>()
                        : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);

                    var cartItem = cartItems.FirstOrDefault(c => c.Product.Id == product_id);

                    if (cartItem != null)
                    {
                        cartItem.Quantity += 1;
                    }
                    else
                    {
                        cartItems.Add(new CartitemsViewModel
                        {
                            Cart_Item_ID = cartItems.Count + 1,
                            Product = new ProductViewModel
                            {
                                Id = productDto.Id,
                                Name = productDto.Name,
                                Price = (float)productDto.Price,
                                Image = productDto.Image ?? string.Empty // إذا Image كان null
                            },
                            Quantity = 1,
                            Price = (float)productDto.Price
                        });
                    }

                    var updatedCartItemsJson = JsonConvert.SerializeObject(cartItems);
                    Response.Cookies.Append("CartItems", updatedCartItemsJson, new CookieOptions { HttpOnly = true });

                    var viewModel = new ShoppingCartViewModel
                    {
                        ShoppingCartList = cartItems,
                        OrderTotal = cartItems.Sum(i => i.Quantity * i.Product.Price)
                    };

                    return View(viewModel);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public IActionResult Remove(int cartId)
        {
            var cartItemsJson = Request.Cookies["CartItems"];
            var cartItems = string.IsNullOrEmpty(cartItemsJson)
                ? new List<CartitemsViewModel>()
                : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);
            var item = cartItems.Find(c => c.Cart_Item_ID == cartId);

            if (item is not null)
            {
                cartItems.Remove(item);
                var updatedCartItemsJson = JsonConvert.SerializeObject(cartItems);
                Response.Cookies.Append("CartItems", updatedCartItemsJson, new CookieOptions { HttpOnly = true });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Minus(int cartId)
        {
            var cartItemsJson = Request.Cookies["CartItems"];
            var cartItems = string.IsNullOrEmpty(cartItemsJson)
                ? new List<CartitemsViewModel>()
                : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);

            var item = cartItems.Find(c => c.Cart_Item_ID == cartId);

            if (item is not null && item.Quantity > 1)
            {
                item.Quantity -= 1;

                var updatedCartItemsJson = JsonConvert.SerializeObject(cartItems);
                Response.Cookies.Append("CartItems", updatedCartItemsJson, new CookieOptions { HttpOnly = true });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Plus(int cartId)
        {
            var cartItemsJson = Request.Cookies["CartItems"];
            var cartItems = string.IsNullOrEmpty(cartItemsJson)
                ? new List<CartitemsViewModel>()
                : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);

            var item = cartItems.Find(c => c.Cart_Item_ID == cartId);

            if (item is not null)
            {
                item.Quantity += 1;

                var updatedCartItemsJson = JsonConvert.SerializeObject(cartItems);
                Response.Cookies.Append("CartItems", updatedCartItemsJson, new CookieOptions { HttpOnly = true });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult PlaceOrder()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Register");
            }

            var cartItemsJson = Request.Cookies["CartItems"];
            var cartItems = string.IsNullOrEmpty(cartItemsJson)
                ? new List<CartitemsViewModel>()
                : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);

            if (cartItems == null || !cartItems.Any())
            {
                TempData["Error"] = "Your cart is empty. Add some products first.";
                return RedirectToAction("Index");
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Register");
            }

            var order = new Order
            {
                User_ID = int.Parse(userId),
                CreationTime = DateTime.Now,
                TotalAmount = cartItems.Sum(i => i.Quantity * i.Price),
                Status = "Pending"
            };

            var orderDetails = cartItems.Select(item => new OrderDetails
            {
                Product_ID = item.Product.Id,
                Quantity = item.Quantity,
                Price = item.Price
            }).ToList();

            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var detail in orderDetails)
            {
                detail.Order_ID = order.Order_ID;
                _context.OrderDetails.Add(detail);
            }
            _context.SaveChanges();

            Response.Cookies.Delete("CartItems");

            return RedirectToAction("OrderSummary", "Order", new { orderId = order.Order_ID });
        }
    }
}