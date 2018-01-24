using BuisnessWebCore.Models;
using System.Collections.Generic;

namespace BuisnessWebCore.Repositories
{
    public interface IShoppingCart
    {
        string ShoppingCartId { get; set; }
        List<ShoppingCartItem> ShoppingCartItems { get; set; }

        void AddToCart(ShopItem shopItem, int amount);
        void ClearCart();
        List<ShoppingCartItem> GetShoppingCartItems();
        decimal GetShoppingCartTotal();
        int RemoveFromCart(ShopItem shopItem);
    }
}