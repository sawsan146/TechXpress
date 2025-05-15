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

        public ShoppingCartDTO GetCartFromCookie(string cookieValue)
        {
            var cart = _cartService.GetCartByCookie(cookieValue);
            return _mapper.Map<ShoppingCartDTO>(cart);
        }

        public ShoppingCartDTO AddToCart(string cookieValue, ProductDTO product)
        {
            var productEntity = _mapper.Map<Product>(product);
            var updatedCart = _cartService.AddToCart(cookieValue, productEntity);
            return _mapper.Map<ShoppingCartDTO>(updatedCart);
        }

        public ShoppingCartDTO UpdateCartQuantity(string cookieValue, int cartItemId, int quantityChange)
        {
            var updatedCart = _cartService.UpdateCartItemQuantity(cookieValue, cartItemId, quantityChange);
            return _mapper.Map<ShoppingCartDTO>(updatedCart);
        }

        public ShoppingCartDTO RemoveFromCart(string cookieValue, int cartItemId)
        {
            var updatedCart = _cartService.RemoveFromCart(cookieValue, cartItemId);
            return _mapper.Map<ShoppingCartDTO>(updatedCart);
        }

        public int PlaceOrder(string cookieValue, int userId)
        {
            return _cartService.PlaceOrder(cookieValue, userId);
        }
    }
}
