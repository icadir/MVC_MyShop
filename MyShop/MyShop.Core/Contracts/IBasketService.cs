using System.Collections.Generic;
using System.Web;
using MyShop.Core.ViewModels;

namespace MyShop.Core.Contracts
{
    public interface IBasketService
    {
        void AddtoBasket(HttpContextBase httpContext, string productId);
        void RemoveFromBasket(HttpContextBase httpContext, string itemId);
        List<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext);
        BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext);
        void ClearBasket(HttpContextBase httpContext)
    }
}
