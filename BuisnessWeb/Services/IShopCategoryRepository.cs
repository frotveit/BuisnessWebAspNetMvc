

using BuisnessWeb.Models;
using System.Collections.Generic;

namespace BuisnessWeb.Services
{
    public interface IShopCategoryRepository
    {
        IEnumerable<ShopCategory> ShopCategories { get; }
    }
}
