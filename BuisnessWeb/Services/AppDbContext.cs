


using BuisnessWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuisnessWeb.Services
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<HourRegistration>().HasKey(c => new { c.EmployeeId, c.Date });
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<PaymentInformation> PaymentInformation { get; set; }
        public DbSet<HourRegistration> HourRegistration { get; set; }

        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<ShopCategory> ShopCategories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ShopOrder> ShopOrders { get; set; }
        public DbSet<ShopOrderDetail> ShopOrderDetails { get; set; }

    }
}
