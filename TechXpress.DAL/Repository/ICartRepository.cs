using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;

namespace TechXpress.DAL.Repository
{
    public interface ICartRepository
    {
        ShoppingCart GetCartByCookie(string cookieValue);
        ShoppingCart AddToCart(string cookieValue, Product product);
        ShoppingCart UpdateCartItemQuantity(string cookieValue, int cartItemId, int quantityChange);
        ShoppingCart RemoveFromCart(string cookieValue, int cartItemId);
        int PlaceOrder(string cookieValue, int userId);
    }
}
