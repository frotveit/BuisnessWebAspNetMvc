
using BuisnessWeb.ViewModels;
using BuisnessWebCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BuisnessWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShopItemRepository _itemRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IShopItemRepository itemRepository, IShoppingCart shoppingCart)
        {
            _itemRepository = itemRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int shopItemId)
        {
            var selectedItem = _itemRepository.ShopItems.FirstOrDefault(i => i.ShopItemId == shopItemId);

            if (selectedItem != null)
            {
                _shoppingCart.AddToCart(selectedItem, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int shopItemId)
        {
            var selectedItem = _itemRepository.ShopItems.FirstOrDefault(p => p.ShopItemId == shopItemId);

            if (selectedItem != null)
            {
                _shoppingCart.RemoveFromCart(selectedItem);
            }
            return RedirectToAction("Index");
        }
    }
}