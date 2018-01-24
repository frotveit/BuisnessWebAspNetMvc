

using System.ComponentModel.DataAnnotations;

namespace BuisnessWebCore.Models
{
    public class ShopItem
    {
        [Key]
        public int ShopItemId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }       
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsItemOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int ShopCategoryId { get; set; }
        public virtual ShopCategory ShopCategory { get; set; }
    }
}
