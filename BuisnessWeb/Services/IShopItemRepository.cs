

using BuisnessWeb.Models;
using System.Collections.Generic;

namespace BuisnessWeb.Services
{
    public interface IShopItemRepository
    {
        IEnumerable<ShopItem> ShopItems { get; }
        IEnumerable<ShopItem> ShopItemsOfTheWeek { get; }

        ShopItem GetShopItemById(int shopItemId);
    }
}
