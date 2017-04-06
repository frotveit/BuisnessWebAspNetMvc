
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BuisnessWeb.Services;
using Microsoft.AspNetCore.Http;


namespace BuisnessWeb
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMemoryCache();
            services.AddSession();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                //options.Password.RequiredLength = 6;
                //options.User.RequireUniqueEmail = true;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            AddApplicationServices(services);

            services.AddMvc();
        }

        private static void AddApplicationServices(IServiceCollection services)
        {
            services.AddSingleton<IConfigurationGetter, ConfigurationGetter>();
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IHourRegistrationRepository, HourRegistrationRepository>();
            services.AddTransient<IShopItemRepository, ShopItemRepository>();
            services.AddTransient<IShopOrderRepository, ShopOrderRepository>();
            services.AddTransient<IShopCategoryRepository, ShopCategoryRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) //, IConfigurationGetter configurationGetter)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseFileServer();  // == app.UseDefaultFiles(); +  app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseIdentity();

            app.UseWelcomePage("/Welcome");
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "categoryfilter",
                  template: "ShopItem/{action}/{category?}",
                  defaults: new { Controller = "ShopItem", action = "List" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.Run(context => context.Response.WriteAsync("Not found")); // if map routing fails

            DbInitializer.Seed(app);
        }
    }
}
