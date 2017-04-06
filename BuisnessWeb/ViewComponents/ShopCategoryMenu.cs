

using BuisnessWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BuisnessWeb.ViewComponents
{
    public class ShopCategoryMenu : ViewComponent
    {
        private readonly IShopCategoryRepository _categoryRepository;
        public ShopCategoryMenu(IShopCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.ShopCategories.OrderBy(c => c.ShopCategoryName);
            return View(categories);
        }
    }
}
