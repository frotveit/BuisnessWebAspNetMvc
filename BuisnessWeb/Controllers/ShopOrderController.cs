
using BuisnessWebCore.Models;
using BuisnessWebCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BuisnessWeb.Controllers
{
    public class ShopOrderController : Controller
    {
        private readonly IShopOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShopOrderController(IShopOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        //[Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Checkout(ShopOrder shopOrder)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some items first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(shopOrder);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(shopOrder);

        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = HttpContext.User.Identity.Name +
                                      ", thanks for your order. You'll soon enjoy your items!";
            return View();
        }
    }
}