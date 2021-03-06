﻿

using BuisnessWebCore.Models;
using BuisnessWebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BuisnessWebStore.Repositories
{
    public class ShopItemRepository : IShopItemRepository
    {
        private readonly IAppDbContext _appDbContext;

        public ShopItemRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<ShopItem> ShopItems
        {
            get
            {
                return _appDbContext.ShopItems.Include(c => c.ShopCategory);
            }
        }

        public IEnumerable<ShopItem> ShopItemsOfTheWeek
        {
            get
            {
                return _appDbContext.ShopItems.Include(c => c.ShopCategory).Where(p => p.IsItemOfTheWeek);
            }
        }

        public ShopItem GetShopItemById(int shopItemId)
        {
            return _appDbContext.ShopItems.FirstOrDefault(p => p.ShopItemId == shopItemId);
        }
    }
}
