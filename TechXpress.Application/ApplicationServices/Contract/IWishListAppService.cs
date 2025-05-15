using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Application.DTOs;

namespace TechXpress.Application.ApplicationServices.Contract
{
    public interface IWishListAppService
    {
        Task<WishListDto> GetWishListByUserIdAsync(int userId);
        Task AddItemToWishListAsync(int userId, int productId, float price);
        Task RemoveItemFromWishListAsync(int wishListItemId);
        Task ClearWishListAsync(int userId);
        Task<bool> IsProductInWishListAsync(int userId, int productId);
        Task<int> GetWishListCountAsync(int userId);
    }


}
