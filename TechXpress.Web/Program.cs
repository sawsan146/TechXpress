using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.ApplicationServices.Implementation;
using TechXpress.Application.ApplicationServices.Implementations;
using TechXpress.BLL.Services.Contracts;
using TechXpress.BLL.Services.Implementations;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Infrastructure;
using TechXpress.DAL.Repository.Contracts;
using TechXpress.DAL.Repository.Implementations;
using TechXpress.DAL.UnitOfWork;
using TechXpress.Services.ApplicationServicesConfigrations;
using TechXpress.Web.Mapping;

namespace TechXpress.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews();

            // Configure session
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Register DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
       options.UseSqlServer(
     
           builder.Configuration.GetConnectionString("SawsanConnection"),
           sqlOptions => sqlOptions.MigrationsAssembly("TechXpress.DAL") ));

       

            // Register generic repository
            builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            // Register UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register services and app services
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductAppService, ProductAppService>();
            builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IWishListAppService, WishListAppService>();
            builder.Services.AddScoped<IProductImageService, ProductImageService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<ICartAppService, CartAppService>();



            // Register AutoMapper profiles
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
            builder.Services.AddAutoMapper(typeof(ApplicationMappingProfile));

            // Configure authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/Register/Login";
                });


            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}