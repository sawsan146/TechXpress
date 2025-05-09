using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TechXpress.DAL;
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


            //builder.Services.AddDbContext<AppDbContext>(options =>
            //  options.UseSqlServer(builder.Configuration.GetConnectionString("SawsanConnection"))
            //);

            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddSession();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>

                 options.LoginPath = "/Register/Login");
            


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
