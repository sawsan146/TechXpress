using Microsoft.AspNetCore.Mvc;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.DTOs;
using TechXpress.Web.ViewModel;
using System.Security.Claims;
using System;
using System.Linq;
using System.Collections.Generic;

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

        private int? CurrentUserId =>
            User.Identity.IsAuthenticated ? int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)) : (int?)null;

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

            var cartDto = _cartAppService.GetCartFromCookie(cookie, CurrentUserId);

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

            var updatedCart = _cartAppService.AddToCart(cookie, productDto, CurrentUserId);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Remove(int cartItemId)
        {
            var cookie = GetCartCookie();
            SetCartCookie(cookie);

            var updatedCart = _cartAppService.RemoveFromCart(cookie, cartItemId, CurrentUserId);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DecreaseQuantity(int cartItemId)
        {
            var cookie = GetCartCookie();
            SetCartCookie(cookie);

            var updatedCart = _cartAppService.UpdateCartQuantity(cookie, cartItemId, -1, CurrentUserId);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult IncreaseQuantity(int cartItemId)
        {
            var cookie = GetCartCookie();
            SetCartCookie(cookie);

            var updatedCart = _cartAppService.UpdateCartQuantity(cookie, cartItemId, +1, CurrentUserId);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult PlaceOrder()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Register");

            var cookie = GetCartCookie();

            if (!CurrentUserId.HasValue)
                return RedirectToAction("Login", "Register");

            var orderId = _cartAppService.PlaceOrder(cookie, CurrentUserId.Value);

            if (orderId == 0)
            {
                TempData["Error"] = "Your cart is empty. Add some products first.";
                return RedirectToAction(nameof(Index));
            }

            Response.Cookies.Delete("CartCookie");

            return RedirectToAction("OrderSummary", "Order", new { orderId });
        }
    }
}
