using BuisnessWebCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BuisnessWebStore
{
    public interface IAppDbContext
    {
        int SaveChanges();

        void AddRange(IEnumerable<object> entities);        
        void AddRange(params object[] entities);

        DbSet<Employee> Employees { get; set; }
        DbSet<PaymentInformation> PaymentInformation { get; set; }
        DbSet<HourRegistration> HourRegistration { get; set; }

        DbSet<ShopItem> ShopItems { get; set; }
        DbSet<ShopCategory> ShopCategories { get; set; }
        DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        DbSet<ShopOrder> ShopOrders { get; set; }
        DbSet<ShopOrderDetail> ShopOrderDetails { get; set; }
    }

    public class AppDbContext : IdentityDbContext<IdentityUser>, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
              
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PaymentInformation> PaymentInformation { get; set; }
        public DbSet<HourRegistration> HourRegistration { get; set; }

        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<ShopCategory> ShopCategories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ShopOrder> ShopOrders { get; set; }
        public DbSet<ShopOrderDetail> ShopOrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<HourRegistration>().HasKey(c => new { c.EmployeeId, c.Date });
        }

    }
}
