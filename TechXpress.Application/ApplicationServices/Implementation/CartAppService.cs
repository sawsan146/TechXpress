using AutoMapper;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.DTOs;
using TechXpress.BLL.Services.Contracts;
using TechXpress.DAL.Entities;

namespace TechXpress.Application.ApplicationServices.Implementations
{
    public class CartAppService : ICartAppService
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public CartAppService(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        public ShoppingCartDTO GetCartFromCookie(string cookieValue, int? CurrentUserId)
        {
            var cart = _cartService.GetCartByCookie(cookieValue, CurrentUserId);
            return _mapper.Map<ShoppingCartDTO>(cart);
        }

        public ShoppingCartDTO AddToCart(string cookieValue, ProductDTO product, int? CurrentUserId)
        {
            var updatedCart = _cartService.AddToCart(cookieValue, product.ProductID, CurrentUserId);
            return _mapper.Map<ShoppingCartDTO>(updatedCart);
        }

        public ShoppingCartDTO UpdateCartQuantity(string cookieValue, int cartItemId, int quantityChange, int? CurrentUserId)
        {
            var updatedCart = _cartService.UpdateCartItemQuantity(cookieValue, cartItemId, quantityChange,CurrentUserId);
            return _mapper.Map<ShoppingCartDTO>(updatedCart);
        }

        public ShoppingCartDTO RemoveFromCart(string cookieValue, int cartItemId, int? CurrentUserId)
        {
            var updatedCart = _cartService.RemoveFromCart(cookieValue, cartItemId, CurrentUserId);
            return _mapper.Map<ShoppingCartDTO>(updatedCart);
        }

        public int PlaceOrder(string cookieValue, int userId)
        {
            return _cartService.PlaceOrder(cookieValue, userId);
        }
    }
}
