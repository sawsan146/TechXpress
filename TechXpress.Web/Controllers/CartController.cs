#region MyRegion
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using TechXpress.DAL.Entities;
//using TechXpress.DAL.Infrastructure;
//using TechXpress.Web.ViewModel;
//using TechXpress.Application.ApplicationServices.Contract;
//using TechXpress.Application.DTOs;

//namespace TechXpress.Web.Controllers
//{
//    public class CartController : Controller
//    {
//        private readonly IProductAppService _productAppService;
//        private readonly AppDbContext _context;

//        public CartController(IProductAppService productAppService, AppDbContext context)
//        {
//            _productAppService = productAppService;
//            _context = context;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            var cartItemsJson = Request.Cookies["CartItems"];
//            var cartItems = string.IsNullOrEmpty(cartItemsJson)
//                ? new List<CartitemsViewModel>()
//                : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);

//            var viewModel = new ShoppingCartViewModel
//            {
//                ShoppingCartList = cartItems,
//                OrderTotal = cartItems.Sum(i => i.Quantity * i.Product.Price)
//            };

//            return View(viewModel);
//        }

//        [HttpPost]
//        public IActionResult Index(int product_id)
//        {
//            if (!User.Identity.IsAuthenticated)
//            {
//                return RedirectToAction("Login", "Register");
//            }
//            else
//            {
//                var productDto = _productAppService.GetProductById(product_id);
//                if (productDto != null)
//                {
//                    var cartItemsJson = Request.Cookies["CartItems"];
//                    var cartItems = string.IsNullOrEmpty(cartItemsJson)
//                        ? new List<CartitemsViewModel>()
//                        : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);

//                    var cartItem = cartItems.FirstOrDefault(c => c.Product.Id == product_id);

//                    if (cartItem != null)
//                    {
//                        cartItem.Quantity += 1;
//                    }
//                    else
//                    {
//                        cartItems.Add(new CartitemsViewModel
//                        {
//                            Cart_Item_ID = cartItems.Count + 1,
//                            Product = new ProductViewModel
//                            {
//                                Id = productDto.Id,
//                                Name = productDto.Name,
//                                Price = (float)productDto.Price,
//                                Image = productDto.Image ?? string.Empty // إذا Image كان null
//                            },
//                            Quantity = 1,
//                            Price = (float)productDto.Price
//                        });
//                    }

//                    var updatedCartItemsJson = JsonConvert.SerializeObject(cartItems);
//                    Response.Cookies.Append("CartItems", updatedCartItemsJson, new CookieOptions { HttpOnly = true });

//                    var viewModel = new ShoppingCartViewModel
//                    {
//                        ShoppingCartList = cartItems,
//                        OrderTotal = cartItems.Sum(i => i.Quantity * i.Product.Price)
//                    };

//                    return View(viewModel);
//                }
//                else
//                {
//                    return NotFound();
//                }
//            }
//        }

//        [HttpPost]
//        public IActionResult Remove(int cartId)
//        {
//            var cartItemsJson = Request.Cookies["CartItems"];
//            var cartItems = string.IsNullOrEmpty(cartItemsJson)
//                ? new List<CartitemsViewModel>()
//                : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);
//            var item = cartItems.Find(c => c.Cart_Item_ID == cartId);

//            if (item is not null)
//            {
//                cartItems.Remove(item);
//                var updatedCartItemsJson = JsonConvert.SerializeObject(cartItems);
//                Response.Cookies.Append("CartItems", updatedCartItemsJson, new CookieOptions { HttpOnly = true });
//            }

//            return RedirectToAction(nameof(Index));
//        }

//        [HttpPost]
//        public IActionResult Minus(int cartId)
//        {
//            var cartItemsJson = Request.Cookies["CartItems"];
//            var cartItems = string.IsNullOrEmpty(cartItemsJson)
//                ? new List<CartitemsViewModel>()
//                : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);

//            var item = cartItems.Find(c => c.Cart_Item_ID == cartId);

//            if (item is not null && item.Quantity > 1)
//            {
//                item.Quantity -= 1;

//                var updatedCartItemsJson = JsonConvert.SerializeObject(cartItems);
//                Response.Cookies.Append("CartItems", updatedCartItemsJson, new CookieOptions { HttpOnly = true });
//            }

//            return RedirectToAction(nameof(Index));
//        }

//        [HttpPost]
//        public IActionResult Plus(int cartId)
//        {
//            var cartItemsJson = Request.Cookies["CartItems"];
//            var cartItems = string.IsNullOrEmpty(cartItemsJson)
//                ? new List<CartitemsViewModel>()
//                : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);

//            var item = cartItems.Find(c => c.Cart_Item_ID == cartId);

//            if (item is not null)
//            {
//                item.Quantity += 1;

//                var updatedCartItemsJson = JsonConvert.SerializeObject(cartItems);
//                Response.Cookies.Append("CartItems", updatedCartItemsJson, new CookieOptions { HttpOnly = true });
//            }

//            return RedirectToAction(nameof(Index));
//        }

//        [HttpPost]
//        public IActionResult PlaceOrder()
//        {
//            if (!User.Identity.IsAuthenticated)
//            {
//                return RedirectToAction("Login", "Register");
//            }

//            var cartItemsJson = Request.Cookies["CartItems"];
//            var cartItems = string.IsNullOrEmpty(cartItemsJson)
//                ? new List<CartitemsViewModel>()
//                : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);

//            if (cartItems == null || !cartItems.Any())
//            {
//                TempData["Error"] = "Your cart is empty. Add some products first.";
//                return RedirectToAction("Index");
//            }

//            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
//            if (string.IsNullOrEmpty(userId))
//            {
//                return RedirectToAction("Login", "Register");
//            }

//            var order = new Order
//            {
//                User_ID = int.Parse(userId),
//                CreationTime = DateTime.Now,
//                TotalAmount = cartItems.Sum(i => i.Quantity * i.Price),
//                Status = "Pending"
//            };

//            var orderDetails = cartItems.Select(item => new OrderDetails
//            {
//                Product_ID = item.Product.Id,
//                Quantity = item.Quantity,
//                Price = item.Price
//            }).ToList();

//            _context.Orders.Add(order);
//            _context.SaveChanges();

//            foreach (var detail in orderDetails)
//            {
//                detail.Order_ID = order.Order_ID;
//                _context.OrderDetails.Add(detail);
//            }
//            _context.SaveChanges();

//            Response.Cookies.Delete("CartItems");

//            return RedirectToAction("OrderSummary", "Order", new { orderId = order.Order_ID });
//        }
//    }
////} 
#endregion

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.DTOs;
using TechXpress.Web.ViewModel;
using System.Security.Claims;

namespace TechXpress.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartAppService _cartAppService;
        private readonly IProductAppService _productAppService;

        public CartController(ICartAppService cartAppService, IProductAppService productAppService)
        {
            _cartAppService = cartAppService;
            _productAppService = productAppService;
        }

        private string GetCartCookie()
        {
            return Request.Cookies["CartCookie"] ?? Guid.NewGuid().ToString();
        }

        private void SetCartCookie(string cookieValue)
        {
            Response.Cookies.Append("CartCookie", cookieValue, new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTimeOffset.UtcNow.AddDays(30)
            });
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cookie = GetCartCookie();
            SetCartCookie(cookie);

            var cartDto = _cartAppService.GetCartFromCookie(cookie);

            var viewModel = new ShoppingCartViewModel
            {
                ShoppingCartList = cartDto?.CartItems?.Select(ci => new CartitemsViewModel
                {
                    Cart_Item_ID = ci.Cart_Item_ID,
                    Product = new ProductViewModel
                    {
                        Id = ci.Product_ID,
                        Name = ci.ProductName,
                        Price = (float)ci.Price,
                        Image = ci.ProductImage ?? string.Empty
                    },
                    Quantity = ci.Quantity,
                    Price = (float)ci.Price
                }).ToList() ?? new List<CartitemsViewModel>(),

                OrderTotal = cartDto?.CartItems?.Sum(ci => ci.Quantity * ci.Price) ?? 0
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Register");

            var productDto = _productAppService.GetProductById(productId);
            if (productDto == null)
                return NotFound();

            var cookie = GetCartCookie();
            SetCartCookie(cookie);

            var updatedCart = _cartAppService.AddToCart(cookie, productDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Remove(int cartItemId)
        {
            var cookie = GetCartCookie();
            SetCartCookie(cookie);

            var updatedCart = _cartAppService.RemoveFromCart(cookie, cartItemId);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DecreaseQuantity(int cartItemId)
        {
            var cookie = GetCartCookie();
            SetCartCookie(cookie);

            var updatedCart = _cartAppService.UpdateCartQuantity(cookie, cartItemId, -1);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult IncreaseQuantity(int cartItemId)
        {
            var cookie = GetCartCookie();
            SetCartCookie(cookie);

            var updatedCart = _cartAppService.UpdateCartQuantity(cookie, cartItemId, +1);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult PlaceOrder()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Register");

            var cookie = GetCartCookie();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login", "Register");

            var orderId = _cartAppService.PlaceOrder(cookie, int.Parse(userId));

            if (orderId == 0)
            {
                TempData["Error"] = "Your cart is empty. Add some products first.";
                return RedirectToAction(nameof(Index));
            }

            // حذف الكوكي بعد طلب الأوردر
            Response.Cookies.Delete("CartCookie");

            return RedirectToAction("OrderSummary", "Order", new { orderId });
        }
    }
}
