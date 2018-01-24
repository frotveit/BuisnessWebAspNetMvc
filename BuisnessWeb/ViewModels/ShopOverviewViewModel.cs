using BuisnessWebCore.Models;
using System.Collections.Generic;


namespace BuisnessWeb.ViewModels
{
    public class ShopOverviewViewModel
    {
        public IEnumerable<ShopItem> ShopItemsOfTheWeek { get; set; }
    }
}
