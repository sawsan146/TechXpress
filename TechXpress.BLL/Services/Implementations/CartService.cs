using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.BLL.Services.Contracts;
using TechXpress.DAL.Entities;
using TechXpress.DAL.UnitOfWork;

namespace TechXpress.BLL.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ShoppingCart GetCartByCookie(string cookieValue)
        {
            return _unitOfWork.CartRepository.GetCartByCookie(cookieValue);
        }

        public ShoppingCart AddToCart(string cookieValue, Product product)
        {
            return _unitOfWork.CartRepository.AddToCart(cookieValue, product);
        }

        public ShoppingCart UpdateCartItemQuantity(string cookieValue, int cartItemId, int quantityChange)
        {
            return _unitOfWork.CartRepository.UpdateCartItemQuantity(cookieValue, cartItemId, quantityChange);
        }

        public ShoppingCart RemoveFromCart(string cookieValue, int cartItemId)
        {
            return _unitOfWork.CartRepository.RemoveFromCart(cookieValue, cartItemId);
        }

        public int PlaceOrder(string cookieValue, int userId)
        {
            return _unitOfWork.CartRepository.PlaceOrder(cookieValue, userId);
        }
    }

   
}
