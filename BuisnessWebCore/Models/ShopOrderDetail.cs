

using System.ComponentModel.DataAnnotations;

namespace BuisnessWebCore.Models
{
    public class ShopOrderDetail
    {
        [Key]
        public int ShopOrderDetailId { get; set; }
        public int ShopOrderId { get; set; }
        public int ShopItemId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual ShopItem ShopItem { get; set; }
        public virtual ShopOrder ShopOrder { get; set; }
    }
}
