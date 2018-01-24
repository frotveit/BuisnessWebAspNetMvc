

using BuisnessWebCore.Models;
using BuisnessWebCore.Repositories;
using System.Collections.Generic;

namespace BuisnessWebStore.Repositories
{
    public class ShopCategoryRepository : IShopCategoryRepository
    {
        private readonly IAppDbContext _appDbContext;

        public ShopCategoryRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<ShopCategory> ShopCategories => _appDbContext.ShopCategories;
    }
}
