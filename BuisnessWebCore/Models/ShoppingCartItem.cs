namespace BuisnessWebCore.Models
{
    public class ShoppingCartItem
    {
        //[Key]
        public int ShoppingCartItemId { get; set; }
        public ShopItem ShopItem { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
