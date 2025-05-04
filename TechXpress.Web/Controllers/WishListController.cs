//using Microsoft.AspNetCore.Mvc;
//using TechXpress.Web.ViewModel;
//using TechXpress.Domain.Entities;
//using Microsoft.AspNetCore.Http;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text.Json;
//using Newtonsoft.Json;
//namespace TechXpress.Web.Controllers
//{
//    public class WishListController : Controller
//    {    
//        List<ProductViewModel> ProductVm;
//        List<WishListItemsViewModel> WishListItems;
//        public WishListController()
//        {

//            ProductVm = new List<ProductViewModel> {

//            new ProductViewModel
//            {
//                Id = 1,
//                Name = "tablet",
//                Image = "25e0a5d6-5154-45ce-a9ca-161096acc032.jpeg",

//                Price = 400f,
//                ReviewCount = 50,
//                Rating=1
//            },
//            new ProductViewModel
//            {

//                    Id = 2,
//                Name = "pc device",
//                Image = "71Hk-ZbQAuL.__AC_SY300_SX300_QL70_ML2_.jpg",

//                Price =300f,
//                ReviewCount = 30,
//                Rating = 1
//            },
//            new ProductViewModel
//            {

//                    Id = 3,

//                Name = "smart watch",
//                Image = "613Ay8pU9zL.__AC_SX300_SY300_QL70_ML2_.jpg",

//                Price = 540f,
//                ReviewCount = 20,
//                Rating = 3
//            },
//            new ProductViewModel
//            {

//                    Id = 4,

//                Name = "canon camera",
//                Image = "81RLTx5tIUL._AC_SL1500_.jpg",

//                Price = 900,
//                ReviewCount = 15,
//                Rating = 5
//            },
//            new ProductViewModel
//            {

//                    Id = 5,
//                Name = "headphone",
//                Image = "da6eac57-b91b-45aa-81f8-6185d4f60a6c.jpeg",

//                Price = 200f,
//                ReviewCount = 29,
//                Rating = 2
//            },
//            new ProductViewModel
//            {

//                    Id = 6,
//                Name = "playstation",
//                Image = "controller-6032446_640.jpg",

//                Price = 340f,
//                ReviewCount = 48,
//                Rating = 4
//            },
//            new ProductViewModel
//            {

//                    Id = 7,
//                Name = "samsung tablet",
//                Image = "5a666c35-7feb-4ac6-8e84-868d875094cd.jpeg",
//                Price = 670f,
//                ReviewCount = 90,
//                Rating = 5
//            },
//            new ProductViewModel
//            {
//                Id = 8,
//                Name = "mouse",
//                Image = "ff07d5fd-2b23-4a90-890e-e2620eca3b21.jpeg",

//                Price = 100,
//                ReviewCount = 50,
//                Rating=1
//            }
//            ,
//            new ProductViewModel
//            {
//                Id = 9,
//                Name = "lcd tv",
//                Image = "71VufAVwfIL.__AC_SY300_SX300_QL70_ML2_.jpg",

//                Price = 1200.00f,
//                ReviewCount = 50,
//                Rating=1
//            }
//             ,
//            new ProductViewModel
//            {
//                Id = 10,
//                Name = "dell labtop",
//                Image = "5fdcc66d-9d3a-40d8-b578-79570055618d.png",

//                Price = 800.00f,
//                ReviewCount = 50,
//                Rating=1
//            }
//                         ,
//            new ProductViewModel
//            {
//                Id = 11,
//                Name = "printer",
//                Image = "51IIRfll9hL.__AC_SY300_SX300_QL70_ML2_.jpg",

//                Price = 250.00f,
//                ReviewCount =50 ,
//                Rating=1
//            }
//                                     ,
//            new ProductViewModel
//            {
//                Id = 12,
//                Name = "LED screen",
//                Image = "61Bo1IYATOL.__AC_SY300_SX300_QL70_ML2_.jpg",

//                Price = 150.00f,
//                ReviewCount = 43,
//                Rating=1
//            }
//                                      ,
//            new ProductViewModel
//            {
//                Id = 13,
//                Name = "speakers",
//                Image = "51-LfrxrhsL.__AC_SY300_SX300_QL70_ML2_.jpg",

//                Price = 180.00f,
//                ReviewCount = 43,
//                Rating=1
//            }
//                                         ,
//            new ProductViewModel
//            {
//                Id = 14,
//                Name = "redmi phone",
//                Image = "61Ll0048EIL.__AC_SX300_SY300_QL70_ML2_.jpg",

//                Price = 450.00f,
//                ReviewCount = 43,
//                Rating=1
//            }
//                                                     ,
//            new ProductViewModel
//            {
//                Id = 15,
//                Name = "pc device",
//                Image = "61rBqHWhl1L.__AC_SX300_SY300_QL70_ML2_.jpg",

//                Price = 320.00f,
//                ReviewCount = 43,
//                Rating=1
//            }
//                                                                 ,
//            new ProductViewModel
//            {
//                Id = 16,
//                Name = "samrt watch",
//                Image = "61pa+yejx3L._AC_SX569_.jpg",

//                Price = 600.00f,
//                ReviewCount = 43,
//                Rating=1
//            }

//        };

//            WishListItems = new List<WishListItemsViewModel>();
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            var wishlistItemsJson = Request.Cookies["WishlistItems"];
//            var wishlistItems = string.IsNullOrEmpty(wishlistItemsJson)
//                ? new List<WishListItemsViewModel>()
//                : JsonConvert.DeserializeObject<List<WishListItemsViewModel>>(wishlistItemsJson);

//            var viewModel = new WishlistViewModel
//            {
//                WishlistItems = wishlistItems
//            };

//            return View(viewModel);
//        }

//        [HttpPost]
//        public IActionResult Index(int productId)
//        {
//            if (!User.Identity.IsAuthenticated)
//            {
//                return RedirectToAction("Login", "Register");
//            }
//            else
//            {
//                var product = ProductVm.FirstOrDefault(p => p.Id == productId);

//                if (product != null)
//                {
//                    var wishlistItemsJson = Request.Cookies["WishlistItems"];
//                    var wishlistItems = string.IsNullOrEmpty(wishlistItemsJson)
//                        ? new List<WishListItemsViewModel>() // Use your WishListItemsViewModel
//                        : JsonConvert.DeserializeObject<List<WishListItemsViewModel>>(wishlistItemsJson); // Or JsonConvert.DeserializeObject

//                    var WishlistItem = wishlistItems.FirstOrDefault(w => w.Product.Id == productId);

//                    if (WishlistItem != null)
//                    {
//                        wishlistItems.Add(new WishListItemsViewModel // Create a new WishListItemsViewModel
//                        {

//                           WishList_Item_ID = wishlistItems.Count + 1,
//                           Price=product.Price,
//                            Product = product
//                            // You might add other properties like AddedDate
//                        });

//                        var updatedWishlistItemsJson = JsonConvert.SerializeObject(wishlistItems); // Or JsonConvert.SerializeObject
//                        Response.Cookies.Append("WishlistItems", updatedWishlistItemsJson, new CookieOptions { HttpOnly = true });

//                        // Optionally, you can redirect to a "Wishlist" page
//                        return RedirectToAction(nameof(Index)); // Or your wishlist display action
//                    }
//                    else
//                    {

//                        //TempData["WishlistMessage"] = "Product already in wishlist.";
//                        return RedirectToAction(nameof(Index)); 
//                    }
//                }
//                else
//                {
//                    return NotFound();
//                }
//            }
//        }

//        // Action to display the wishlist (GET request)

//    }
//}



using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Controllers
{
    public class WishlistController : Controller
    {
        // Use the same ProductViewModel
        private readonly List<ProductViewModel> ProductVm = new List<ProductViewModel>
        {
            new ProductViewModel { Id = 1, Name = "Tablet", Image = "25e0a5d6-5154-45ce-a9ca-161096acc032.jpeg", Price = 400f, ReviewCount = 50, Rating = 1 },
            new ProductViewModel { Id = 2, Name = "PC Device", Image = "71Hk-ZbQAuL.__AC_SY300_SX300_QL70_ML2_.jpg", Price = 300f, ReviewCount = 30, Rating = 1 },
            new ProductViewModel { Id = 3, Name = "Smart Watch", Image = "613Ay8pU9zL.__AC_SX300_SY300_QL70_ML2_.jpg", Price = 540f, ReviewCount = 20, Rating = 3 },
            new ProductViewModel { Id = 4, Name = "Canon Camera", Image = "81RLTx5tIUL._AC_SL1500_.jpg", Price = 900, ReviewCount = 15, Rating = 5 },
            new ProductViewModel { Id = 5, Name = "Headphone", Image = "da6eac57-b91b-45aa-81f8-6185d4f60a6c.jpeg", Price = 200f, ReviewCount = 29, Rating = 2 },
            new ProductViewModel { Id = 6, Name = "Playstation", Image = "controller-6032446_640.jpg", Price = 340f, ReviewCount = 48, Rating = 4 },
            new ProductViewModel { Id = 7, Name = "Samsung Tablet", Image = "5a666c35-7feb-4ac6-8e84-868d875094cd.jpeg", Price = 670f, ReviewCount = 90, Rating = 5 },
            new ProductViewModel { Id = 8, Name = "Mouse", Image = "ff07d5fd-2b23-4a90-890e-e2620eca3b21.jpeg", Price = 100, ReviewCount = 50, Rating = 1 },
            new ProductViewModel { Id = 9, Name = "LCD TV", Image = "71VufAVwfIL.__AC_SY300_SX300_QL70_ML2_.jpg", Price = 1200.00f, ReviewCount = 50, Rating = 1 },
            new ProductViewModel { Id = 10, Name = "Dell Laptop", Image = "5fdcc66d-9d3a-40d8-b578-79570055618d.png", Price = 800.00f, ReviewCount = 50, Rating = 1 },
            new ProductViewModel { Id = 11, Name = "Printer", Image = "51IIRfll9hL.__AC_SY300_SX300_QL70_ML2_.jpg", Price = 250.00f, ReviewCount = 50, Rating = 1 },
            new ProductViewModel { Id = 12, Name = "LED Screen", Image = "61Bo1IYATOL.__AC_SY300_SX300_QL70_ML2_.jpg", Price = 150.00f, ReviewCount = 43, Rating = 1 },
            new ProductViewModel { Id = 13, Name = "Speakers", Image = "51-LfrxrhsL.__AC_SY300_SX300_QL70_ML2_.jpg", Price = 180.00f, ReviewCount = 43, Rating = 1 },
            new ProductViewModel { Id = 14, Name = "Redmi Phone", Image = "61Ll0048EIL.__AC_SX300_SY300_QL70_ML2_.jpg", Price = 450.00f, ReviewCount = 43, Rating = 1 },
            new ProductViewModel { Id = 15, Name = "PC Device", Image = "61rBqHWhl1L.__AC_SX300_SY300_QL70_ML2_.jpg", Price = 320.00f, ReviewCount = 43, Rating = 1 },
            new ProductViewModel { Id = 16, Name = "Smart Watch", Image = "61pa+yejx3L._AC_SX569_.jpg", Price = 600.00f, ReviewCount = 43, Rating = 1 }
        };

        public WishlistController()
        {
            // No need to initialize ProductVm here, it's already done above
        }

        [HttpGet]
        public IActionResult Index()
        {
            var wishlistItemsJson = Request.Cookies["WishlistItems"];
            var wishlistItems = string.IsNullOrEmpty(wishlistItemsJson)
                ? new List<WishListItemsViewModel>()
                : JsonConvert.DeserializeObject<List<WishListItemsViewModel>>(wishlistItemsJson);

            var viewModel = new WishlistViewModel
            {
                WishlistItems = wishlistItems
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddToWishList(int productId) // Corrected method name
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Register");
            }

            var product = ProductVm.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return NotFound(); // Product not found
            }

            var wishlistItemsJson = Request.Cookies["WishlistItems"];
            var wishlistItems = string.IsNullOrEmpty(wishlistItemsJson)
                ? new List<WishListItemsViewModel>()
                : JsonConvert.DeserializeObject<List<WishListItemsViewModel>>(wishlistItemsJson);

            // Check if the product is already in the wishlist
            if (!wishlistItems.Any(item => item.Product.Id == productId))
            {
                wishlistItems.Add(new WishListItemsViewModel
                {
                    WishList_Item_ID = wishlistItems.Count + 1, // Correct ID assignment
                    Price = product.Price,
                    Product = product
                });

                var updatedWishlistItemsJson = JsonConvert.SerializeObject(wishlistItems);
                Response.Cookies.Append("WishlistItems", updatedWishlistItemsJson, new CookieOptions { HttpOnly = true });
            }
            //No Redirection
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult RemoveFromWishlist(int productId)
        {
            var wishlistItemsJson = Request.Cookies["WishlistItems"];
            if (!string.IsNullOrEmpty(wishlistItemsJson))
            {
                var wishlistItems = JsonConvert.DeserializeObject<List<WishListItemsViewModel>>(wishlistItemsJson);
                var itemToRemove = wishlistItems.FirstOrDefault(item => item.Product.Id == productId);

                if (itemToRemove != null)
                {
                    wishlistItems.Remove(itemToRemove);
                    var updatedWishlistJson = JsonConvert.SerializeObject(wishlistItems);
                    Response.Cookies.Append("WishlistItems", updatedWishlistJson, new CookieOptions { HttpOnly = true });
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
