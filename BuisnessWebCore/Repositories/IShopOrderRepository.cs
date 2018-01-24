

using BuisnessWebCore.Models;

namespace BuisnessWebCore.Repositories
{
    public interface IShopOrderRepository
    {
        void CreateOrder(ShopOrder shopOrder);
    }
}
