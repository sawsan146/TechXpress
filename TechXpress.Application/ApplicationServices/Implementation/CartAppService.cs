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
            var dto = _mapper.Map<ShoppingCartDTO>(cart);

            dto.CartItems = dto.CartItems.Select(ci => new CartItemDTO
            {
                Cart_Item_ID = ci.Cart_Item_ID,
                Product_ID = ci.Product_ID,
                ProductName = ci.ProductName,
                Quantity = ci.Quantity,
                Price = ci.Price,
                ProductImage = cart.CartItems
                    .Where(c => c.Cart_Item_ID == ci.Cart_Item_ID)
                    .Select(c => c.Product?.ProductImages.FirstOrDefault()?.ImageURL) 
                    .FirstOrDefault()
            }).ToList();

            return dto;
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
