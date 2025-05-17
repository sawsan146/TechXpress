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

        public ShoppingCart GetCartByCookie(string cookieValue, int? CurrentUserId)
        {
            return _unitOfWork.CartRepository.GetCartByCookie(cookieValue, CurrentUserId);
        }

        public ShoppingCart AddToCart(string cookieValue, int productId, int? CurrentUserId)
        {
            return _unitOfWork.CartRepository.AddToCart(cookieValue, productId, CurrentUserId);
        }


        public ShoppingCart UpdateCartItemQuantity(string cookieValue, int cartItemId, int quantityChange, int? CurrentUserId)
        {
            return _unitOfWork.CartRepository.UpdateCartItemQuantity(cookieValue, cartItemId, quantityChange,CurrentUserId);
        }

        public ShoppingCart RemoveFromCart(string cookieValue, int cartItemId, int? CurrentUserId)
        {
            return _unitOfWork.CartRepository.RemoveFromCart(cookieValue, cartItemId, CurrentUserId);
        }

        public int PlaceOrder(string cookieValue, int userId)
        {
            return _unitOfWork.CartRepository.PlaceOrder(cookieValue, userId);
        }
    }

   
}
