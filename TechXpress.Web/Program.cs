using FluentAssertions.Common;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Infrastructure;
using TechXpress.Services.ApplicationServicesConfigrations;
//using TechXpress.Domain.Infrastructure;
//using TechXpress.Logic.Repository.Contracts;
//using TechXpress.Logic.Repository.Implementations;
//using TechXpress.BLL.UnitOfWork;

namespace TechXpress.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDistributedMemoryCache(); // استخدام الذاكرة لتخزين الجلسة
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            //builder.Services.AddDbContext<AppDbContext>(options =>
            //  options.UseSqlServer(builder.Configuration.GetConnectionString("SawsanConnection"))
            //);

            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 400000000; // 100 MB
            });
            builder.Services.AddApplicationDbContext(builder.Configuration.GetConnectionString("DefaultConnection")
                , builder.Configuration.GetConnectionString("Redis"));

            builder.Services.AddIdentity<User, IdentityRole>()
                      .AddEntityFrameworkStores<AppDbContext>()
                      .AddDefaultTokenProviders();
            builder.Services.AddApplicationServices(builder.Configuration);

            builder.Services.AddCors(
              option => {
                  option.AddPolicy("MyPolicy", options => {
                      options.AllowAnyHeader().
                       AllowAnyMethod()
                     .AllowAnyOrigin();
                  });
              });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
