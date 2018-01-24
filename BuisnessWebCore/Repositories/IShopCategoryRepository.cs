

using BuisnessWebCore.Models;
using System.Collections.Generic;

namespace BuisnessWebCore.Repositories
{
    public interface IShopCategoryRepository
    {
        IEnumerable<ShopCategory> ShopCategories { get; }
    }
}
