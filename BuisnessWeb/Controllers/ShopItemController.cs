
using BuisnessWeb.Services;
using BuisnessWeb.Models;
using BuisnessWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BuisnessWeb.Controllers
{
    public class ShopItemController : Controller
    {
        private readonly IShopItemRepository _itemRepository;
        private readonly IShopCategoryRepository _categoryRepository;

        public ShopItemController(IShopItemRepository itemRepository, IShopCategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult Overview()
        {
            var shopOverviewViewModel = new ShopOverviewViewModel
            {
                ShopItemsOfTheWeek = _itemRepository.ShopItemsOfTheWeek
            };

            return View(shopOverviewViewModel);
        }

        public ViewResult List(string shopCategory)
        {
            IEnumerable<ShopItem> shopItems;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(shopCategory))
            {
                shopItems = _itemRepository.ShopItems.OrderBy(i => i.ShopItemId);
                currentCategory = "All items";
            }
            else
            {
                shopItems = _itemRepository.ShopItems.Where(i => i.ShopCategory.ShopCategoryName == shopCategory).OrderBy(p => p.ShopItemId);
                if (shopCategory != null)
                {
                    currentCategory = _categoryRepository.ShopCategories.FirstOrDefault(c => c.ShopCategoryName == shopCategory).ShopCategoryName;
                }
            }

            return View(new ShopItemsListViewModel
            {
                ShopItems = shopItems,
                CurrentShopCategory = currentCategory
            });
        }

        public IActionResult Details(int shopItemId)
        {
            var item = _itemRepository.GetShopItemById(shopItemId);
            if (item == null)
                return NotFound();

            return View(item);
        }
    }
}