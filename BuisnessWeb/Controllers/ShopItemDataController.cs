using BuisnessWeb.ViewModels;
using BuisnessWebCore.Models;
using BuisnessWebCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BuisnessWeb.Controllers
{
    [Route("api/[controller]")]
    public class ShopItemDataController : Controller
    {
        private readonly IShopItemRepository _itemRepository;

        public ShopItemDataController(IShopItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public IEnumerable<ShopItemViewModel> LoadMoreShopItems()
        {
            IEnumerable<ShopItem> dbShopItems = null;

            dbShopItems = _itemRepository.ShopItems.OrderBy(p => p.ShopItemId).Take(10);

            List<ShopItemViewModel> items = new List<ShopItemViewModel>();

            foreach (var dbShopItem in dbShopItems)
            {
                items.Add(MapDbShopItemToShopItemViewModel(dbShopItem));
            }
            return items;
        }

        private ShopItemViewModel MapDbShopItemToShopItemViewModel(ShopItem dbShopItem)
        {
            return new ShopItemViewModel()
            {
                ShopItemId = dbShopItem.ShopItemId,
                Name = dbShopItem.Name,
                Price = dbShopItem.Price,
                ShortDescription = dbShopItem.ShortDescription,
                ImageThumbnailUrl = dbShopItem.ImageThumbnailUrl
            };
        }
    }
}