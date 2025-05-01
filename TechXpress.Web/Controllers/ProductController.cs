using Microsoft.AspNetCore.Mvc;
using TechXpress.Domain.Entities;
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
                    Name = "Product 1",
                    Description = "High-quality product with advanced features.",
                    Price = 400.00f,
                    Stock = 50,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 1, Name = "Phones" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 1, Product_ID = 1, ImageURL = "~/images/Products/Laptop.jpg" }
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
                    Name = "Product 2",
                    Description = "Reliable product for everyday use.",
                    Price = 300.00f,
                    Stock = 30,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 2, Name = "Computers" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 2, Product_ID = 2, ImageURL = "~/images/Products/Laptop.jpg" }
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
                    Name = "Product 1",
                    Description = "High-quality product with advanced features.",
                    Price = 540.00f,
                    Stock = 20,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 3, Name = "Smart Watches" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 3, Product_ID = 3, ImageURL = "~/images/Products/Laptop.jpg" }
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
                    Name = "Product 1",
                    Description = "High-quality product with advanced features.",
                    Price = 900.00f,
                    Stock = 15,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 4, Name = "Cameras" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 4, Product_ID = 4, ImageURL = "~/images/Products/Laptop.jpg" }
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
                    Name = "Product 1",
                    Description = "High-quality product with advanced features.",
                    Price = 200.00f,
                    Stock = 40,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 5, Name = "Head Phones" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 5, Product_ID = 5, ImageURL = "~/images/Products/Laptop.jpg" }
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
                    Name = "Product 1",
                    Description = "High-quality product with advanced features.",
                    Price = 340.00f,
                    Stock = 25,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 6, Name = "Games" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 6, Product_ID = 6, ImageURL = "~/images/Products/Laptop.jpg" }
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
                    Name = "Product 1",
                    Description = "High-quality product with advanced features.",
                    Price = 670.00f,
                    Stock = 60,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 7, Name = "Tablet" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 7, Product_ID = 7, ImageURL = "~/images/Products/Laptop.jpg" }
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
                    Name = "Product 1",
                    Description = "High-quality product with advanced features.",
                    Price = 100.00f,
                    Stock = 150,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 8, Name = "Accessories" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 8, Product_ID = 8, ImageURL = "~/images/Products/Laptop.jpg" }
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
                    Name = "Product 1",
                    Description = "High-quality product with advanced features.",
                    Price = 1200.00f,
                    Stock = 10,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 9, Name = "TV" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 9, Product_ID = 9, ImageURL = "~/images/Products/Laptop.jpg" }
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
                    Name = "Product 2",
                    Description = "Reliable product for everyday use.",
                    Price = 800.00f,
                    Stock = 35,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 10, Name = "Laptops" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 10, Product_ID = 10, ImageURL = "~/images/Products/Laptop.jpg" }
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
                    Name = "Product 1",
                    Description = "High-quality product with advanced features.",
                    Price = 250.00f,
                    Stock = 50,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 11, Name = "Printers" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 11, Product_ID = 11, ImageURL = "~/images/Products/Laptop.jpg" }
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
                    Name = "Product 1",
                    Description = "High-quality product with advanced features.",
                    Price = 150.00f,
                    Stock = 80,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 12, Name = "Monitors" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 12, Product_ID = 12, ImageURL = "~/images/Products/Laptop.jpg" }
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
                    Name = "Product 1",
                    Description = "High-quality product with advanced features.",
                    Price = 180.00f,
                    Stock = 70,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 13, Name = "Speakers" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 13, Product_ID = 13, ImageURL = "~/images/Products/Laptop.jpg" }
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
                    Name = "Product 1",
                    Description = "High-quality product with advanced features.",
                    Price = 450.00f,
                    Stock = 45,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 1, Name = "Phones" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 14, Product_ID = 14, ImageURL = "~/images/Products/Laptop.jpg" }
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
                    Name = "Product 2",
                    Description = "Reliable product for everyday use.",
                    Price = 320.00f,
                    Stock = 28,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 2, Name = "Computers" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 15, Product_ID = 15, ImageURL = "~/images/Products/Laptop.jpg" }
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
                    Name = "Product 1",
                    Description = "High-quality product with advanced features.",
                    Price = 600.00f,
                    Stock = 18,
                    AddTime = DateTime.Now,
                    Category = new Category { Category_ID = 3, Name = "Smart Watches" },
                    ProductImages = new List<ProductImg>
                    {
                        new ProductImg { Image_ID = 16, Product_ID = 16, ImageURL = "~/images/Products/Laptop.jpg" }
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
            return View("HomeProductSection");
        }

        public IActionResult ProductDetails()
        {
            return View("ProductDetails");
        }

        public IActionResult ProductDashBoard()
        {
            return View("ProductDashBoard",products);
        }

    }
}