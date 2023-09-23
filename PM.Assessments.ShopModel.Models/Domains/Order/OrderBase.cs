using PM.Assessments.ShopModel.Models.Domains.Payment;
using PM.Assessments.ShopModel.Models.Domains.Product;
using PM.Assessments.ShopModel.Models.Domains.Subscription;
using PM.Assessments.ShopModel.Models.Domains.User;

namespace PM.Assessments.ShopModel.Models.Domains.Order
{
    /// <summary>
    /// Base class for Order to manage an order that contains information about the order and operations on it.
    /// It supports subscribing to IProductSoldNotify to get notified when a product was sold.
    /// </summary>
    public abstract class OrderBase : IProductSoldNotify
    {
        /// <summary>
        /// The order Id. It should be unique and will be used to track the order when needed.
        /// </summary>
        public Guid Id { get; private set; }
        /// <summary>
        /// The username of the user that this order belongs to.
        /// </summary>
        public required string Username { get; init; }
        /// <summary>
        /// Keeps a list of order products with their qty.
        /// </summary>
        protected Dictionary<ProductBase, uint> Items { get; private set; } = new Dictionary<ProductBase, uint>();
        /// <summary>
        /// The creation date and time of this order
        /// </summary>
        public DateTime CreationDateTime { get; init; }
        /// <summary>
        /// The finalization date and time of this order.
        /// Order will be finalized if its status change to Paid or Canceled.
        /// </summary>
        public DateTime? FinalizationDateTime { get; private set; }
        /// <summary>
        /// The total sum of all products of the order.
        /// </summary>
        public decimal TotalSum { get; private set; }
        /// <summary>
        /// The user that this order is created for.
        /// </summary>
        public required Customer IssuedTo { get; init; }
        /// <summary>
        /// The shipping address for this order. 
        /// It can be filled with the customer address by default.
        /// If all of the products were digital, this address can be null.
        /// </summary>
        public required Address? ShippingAddress { get; set; }
        /// <summary>
        /// The billing address of this order.
        /// It can be filled with the customer address by default.
        /// </summary>
        public required Address BillingAddress { get; set; }
        /// <summary>
        /// The order status.
        /// </summary>
        public OrderStatus Status { get; set; }
        /// <summary>
        /// Applies the given discount code for the user that order belongs to, using specified discount handler.
        /// </summary>
        /// <param name="discountCode">Discount code to be checked.</param>
        /// <param name="discountCodeHandler">An implementation of IDiscountHandler to check the discount validation and value.</param>
        public abstract void ApplyDiscountCode(string discountCode, IDiscountCodeHandler discountCodeHandler);
        /// <summary>
        /// Starts the payment process of this order using the given payment gateway.
        /// </summary>
        /// <param name="paymentGateway">An implementation of IPaymentGateway to specify the payment method and process.</param>
        /// <returns></returns>
        public abstract string Purchase(IPaymentGateway paymentGateway);
        /// <summary>
        /// This method can be called to add a subscriber to an event of the shopping cart. like, a product getting sold event.
        /// </summary>
        /// <param name="subscriber">The object that wants to be added as a subscriber of the event.</param>
        /// <param name="eventName">The event name that a subscriber wants to subscribe to.</param>
        public abstract void Subscribe(ISubscriber<ProductBase> subscriber, string eventName);
        /// <summary>
        /// This method can be called to remove a subscriber from an event of the shopping cart. like, a product getting sold event.
        /// </summary>
        /// <param name="subscriber">The object that wants to be removed as a subscriber of the event.</param>
        /// <param name="eventName">The event name that a subscriber wants to unsubscribe.</param>
        public abstract void Unsubscribe(ISubscriber<ProductBase> subscriber, string eventName);
        /// <summary>
        /// In a derived class, this method can be called to notify all of the subscribers for a specific event.
        /// For example, this can be called in the purchase method to notify the subscribers to the product sold event.
        /// </summary>
        /// <param name="eventName">The event name that is triggered.</param>
        /// <param name="data">The data that will be passed to subscribers.</param>
        /// <param name="fieldName">The name of a product field that caused the trigger. If there was no specific data field, it could be null.</param>
        public abstract void Notify(string eventName, ProductBase data, string fieldName);
    }
    /// <summary>
    /// Specifies the values can be used as order status.
    /// </summary>
    public enum OrderStatus
    {
        Unknown = 0,
        Billing = 10,
        Paid = 20,
        Canceled = 30,
        Pending = 40
    }
}
