using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OlexShop.Core.ApplicationService.Config;
using OlexShop.Core.ApplicationService.Facade;
using OlexShop.Core.Contracts.Facade;
using OlexShop.Core.Contracts.Repository;
using OlexShop.Core.Domain.Entities;
using OlexShop.Infrastructure.Data;
using OlexShop.Infrastructure.EF;
using OlexShop.Models;
using OlexShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlexShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AdminAuthenticationProfile());
                mc.AddProfile(new AdsProfile());
                mc.AddProfile(new NewsCategoryProfile());
                mc.AddProfile(new NewsCommentProfile());
                mc.AddProfile(new NewsProfile());
                mc.AddProfile(new ProductsCategoryProfile());
                mc.AddProfile(new ProductsCommentProfile());
                mc.AddProfile(new ProductsImagesProfile());
                mc.AddProfile(new ProductsProfile());
                mc.AddProfile(new UserAuthenticationProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddDbContext<DemoContext>(option => option.UseSqlServer(Configuration.GetConnectionString("olexshop")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IViewerCountService, ViewerCountService>();
            services.AddScoped<IUserAuthenticationRepository, UserAuthenticationRepository>();
            services.AddScoped<IUserAuthenticationFacade, UserAuthenticationFacade>();
            services.AddScoped<IAdminAuthenticationRepository, AdminAuthenticationRepository>();
            services.AddScoped<IAdminAuthenticationFacade, AdminAuthenticationFacade>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsFacade, NewsFacade>();
            services.AddScoped<INewsCommentRepository, NewsCommentRepository>();
            services.AddScoped<INewsCommentFacade, NewsCommentFacade>();
            services.AddScoped<INewsCategoryRepository, NewsCategoryRepository>();
            services.AddScoped<INewsCategoryFacade, NewsCategoryFacade>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsFacade, ProductsFacade>();
            services.AddScoped<IProductsImageRepository, ProductsImageRepository>();
            services.AddScoped<IProductsImageFacade, ProductsImageFacade>();
            services.AddScoped<IProductsCommentRepository, ProductsCommentRepository>();
            services.AddScoped<IProductsCommentFacade, ProductsCommentFacade>();
            services.AddScoped<IProductsCategoryRepository, ProductsCategoryRepository>();
            services.AddScoped<IProductsCategoryFacade, ProductsCategoryFacade>();
            services.AddControllersWithViews();

            services.AddMemoryCache();
            services.AddSession();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "Admin",
                defaults: new { controller = "Admin", action = "Index" }
            );
                endpoints.MapAreaControllerRoute(
                name: "AddProduct",
                areaName: "Admin",
                pattern: "Admin/AddProduct",
                defaults: new { controller = "Admin", action = "AddProduct" }
            );
                endpoints.MapAreaControllerRoute(
                name: "ProductsInfo",
                areaName: "Admin",
                pattern: "Admin/ProductsInfo",
                defaults: new { controller = "Admin", action = "ProductsInfo" }
            );
                endpoints.MapAreaControllerRoute(
                name: "AddNews",
                areaName: "Admin",
                pattern: "Admin/AddNews",
                defaults: new { controller = "Admin", action = "AddNews" }
            );
                endpoints.MapAreaControllerRoute(
                name: "NewsInfo",
                areaName: "Admin",
                pattern: "Admin/NewsInfo",
                defaults: new { controller = "Admin", action = "NewsInfo" }
            );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "Login",
                    pattern: "login",
                    defaults: new { controller = "Account", action = "Login" }
                    );
                endpoints.MapControllerRoute(
                    name: "SignUp",
                    pattern: "SignUp",
                    defaults: new { controller = "Account", action = "SignUp" }
                    );
                endpoints.MapControllerRoute(
                    name: "ProductDetails",
                    pattern: "ProductDetails/{id?}",
                    defaults: new { controller = "Home", action = "ProductDetails" }
                    );
                endpoints.MapControllerRoute(
                    name: "FindByCategory",
                    pattern: "FindByCategory/{id?}",
                    defaults: new { controller = "Home", action = "FindByCategory" }
                    );
                endpoints.MapControllerRoute(
                    name: "ContactUs",
                    pattern: "ContactUs",
                    defaults: new { controller = "Home", action = "ContactUs" }
                    );
                endpoints.MapControllerRoute(
                    name: "Blog",
                    pattern: "Blog",
                    defaults: new { controller = "Blog", action = "Index" }
                    );
                endpoints.MapControllerRoute(
                    name: "Cart",
                    pattern: "Cart",
                    defaults: new { controller = "Cart", action = "Index" }
                    );
            });

        }
    }
}
