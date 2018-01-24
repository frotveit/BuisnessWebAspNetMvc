

using BuisnessWebCore.Models;
using System.Collections.Generic;

namespace BuisnessWeb.ViewModels
{
    public class ShopItemsListViewModel
    {
        public IEnumerable<ShopItem> ShopItems { get; set; }
        public string CurrentShopCategory { get; set; }
    }
}
