

using BuisnessWeb.Models;

namespace BuisnessWeb.Services
{
    public interface IShopOrderRepository
    {
        void CreateOrder(ShopOrder shopOrder);
    }
}
