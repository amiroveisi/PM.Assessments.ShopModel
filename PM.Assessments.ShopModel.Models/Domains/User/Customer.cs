using PM.Assessments.ShopModel.Models.Domains.Product;
using PM.Assessments.ShopModel.Models.Domains.Subscription;

namespace PM.Assessments.ShopModel.Models.Domains.User
{
    /// <summary>
    /// The base class for users that are customer.
    /// It supports subscribing to product price change event.
    /// A derived class can subscribe to an instance of IProductPriceChangeNotify and get notified when the product price changes.
    /// </summary>
    public abstract class Customer : UserBase, IProductPriceChangeSubscriber
    {
        /// <summary>
        /// In a derived class, this method will be called by an ISubscriptable when the given event was triggered.
        /// </summary>
        /// <param name="eventName">The event that was triggered.</param>
        /// <param name="data">The data that is sent by the ISubscriptable for this event.</param>
        /// <param name="fieldName">The data field that caused the event trigger. It could be null if there was no specific field for event trigger.</param>
        public abstract void OnNotify(string eventName, ProductBase data, string fieldName);
    }
}
