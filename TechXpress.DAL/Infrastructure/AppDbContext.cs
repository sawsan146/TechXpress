using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Configurations;
using TechXpress.DAL.Entities;

namespace TechXpress.DAL.Infrastructure
{
    public class AppDbContext : IdentityDbContext<User, ApplicationRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImg> ProductImages { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<WishListItems> WishListItems { get; set; }

        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new ReturnConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingCartConfiguration());
            modelBuilder.ApplyConfiguration(new WishListConfiguration());
            modelBuilder.ApplyConfiguration(new WishListItemsConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImgConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemsConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new ContactMessageConfiguration());



        
    modelBuilder.Entity<Product>().HasData(
     new Product
     {
         Product_ID = 1,
         Category_ID = "1",
         Name = "HP Pavilion 15",
         Price = 15000f,
         Stock = 20,
         AddTime = DateTime.Now,
         Description = "Powerful laptop with Intel i7, 16GB RAM, and 512GB SSD.",
         Brand = "HP",
         Processor = "Intel Core i7",
         RAM = 16,
         Storage = "512GB SSD",
         GPU = "NVIDIA GTX 1650",
         ScreenSize = 15.6m,
         Resolution = "1920x1080",
         PercentageDiscount = 10,
         PriceAfterDiscount = 13500f
     },
     new Product
     {
         Product_ID = 2,
         Category_ID = "2",
         Name = "Dell Inspiron 14",
         Price = 12000f,
         Stock = 15,
         AddTime = DateTime.Now,
         Description = "Affordable performance laptop with 8GB RAM and 256GB SSD.",
         Brand = "Dell",
         Processor = "Intel Core i5",
         RAM = 8,
         Storage = "256GB SSD",
         GPU = "Intel Iris Xe",
         ScreenSize = 14.0m,
         Resolution = "1920x1080",
         PercentageDiscount = null,
         PriceAfterDiscount = null
     },
     new Product
     {
         Product_ID = 3,
         Category_ID = "3",
         Name = "Lenovo Legion 5",
         Price = 22000f,
         Stock = 10,
         AddTime = DateTime.Now,
         Description = "Gaming laptop with Ryzen 7, 16GB RAM, and RTX 3060.",
         Brand = "Lenovo",
         Processor = "AMD Ryzen 7",
         RAM = 16,
         Storage = "1TB SSD",
         GPU = "NVIDIA RTX 3060",
         ScreenSize = 15.6m,
         Resolution = "2560x1440",
         PercentageDiscount = 5,
         PriceAfterDiscount = 20900f
     }
 );
            modelBuilder.Entity<Category>().HasData(
                 new Category
                 {
                     Category_ID = "1",
                     Name = "Laptops",
                     Description = "All types of personal and gaming laptops."
                 },
                 new Category
                 {
                     Category_ID = "2",
                     Name = "Ultrabooks",
                     Description = "Lightweight, thin laptops with high performance."
                 },
                 new Category
                 {
                     Category_ID = "3",
                     Name = "Gaming",
                     Description = "High-end gaming laptops and accessories."
                 }
             );
            modelBuilder.Entity<ProductImg>().HasData(
                new ProductImg
                {
                    Image_ID = 1,
                    Product_ID = 1,
                    ImageURL = "HP1.jpeg"
                },
                new ProductImg
                {
                    Image_ID = 2,
                    Product_ID = 1,
                    ImageURL = "HP2.jpeg"
                },
                new ProductImg
                {
                    Image_ID = 7,
                    Product_ID = 1,
                    ImageURL = "HP3.jpeg"
                },
                new ProductImg
                {
                    Image_ID = 3,
                    Product_ID = 2,
                    ImageURL = "Dell1.jpeg"
                },
                new ProductImg
                {
                    Image_ID = 4,
                    Product_ID = 2,
                    ImageURL = "dell2.jpeg"
                },
                new ProductImg
                {
                    Image_ID = 8,
                    Product_ID =2 ,
                    ImageURL = "dell3.jpeg"
                },
                new ProductImg
                {
                    Image_ID = 5,
                    Product_ID = 3,
                    ImageURL = "Lenovo1.jpeg"
                },
                new ProductImg
                {
                    Image_ID = 6,
                    Product_ID = 3,
                    ImageURL = "Lenovo2.jpeg"
                },
                new ProductImg
                {
                    Image_ID = 9,
                    Product_ID = 3,
                    ImageURL = "Lenovo3.jpeg"
                }
            );

            base.OnModelCreating(modelBuilder);
        }



    }
}
    
    
  



