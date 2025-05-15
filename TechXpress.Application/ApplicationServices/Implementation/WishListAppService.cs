using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.DTOs;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace TechXpress.Application.ApplicationServices.Implementation
{
    public class WishListAppService : IWishListAppService
    {
        private readonly AppDbContext _context;

        public WishListAppService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<WishListDto> GetWishListByUserIdAsync(int userId)
        {
            var wishlist = await _context.WishLists
                .FirstOrDefaultAsync(w => w.User_ID == userId);

            if (wishlist == null)
                return new WishListDto { Items = new List<WishListItemDto>() };

            var items = await _context.WishListItems
                .Where(wi => wi.WishList_ID == wishlist.WishList_ID)
                .Join(_context.Products,
                      wi => wi.Product_ID,
                      p => p.Product_ID,
                      (wi, p) => new { WishListItem = wi, Product = p })
                .Select(x => new WishListItemDto
                {
                    Id = x.WishListItem.WishList_Item_ID,
                    Price = x.WishListItem.Price,
                    ProductName = x.Product.Name,
                    ProductImageUrl = _context.ProductImages
                            .Where(img => img.Product_ID == x.Product.Product_ID)
                            .Select(img => img.ImageURL)
                            .FirstOrDefault()
                })
                .ToListAsync();

            return new WishListDto { Items = items };
        }

        public async Task AddItemToWishListAsync(int userId, int productId, float price)
        {
            var wishlist = await _context.WishLists
                .FirstOrDefaultAsync(w => w.User_ID == userId);

            if (wishlist == null)
            {
                wishlist = new WishList
                {
                    User_ID = userId
                };
                _context.WishLists.Add(wishlist);
                await _context.SaveChangesAsync();
            }

            var exists = await _context.WishListItems
                .AnyAsync(wi => wi.WishList_ID == wishlist.WishList_ID && wi.Product_ID == productId);

            if (!exists)
            {
                var item = new WishListItems
                {
                    Product_ID = productId,
                    Price = price,
                    WishList_ID = wishlist.WishList_ID
                };

                _context.WishListItems.Add(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveItemFromWishListAsync(int wishListItemId)
        {
            var item = await _context.WishListItems
                .FirstOrDefaultAsync(wi => wi.WishList_Item_ID == wishListItemId);

            if (item != null)
            {
                _context.WishListItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ClearWishListAsync(int userId)
        {
            var wishlist = await _context.WishLists
                .FirstOrDefaultAsync(w => w.User_ID == userId);

            if (wishlist != null)
            {
                var items = await _context.WishListItems
                    .Where(wi => wi.WishList_ID == wishlist.WishList_ID)
                    .ToListAsync();

                _context.WishListItems.RemoveRange(items);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsProductInWishListAsync(int userId, int productId)
        {
            var wishlist = await _context.WishLists
                .FirstOrDefaultAsync(w => w.User_ID == userId);

            if (wishlist == null)
                return false;

            return await _context.WishListItems
                .AnyAsync(wi => wi.WishList_ID == wishlist.WishList_ID && wi.Product_ID == productId);
        }

        public async Task<int> GetWishListCountAsync(int userId)
        {
            var wishlist = await _context.WishLists
                .FirstOrDefaultAsync(w => w.User_ID == userId);

            if (wishlist == null)
                return 0;

            return await _context.WishListItems
                .CountAsync(wi => wi.WishList_ID == wishlist.WishList_ID);
        }
    }
}
