using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TechXpress.Domain.Entities;
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Controllers
{
    public class CartController : Controller
    {
        List<ProductViewModel> ProductVm;
        List<CartitemsViewModel> cartItems;
        public CartController()
        {
            ProductVm = new List<ProductViewModel> {

            new ProductViewModel
            {
                Id = 1,
                Name = "Product 1",
                Image = "Laptop.jpg",
                Price = 400f,
                ReviewCount = 5,
                Rating=1
            },
            new ProductViewModel
            {

                    Id = 2,
                Name = "Product 2",
                Image = "Laptop.jpg",
                Price =300f,
                ReviewCount = 5,
                Rating = 1
            },
            new ProductViewModel
            {

                    Id = 3,
                Name = "Product 1",
                Image = "Laptop.jpg",
                Price = 540f,
                ReviewCount = 23,
                Rating = 3
            },
            new ProductViewModel
            {

                    Id = 4,
                Name = "Product 1",
                Image = "Laptop.jpg",
                Price = 900,
                ReviewCount = 54,
                Rating = 5
            },
            new ProductViewModel
            {

                    Id = 5,
                Name = "Product 1",
                Image = "Laptop.jpg",
                Price = 200f,
                ReviewCount = 29,
                Rating = 2
            },
            new ProductViewModel
            {

                    Id = 6,
                Name = "Product 1",
                Image = "Laptop.jpg",
                Price = 340f,
                ReviewCount = 48,
                Rating = 4
            },
            new ProductViewModel
            {

                    Id = 7,
                Name = "Product 1",
                Image = "Laptop.jpg",
                Price = 670f,
                ReviewCount = 90,
                Rating = 5
            },
            new ProductViewModel
            {

                Id = 8,
                Name = "Product 1",
                Image = "Laptop.jpg",
                Price = 100,
                ReviewCount = 50,
                Rating=1
            }


            };
            cartItems = new List<CartitemsViewModel>
             {
                 new CartitemsViewModel
                  {
                    Cart_Item_ID = 1,
                    Quantity = 2,
                    Price = 100,
                    Product = ProductVm[0]
                 },
             new CartitemsViewModel
             {
                 Cart_Item_ID = 2,
                 Quantity = 1,
                 Price = 200,
                Product= new ProductViewModel
                 {
            
                         Id = 2,
                     Name = "Product 2",
                     Image = "Laptop.jpg",
                     Price =300f,
                     ReviewCount = 5,
                     Rating = 1
           },
        }
            };

        }
        public IActionResult Index(int product_id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Register");
            }
            else
            {
                var product = ProductVm.FirstOrDefault(p => p.Id == product_id);

                if (product != null)
                {
                    var cartItemsJson = Request.Cookies["CartItems"];
                    var cartItems = string.IsNullOrEmpty(cartItemsJson)
                        ? new List<CartitemsViewModel>()
                        : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);

                    var cartItem = cartItems.FirstOrDefault(c => c.Product.Id == product_id);

                    if (cartItem != null)
                    {
                        cartItem.Quantity += 1;
                    }
                    else
                    {
                        cartItems.Add(new CartitemsViewModel
                        {
                            Cart_Item_ID = cartItems.Count + 1,
                            Product = product,
                            Quantity = 1,
                            Price = product.Price
                        });
                    }

                    var updatedCartItemsJson = JsonConvert.SerializeObject(cartItems);
                    Response.Cookies.Append("CartItems", updatedCartItemsJson, new CookieOptions { HttpOnly = true });

                    var viewModel = new ShoppingCartViewModel
                    {
                        ShoppingCartList = cartItems,
                        OrderTotal = cartItems.Sum(i => i.Quantity * i.Product.Price)
                    };

                    return View(viewModel);
                }
                else
                {
                    return NotFound();
                }
            }
        }


        [HttpPost]
        public IActionResult Remove(int cartId)
        {
           var item= cartItems.Find(c=>c.Cart_Item_ID==cartId);

            if (item is not null)
            {
                cartItems.Remove(item);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Minus(int cartId)
        {
            var item = cartItems.Find(c => c.Cart_Item_ID == cartId);

            if (item is not null && item.Quantity > 1)
            {
                item.Quantity -= 1;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Plus(int cartId)
        {
            var item = cartItems.Find(c => c.Cart_Item_ID == cartId);

            if (item is not null)
            {
                item.Quantity += 1;
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
