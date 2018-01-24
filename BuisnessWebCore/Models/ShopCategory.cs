

using System.Collections.Generic;

namespace BuisnessWebCore.Models
{
    public class ShopCategory
    {
        //[Key]
        public int ShopCategoryId { get; set; }
        public string ShopCategoryName { get; set; }
        public string Description { get; set; }
        public List<ShopItem> Items { get; set; }
    }

}
