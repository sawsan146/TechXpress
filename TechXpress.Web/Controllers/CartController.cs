using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TechXpress.DAL.Entities;
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
                Name = "tablet",
                Image = "25e0a5d6-5154-45ce-a9ca-161096acc032.jpeg",

                Price = 400f,
                ReviewCount = 50,
                Rating=1
            },
            new ProductViewModel
            {

                    Id = 2,
                Name = "pc device",
                Image = "71Hk-ZbQAuL.__AC_SY300_SX300_QL70_ML2_.jpg",

                Price =300f,
                ReviewCount = 30,
                Rating = 1
            },
            new ProductViewModel
            {

                    Id = 3,

                Name = "smart watch",
                Image = "613Ay8pU9zL.__AC_SX300_SY300_QL70_ML2_.jpg",

                Price = 540f,
                ReviewCount = 20,
                Rating = 3
            },
            new ProductViewModel
            {

                    Id = 4,

                Name = "canon camera",
                Image = "81RLTx5tIUL._AC_SL1500_.jpg",

                Price = 900,
                ReviewCount = 15,
                Rating = 5
            },
            new ProductViewModel
            {

                    Id = 5,
                Name = "headphone",
                Image = "da6eac57-b91b-45aa-81f8-6185d4f60a6c.jpeg",

                Price = 200f,
                ReviewCount = 29,
                Rating = 2
            },
            new ProductViewModel
            {

                    Id = 6,
                Name = "playstation",
                Image = "controller-6032446_640.jpg",

                Price = 340f,
                ReviewCount = 48,
                Rating = 4
            },
            new ProductViewModel
            {

                    Id = 7,
                Name = "samsung tablet",
                Image = "5a666c35-7feb-4ac6-8e84-868d875094cd.jpeg",
                Price = 670f,
                ReviewCount = 90,
                Rating = 5
            },
            new ProductViewModel
            {
                Id = 8,
                Name = "mouse",
                Image = "ff07d5fd-2b23-4a90-890e-e2620eca3b21.jpeg",

                Price = 100,
                ReviewCount = 50,
                Rating=1
            }
            ,
            new ProductViewModel
            {
                Id = 9,
                Name = "lcd tv",
                Image = "71VufAVwfIL.__AC_SY300_SX300_QL70_ML2_.jpg",

                Price = 1200.00f,
                ReviewCount = 50,
                Rating=1
            }
             ,
            new ProductViewModel
            {
                Id = 10,
                Name = "dell labtop",
                Image = "5fdcc66d-9d3a-40d8-b578-79570055618d.png",

                Price = 800.00f,
                ReviewCount = 50,
                Rating=1
            }
                         ,
            new ProductViewModel
            {
                Id = 11,
                Name = "printer",
                Image = "51IIRfll9hL.__AC_SY300_SX300_QL70_ML2_.jpg",

                Price = 250.00f,
                ReviewCount =50 ,
                Rating=1
            }
                                     ,
            new ProductViewModel
            {
                Id = 12,
                Name = "LED screen",
                Image = "61Bo1IYATOL.__AC_SY300_SX300_QL70_ML2_.jpg",

                Price = 150.00f,
                ReviewCount = 43,
                Rating=1
            }
                                      ,
            new ProductViewModel
            {
                Id = 13,
                Name = "speakers",
                Image = "51-LfrxrhsL.__AC_SY300_SX300_QL70_ML2_.jpg",

                Price = 180.00f,
                ReviewCount = 43,
                Rating=1
            }
                                         ,
            new ProductViewModel
            {
                Id = 14,
                Name = "redmi phone",
                Image = "61Ll0048EIL.__AC_SX300_SY300_QL70_ML2_.jpg",

                Price = 450.00f,
                ReviewCount = 43,
                Rating=1
            }
                                                     ,
            new ProductViewModel
            {
                Id = 15,
                Name = "pc device",
                Image = "61rBqHWhl1L.__AC_SX300_SY300_QL70_ML2_.jpg",

                Price = 320.00f,
                ReviewCount = 43,
                Rating=1
            }
                                                                 ,
            new ProductViewModel
            {
                Id = 16,
                Name = "samrt watch",
                Image = "61pa+yejx3L._AC_SX569_.jpg",

                Price = 600.00f,
                ReviewCount = 43,
                Rating=1
            }

        };

            cartItems = new List<CartitemsViewModel>();
        }


        [HttpGet]
        public IActionResult Index()
        {
            var cartItemsJson = Request.Cookies["CartItems"];
            var cartItems = string.IsNullOrEmpty(cartItemsJson)
                ? new List<CartitemsViewModel>()
                : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);

            var viewModel = new ShoppingCartViewModel
            {
                ShoppingCartList = cartItems,
                OrderTotal = cartItems.Sum(i => i.Quantity * i.Product.Price)
            };

            return View(viewModel);
        }
        [HttpPost]
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
                            Cart_Item_ID = cartItems.Count+1,
                            Product = product,
                            Quantity = 1,
                            Price = product.Price,
                            
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
            var cartItemsJson = Request.Cookies["CartItems"];
            var cartItems = string.IsNullOrEmpty(cartItemsJson)
                ? new List<CartitemsViewModel>()
                : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);
            var item = cartItems.Find(c => c.Cart_Item_ID == cartId);

            if (item is not null)
            {
                cartItems.Remove(item);
                var updatedCartItemsJson = JsonConvert.SerializeObject(cartItems);
                Response.Cookies.Append("CartItems", updatedCartItemsJson, new CookieOptions { HttpOnly = true });
            }

            return RedirectToAction(nameof(Index));
        }

 
        [HttpPost]
        public IActionResult Minus(int cartId)
        {
            var cartItemsJson = Request.Cookies["CartItems"];
            var cartItems = string.IsNullOrEmpty(cartItemsJson)
                ? new List<CartitemsViewModel>()
                : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);

            var item = cartItems.Find(c => c.Cart_Item_ID == cartId);

            if (item is not null && item.Quantity > 1)
            {
                item.Quantity -= 1;

                var updatedCartItemsJson = JsonConvert.SerializeObject(cartItems);
                Response.Cookies.Append("CartItems", updatedCartItemsJson, new CookieOptions { HttpOnly = true });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Plus(int cartId)
        {
            var cartItemsJson = Request.Cookies["CartItems"];
            var cartItems = string.IsNullOrEmpty(cartItemsJson)
                ? new List<CartitemsViewModel>()
                : JsonConvert.DeserializeObject<List<CartitemsViewModel>>(cartItemsJson);

            var item = cartItems.Find(c => c.Cart_Item_ID == cartId);

            if (item is not null)
            {
                item.Quantity += 1;

                var updatedCartItemsJson = JsonConvert.SerializeObject(cartItems);
                Response.Cookies.Append("CartItems", updatedCartItemsJson, new CookieOptions { HttpOnly = true });
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
