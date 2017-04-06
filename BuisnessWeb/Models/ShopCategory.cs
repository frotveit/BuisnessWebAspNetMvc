

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuisnessWeb.Models
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
