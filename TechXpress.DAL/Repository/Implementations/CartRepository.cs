using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Infrastructure;
using TechXpress.DAL.Repository.Contracts;

namespace TechXpress.DAL.Repository.Implementations
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public ShoppingCart GetCartByCookie(string cookieValue, int? CurrentUserId)
        {
            return _context.ShoppingCarts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .ThenInclude(ci=>ci.ProductImages)
                .FirstOrDefault(c => c.CookieValue == cookieValue);
        }

        public ShoppingCart AddToCart(string cookieValue, int productId, int? CurrentUserId)
        {

            var product = _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefault(p => p.Product_ID == productId); 
            
            if (product == null)
                throw new Exception("Product not found");

            var cart = _context.ShoppingCarts
                .Include(c => c.CartItems)
                .FirstOrDefault(c => c.CookieValue == cookieValue);

            if (cart == null)
            {
                cart = new ShoppingCart
                {
                    CookieValue = cookieValue,
                    Create_Date = DateTime.Now,
                    CartItems = new List<CartItems>(),
                    User_ID = CurrentUserId ?? 0
                };
                _context.ShoppingCarts.Add(cart);
            }

            var existingItem = cart.CartItems.FirstOrDefault(ci => ci.Product_ID == product.Product_ID);
            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }
            else
            {
                cart.CartItems.Add(new CartItems
                {
                    Product_ID = product.Product_ID,
                    Quantity = 1,
                    Price = product.Price                    
                });
            }

            _context.SaveChanges();
            return cart;
        }


        public ShoppingCart UpdateCartItemQuantity(string cookieValue, int cartItemId, int quantityChange, int? CurrentUserId)
        {
            var cart = _context.ShoppingCarts
                .Include(c => c.CartItems)
                .FirstOrDefault(c => c.CookieValue == cookieValue);

            if (cart == null) return null;

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.Cart_Item_ID == cartItemId);
            if (cartItem == null) return cart;

            cartItem.Quantity += quantityChange;

            if (cartItem.Quantity <= 0)
            {
                cart.CartItems.Remove(cartItem);
            }

            _context.SaveChanges();
            return cart;
        }


        public ShoppingCart RemoveFromCart(string cookieValue, int cartItemId, int? CurrentUserId)
        {
            var cart = _context.ShoppingCarts
                .Include(c => c.CartItems)
                .FirstOrDefault(c => c.CookieValue == cookieValue);

            if (cart == null) return null;

            var item = cart.CartItems.FirstOrDefault(ci => ci.Cart_Item_ID == cartItemId);
            if (item != null)
            {
                cart.CartItems.Remove(item);
                _context.CartItems.Remove(item);
                _context.SaveChanges();
            }

            return cart;
        }

        public int PlaceOrder(string cookieValue, int userId)
        {
            var cart = _context.ShoppingCarts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.CookieValue == cookieValue);

            if (cart == null || !cart.CartItems.Any())
                return 0;

            var order = new Order
            {
                User_ID = userId,
                CreationTime = DateTime.Now,
                ShippingGoal = "Pending", 
                DeliveryDate = DateTime.Now.AddDays(3), 
                Status = "Processing",
                TotalAmount = cart.Total_Price,
                OrderDetails = cart.CartItems.Select(ci => new OrderDetails
                {
                    Product_ID = ci.Product_ID,
                    Quantity = ci.Quantity,
                    Price = ci.Price
                }).ToList()
            };

            _context.Orders.Add(order);

            _context.CartItems.RemoveRange(cart.CartItems);
            _context.ShoppingCarts.Remove(cart);

            _context.SaveChanges();
            return order.Order_ID;
        }


    }

}
