using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.ApplicationServices.Implementation;
using TechXpress.BLL.Services.Contracts;
using TechXpress.BLL.Services.Implementations;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Infrastructure;
using TechXpress.Logic.Repository.Contracts;
using TechXpress.Logic.Repository.Implementations;
using TechXpress.Logic.UnitOfWork;
using TechXpress.Services.ApplicationServicesConfigrations;
using TechXpress.Web.Mapping;


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


            builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("SawsanConnection"))
            );



            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
           builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
           //builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddScoped<IProductAppService, ProductAppService>();
         
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
            builder.Services.AddAutoMapper(typeof(ApplicationMappingProfile));


            builder.Services.AddSession();
           
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)

                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => options.LoginPath = "/Register/Login");
           
            //builder.Services.Configure<FormOptions>(options =>
            //{
            //    options.MultipartBodyLengthLimit = 400000000; // 100 MB
            //});

            //builder.Services.AddApplicationDbContext(builder.Configuration.GetConnectionString("SawsanConnection")
            //    , builder.Configuration.GetConnectionString("Redis"));

            //builder.Services.AddIdentity<User, IdentityRole>()
            //          .AddEntityFrameworkStores<AppDbContext>()
            //          .AddDefaultTokenProviders();
            //builder.Services.AddApplicationServices(builder.Configuration);


            //builder.Services.AddCors(
            //  option => {
            //      option.AddPolicy("MyPolicy", options => {
            //          options.AllowAnyHeader().
            //           AllowAnyMethod()
            //         .AllowAnyOrigin();
            //      });
            //  });

 
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
