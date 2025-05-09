using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechXpress.DAL.Entities;
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Controllers
{
    public class ProductController : Controller
    {
        List<Product> products;

        public ProductController()
        {
            products = new List<Product>
            {
                new Product
                {
                    Product_ID = 1,
                    Category_ID = 1,
                    Name = "Tablet",
                    Price = 400.00f,
                    Stock = 50,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 1, Name = "Phones" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 1, Product_ID = 1, ImageURL = "~/images/product/25e0a5d6-5154-45ce-a9ca-161096acc032.jpeg" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 4 }
                    }
                },
                new Product
                {
                    Product_ID = 2,
                    Category_ID = 2,
                    Name = "pc device",
                    Price = 300.00f,
                    Stock = 30,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 2, Name = "Computers" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 2, Product_ID = 2, ImageURL = "~/images/product/71Hk-ZbQAuL.__AC_SY300_SX300_QL70_ML2_.jpg" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 3 }
                    }
                },
                new Product
                {
                    Product_ID = 3,
                    Category_ID = 3,
                    Name = "smart watch",
                    Price = 540.00f,
                    Stock = 20,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 3, Name = "Smart Watches" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 3, Product_ID = 3, ImageURL = "~/images/product/613Ay8pU9zL.__AC_SX300_SY300_QL70_ML2_.jpg" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 3 }
                    }
                },
                new Product
                {
                    Product_ID = 4,
                    Category_ID = 4,
                    Name = "canon camera",
                    Price = 900.00f,
                    Stock = 15,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 4, Name = "Cameras" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 4, Product_ID = 4, ImageURL = "~/images/product/81RLTx5tIUL._AC_SL1500_.jpg" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 4 }
                    }
                },
                new Product
                {
                    Product_ID = 5,
                    Category_ID = 5,
                    Name = "headphone",
                    Price = 200.00f,
                    Stock = 40,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 5, Name = "Head Phones" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 5, Product_ID = 5, ImageURL = "~/images/product/da6eac57-b91b-45aa-81f8-6185d4f60a6c.jpeg" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 3 }
                    }
                },
                new Product
                {
                    Product_ID = 6,
                    Category_ID = 6,
                    Name = "playstation",
                    Price = 340.00f,
                    Stock = 25,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 6, Name = "Games" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 6, Product_ID = 6, ImageURL = "~/images/product/controller-6032446_640.jpg" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 4 }
                    }
                },
                new Product
                {
                    Product_ID = 7,
                    Category_ID = 7,
                    Name = "samsung tablet",
                    Price = 670.00f,
                    Stock = 60,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 7, Name = "Tablet" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 7, Product_ID = 7, ImageURL = "~/images/product/5a666c35-7feb-4ac6-8e84-868d875094cd.jpeg" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 4 }
                    }
                },
                new Product
                {
                    Product_ID = 8,
                    Category_ID = 8,
                    Name = "mouse",
                    Price = 100.00f,
                    Stock = 150,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 8, Name = "Accessories" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 8, Product_ID = 8, ImageURL = "~/images/product/ff07d5fd-2b23-4a90-890e-e2620eca3b21.jpeg" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 3 }
                    }
                },
                new Product
                {
                    Product_ID = 9,
                    Category_ID = 9,
                    Name = "lcd tv",
                    Price = 1200.00f,
                    Stock = 10,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 9, Name = "TV" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 9, Product_ID = 9, ImageURL = "~/images/product/71VufAVwfIL.__AC_SY300_SX300_QL70_ML2_.jpg" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 4 }
                    }
                },
                new Product
                {
                    Product_ID = 10,
                    Category_ID = 10,
                    Name = "dell labtop",
                    Price = 800.00f,
                    Stock = 35,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 10, Name = "Laptops" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 10, Product_ID = 10, ImageURL = "~/images/product/5fdcc66d-9d3a-40d8-b578-79570055618d.png" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 4 }
                    }
                },
                new Product
                {
                    Product_ID = 11,
                    Category_ID = 11,
                    Name = "printer",
                    Price = 250.00f,
                    Stock = 50,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 11, Name = "Printers" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 11, Product_ID = 11, ImageURL = "~/images/product/51IIRfll9hL.__AC_SY300_SX300_QL70_ML2_.jpg" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 3 }
                    }
                },
                new Product
                {
                    Product_ID = 12,
                    Category_ID = 12,
                    Name = "LED screen",
                    Price = 150.00f,
                    Stock = 80,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 12, Name = "Monitors" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 12, Product_ID = 12, ImageURL = "~/images/product/61Bo1IYATOL.__AC_SY300_SX300_QL70_ML2_.jpg" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 4 }
                    }
                },
                new Product
                {
                    Product_ID = 13,
                    Category_ID = 13,
                    Name = "speakeres",
                    Price = 180.00f,
                    Stock = 70,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 13, Name = "Speakers" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 13, Product_ID = 13, ImageURL = "~/images/product/51-LfrxrhsL.__AC_SY300_SX300_QL70_ML2_.jpg" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 4 }
                    }
                },
                new Product
                {
                    Product_ID = 14,
                    Category_ID = 1,
                    Name = "redmi phone",
                    Price = 450.00f,
                    Stock = 45,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 1, Name = "Phones" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 14, Product_ID = 14, ImageURL = "~/images/product/61Ll0048EIL.__AC_SX300_SY300_QL70_ML2_.jpg" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 4 }
                    }
                },
                new Product
                {
                    Product_ID = 15,
                    Category_ID = 2,
                    Name = "pc device",
                    Price = 320.00f,
                    Stock = 28,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 2, Name = "Computers" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 15, Product_ID = 15, ImageURL = "~/images/product/61rBqHWhl1L.__AC_SX300_SY300_QL70_ML2_.jpg" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 3 }
                    }
                },
                new Product
                {
                    Product_ID = 16,
                    Category_ID = 3,
                    Name = "smart watch",
                    Price = 600.00f,
                    Stock = 18,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 3, Name = "Smart Watches" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 16, Product_ID = 16, ImageURL = "~/images/product/61pa+yejx3L._AC_SX569_.jpg" }
                    },
                    Reviews = new List<Review>
                    {
                        new Review { Rating = 4 }
                    }
                }
            };

        }

        public IActionResult Index(string category = "All Products")
        {


            ViewBag.Category = category;
            ViewBag.Categories = new List<string>
            {
                "All Products",
                "Phones",
                "Computers",
                "Smart Watches",
                "Cameras",
                "Head Phones",
                "Games",
                "Tablet",
                "Accessories",
                "TV",
                "Laptops",
                "Printers",
                "Monitors",
                "Speakers"
            };
            return View("AllProduct", products);
        }

        public IActionResult HomeProductSection()
        {
            return View("HomeProductSection", products);
        }

        public IActionResult ProductDashBoard()
        {
            ViewData["ActivePage"] = "Product";

            return View("ProductDashBoard", products);
        }
        public IActionResult ProductDetails(int id)
        {
            var product = products.FirstOrDefault(p => p.Product_ID == id);

            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct()
        {
            var userName = Request.Cookies["UserName"] ?? "Guest";
            ViewBag.UserName = userName;

            ProductDashBoardViewModel vm = new ProductDashBoardViewModel
            {
                Categories = GetCategories()
            };

            return View("AddProductDashBoard", vm);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductDashBoardViewModel vm)
        {
            ModelState.Remove("Categories");


            if (ModelState.IsValid)
            {

                TempData["SuccessMessage"] = "Product added successfully!";
                return RedirectToAction("ProductDashBoard");
            }

            vm.Categories = GetCategories();
            return View("AddProductDashBoard", vm);
        }     


        private List<SelectListItem> GetCategories()
        {
            List<CategoryViewModel> _Category = new List<CategoryViewModel>
             {
                 new CategoryViewModel{ Id = "1", Name = "Phones" },
                 new CategoryViewModel{ Id = "2", Name = "Computers" },
                 new CategoryViewModel{ Id = "3", Name = "Smart Watches" },
                 new CategoryViewModel{ Id = "4", Name = "Cameras" },
                 new CategoryViewModel{ Id = "5", Name = "Head Phones" },
                 new CategoryViewModel{ Id = "6", Name = "Games" },
                 new CategoryViewModel{ Id = "7", Name = "Tablet" }
             };

            return _Category.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }

        //for Admin
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateProduct(int id)
        {

            ProductDashBoardViewModel vm = new ProductDashBoardViewModel();
            var product = products.FirstOrDefault(p => p.Product_ID == id);

            if (product != null)
            {
                vm.Name = product.Name;
                vm.Price = product.Price;
                vm.Stock = product.Stock;
                vm.Description = product.Description;
                vm.Category_ID = product.Category_ID.ToString();
                vm.Categories = GetCategories();
                vm.UploadedImages = new List<IFormFile>();
            }
            else
            {
                return NotFound();
            }
            return View(vm);

        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductDashBoardViewModel vm)
        {
            ModelState.Remove("Categories");
            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Product updated successfully!";
                return RedirectToAction("ProductDashBoard");
            }
            vm.Categories = GetCategories();
            return View(vm);
        }


        public IActionResult AccessDenied()
        {
            return View();
        }


        //     [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Product_ID == id);
            if (product != null)
            {
                products.Remove(product);
                TempData["SuccessMessage"] = "Product deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Product not found!";
            }
            return RedirectToAction("ProductDashBoard");
        }

    }
}
