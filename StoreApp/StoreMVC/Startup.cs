using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreBL;
using StoreDL;
using StoreMVC.Models;

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
            services.AddDistributedMemoryCache();
            services.AddControllersWithViews();
            services.AddDbContext<StoreDBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("StoreDB")));
            services.AddScoped<ICustomerRepository, StoreRepoDB>();
            services.AddScoped<ILocationRepository, StoreRepoDB>();
            services.AddScoped<IOrderRepository, StoreRepoDB>();
            services.AddScoped<IProductRepository, StoreRepoDB>();
            services.AddScoped<IManagerRepository, StoreRepoDB>();
            services.AddScoped<ICartRepository, StoreRepoDB>();
            services.AddScoped<ICustomerBL, CustomerBL>();
            services.AddScoped<ILocationBL, LocationBL>();
            services.AddScoped<IOrderBL, OrderBL>();
            services.AddScoped<IProductBL, ProductBL>();
            services.AddScoped<ICartBL, CartBL>();
            services.AddScoped<IManagerBL, ManagerBL>();
            services.AddScoped<IMapper, Mapper>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}