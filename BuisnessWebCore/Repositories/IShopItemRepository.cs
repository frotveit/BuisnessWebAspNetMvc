

using BuisnessWebCore.Models;
using System.Collections.Generic;

namespace BuisnessWebCore.Repositories
{
    public interface IShopItemRepository
    {
        IEnumerable<ShopItem> ShopItems { get; }
        IEnumerable<ShopItem> ShopItemsOfTheWeek { get; }

        ShopItem GetShopItemById(int shopItemId);
    }
}
