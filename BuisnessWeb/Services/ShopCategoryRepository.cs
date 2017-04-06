

using BuisnessWeb.Models;
using System.Collections.Generic;

namespace BuisnessWeb.Services
{
    public class ShopCategoryRepository : IShopCategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public ShopCategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<ShopCategory> ShopCategories => _appDbContext.ShopCategories;
    }
}
