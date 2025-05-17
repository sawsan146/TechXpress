using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Application.DTOs;

namespace TechXpress.Application.ApplicationServices.Contract
{
    public interface ICartAppService
    {

       public ShoppingCartDTO GetCartFromCookie(string cookieValue, int? CurrentUserId);
       public ShoppingCartDTO AddToCart(string cookieValue, ProductDTO product, int? CurrentUserId);
       public ShoppingCartDTO UpdateCartQuantity(string cookieValue, int cartItemId, int quantityChange, int? CurrentUserId);
       public ShoppingCartDTO RemoveFromCart(string cookieValue, int cartItemId, int? CurrentUserId);
       public int PlaceOrder(string cookieValue, int userId);
    }
}
