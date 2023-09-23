using PM.Assessments.ShopModel.Models.Domains.Product;
using PM.Assessments.ShopModel.Models.Domains.Subscription;

namespace PM.Assessments.ShopModel.Models.Domains.User
{
    /// <summary>
    /// The base class for users that are seller.
    /// It supports subscribing to product sold and product out of stock events.
    /// A derived class can subscribe to an instance of IProductSoldNotify and IOutOfStockNotify to get notified when the product was sold or was out of stock.
    /// A seller also can create a product.
    /// </summary>
    public abstract class SellerUser : UserBase, IOutOfStockSubscriber, IProductSoldSubscriber
    {
        /// <summary>
        /// This method creates a product for this seller and set its seller id and also can subscribe by default to get notified when it is sold or out of stock.
        /// </summary>
        /// <param name="product">The product to be mark as created by this seller.</param>
        public abstract void CreateProduct(ProductBase product);
        /// <summary>
        /// In a derived class, this method will be called by an ISubscriptable when the given event was triggered.
        /// </summary>
        /// <param name="eventName">The event that was triggered.</param>
        /// <param name="data">The data that is sent by the ISubscriptable for this event.</param>
        /// <param name="fieldName">The data field that caused the event trigger. It could be null if there was no specific field for event trigger.</param>
        public abstract void OnNotify(string eventName, ProductBase data, string fieldName);
    }
}
