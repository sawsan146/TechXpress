using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.DTOs;
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IWishListAppService _wishListAppService;
        private readonly IProductAppService _productAppService;

        public WishlistController(IWishListAppService wishListAppService, IProductAppService productAppService)
        {
            _wishListAppService = wishListAppService;
            _productAppService = productAppService;
        }

        private int GetCurrentUserId()
        {
            // Assumes user ID is stored as claim type "UserId" or "sub"
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "UserId" || c.Type == "sub");
            if (userIdClaim == null)
                return 0;

            return int.TryParse(userIdClaim.Value, out var userId) ? userId : 0;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            var userId = GetCurrentUserId();
            if (userId == 0)
                return RedirectToAction("Login", "Account");

            var wishlistDto = await _wishListAppService.GetWishListByUserIdAsync(userId);

            // Map WishListItemDto to your WishListItemsViewModel for the View
            var wishlistItems = wishlistDto.Items.Select(item => new WishListItemsViewModel
            {
                WishList_Item_ID = item.Id,
                Price = item.Price,
                Product = new ProductViewModel
                {
                    Id = 0, // you can get real Id if you extend your DTO or add it here
                    Name = item.ProductName,
                    Image = item.ProductImageUrl,
                    Price = item.Price,
                    // ReviewCount and Rating are not available from DTO, default to 0 or remove from UI
                   
                }
            }).ToList();

            var viewModel = new WishlistViewModel
            {
                WishlistItems = wishlistItems
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToWishList(int productId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            var userId = GetCurrentUserId();
            if (userId == 0)
                return RedirectToAction("Login", "Account");

            // Get product details to know price
            ProductDTO productDto;
            try
            {
                productDto = _productAppService.GetProductById(productId);
            }
            catch
            {
                return NotFound();
            }

            if (productDto == null)
                return NotFound();

            // Check if product is already in wishlist (optional)
            var alreadyInWishlist = await _wishListAppService.IsProductInWishListAsync(userId, productId);
            if (!alreadyInWishlist)
            {
                await _wishListAppService.AddItemToWishListAsync(userId, productId, productDto.Price);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromWishlist(int wishListItemId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            await _wishListAppService.RemoveItemFromWishListAsync(wishListItemId);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> AddToWishList(int userId, int productId)
        {
            // For test purposes, hardcode a price or get it from database if you want
            float testPrice = 10.0f;

            await _wishListAppService.AddItemToWishListAsync(userId, productId, testPrice);

            return Content($"Product {productId} added to user {userId} wishlist.");
        }
    }
}

