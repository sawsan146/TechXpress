using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;

namespace TechXpress.BLL.Services.Contracts
{
    public interface ICartService
    {
        ShoppingCart GetCartByCookie(string cookieValue, int? CurrentUserId);
        ShoppingCart AddToCart(string cookieValue, int  productId, int? CurrentUserId);
        ShoppingCart UpdateCartItemQuantity(string cookieValue, int cartItemId, int quantityChange, int? CurrentUserId);
        ShoppingCart RemoveFromCart(string cookieValue, int cartItemId, int? CurrentUserId);
        int PlaceOrder(string cookieValue, int userId);
    }

}
