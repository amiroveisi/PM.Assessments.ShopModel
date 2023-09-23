using PM.Assessments.ShopModel.Models.Domains.Product;

namespace PM.Assessments.ShopModel.Models.Domains.Subscription
{
    /// <summary>
    /// The interface to broadcast out of stock event.
    /// An implementation of this interface can have subscribers to get notified when a product gets out of stock.
    /// </summary>
    public interface IOutOfStockNotify : ISubscriptable<ProductBase>
    {
    }
}
