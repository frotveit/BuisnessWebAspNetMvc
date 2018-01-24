

using BuisnessWebCore.Models;
using BuisnessWebCore.Repositories;
using System;

namespace BuisnessWebStore.Repositories
{
    public class ShopOrderRepository : IShopOrderRepository
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;


        public ShopOrderRepository(IAppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(ShopOrder order)
        {
            order.OrderPlaced = DateTime.Now;

            _appDbContext.ShopOrders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new ShopOrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    ShopItemId = shoppingCartItem.ShopItem.ShopItemId,
                    ShopOrderId = order.ShopOrderId,
                    Price = shoppingCartItem.ShopItem.Price
                };

                _appDbContext.ShopOrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }
    }
}
