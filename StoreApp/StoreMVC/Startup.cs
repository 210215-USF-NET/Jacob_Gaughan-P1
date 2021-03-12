using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreBL;
using StoreDL;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC
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
            services.AddMvc(options =>
                options.EnableEndpointRouting = false
            );
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
            });

            services.AddControllersWithViews();
            services.AddDbContext<StoreDBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("StoreDB")));
            services.AddScoped<ICustomerRepository, StoreRepoDB>();
            services.AddScoped<ILocationRepository, StoreRepoDB>();
            services.AddScoped<IOrderRepository, StoreRepoDB>();
            services.AddScoped<IProductRepository, StoreRepoDB>();
            services.AddScoped<IInventoryRepository, StoreRepoDB>();
            services.AddScoped<IManagerRepository, StoreRepoDB>();
            services.AddScoped<ICustomerBL, CustomerBL>();
            services.AddScoped<ILocationBL, LocationBL>();
            services.AddScoped<IOrderBL, OrderBL>();
            services.AddScoped<IProductBL, ProductBL>();
            services.AddScoped<IInventoryBL, InventoryBL>();
            services.AddScoped<IMapper, Mapper>();
            services.AddScoped<IManagerBL, ManagerBL>();
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
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}