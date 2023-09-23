using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.Assessments.ShopModel.Models.Domains.Product;
using PM.Assessments.ShopModel.Models.Domains.Subscription;

namespace PM.Assessments.ShopModel.Models.Domains.Stock
{
    /// <summary>
    /// The base class for stock. It has operations to manage the stock.
    /// It supports subscription to out of stock event. this will be triggered when a product was out of stock.
    /// Subscribers should implement IOutOfStockSubscriber interface. then, they can use Subscribe and Unsubscribe methods 
    /// to subscribe and unsubscribe to out of stock events.
    /// </summary>
    public abstract class StockBase : IOutOfStockNotify
    {
        /// <summary>
        /// The stock Id that will be unique and will be used to track a product in a stock when needed.
        /// </summary>
        public required string Id { get; set; }
        /// <summary>
        /// This dictionary keeps stock items in format of "<articleNumber,qty>". 
        /// It supports concurrent access to stock items.
        /// </summary>
        protected ConcurrentDictionary<string, int> StockItems = new ConcurrentDictionary<string, int>();
        /// <summary>
        /// This method returns the count of a product in this stock.
        /// </summary>
        /// <param name="product">The product to get the count in this stock.</param>
        /// <returns>The count of the given product in this stock.</returns>
        public abstract int GetStockItemsCountFor(ProductBase product);
        /// <summary>
        /// This method adds a product to this stock. if there was already a product with the same article number, its quantity will be added by the given qty.
        /// If there was not such a product, it will be added with the given qty.
        /// </summary>
        /// <param name="product">The product to be added to this stock.</param>
        /// <param name="qty">The quantity of the given product to be added.</param>
        public abstract void AddToStock(ProductBase product, uint qty);
        /// <summary>
        /// This method removes a product from this stock by the given qty.
        /// In a derived class, if the given qty was greater than the available quantity, it may throw an exception.
        /// </summary>
        /// <param name="product">The product to be removed from this stock.</param>
        /// <param name="qty">The quantity of the given product to be removed.</param>
        public abstract void RemoveFromStock(ProductBase product, uint qty);
        /// <summary>
        /// This method can be called to add a subscriber to an event of the stock. like, out of stock event.
        /// </summary>
        /// <param name="subscriber">The object that wants to be added as a subscriber to the event.</param>
        /// <param name="eventName">The event name that a subscriber wants to subscribe.</param>
        public abstract void Subscribe(ISubscriber<ProductBase> subscriber, string eventName);
        /// <summary>
        /// This method can be called to remove a subscriber from an event of the stock. like, out of stock.
        /// </summary>
        /// <param name="subscriber">The object that wants to be removed as a subscriber of the event.</param>
        /// <param name="eventName">The event name that a subscriber wants to unsubscribe.</param>
        public abstract void Unsubscribe(ISubscriber<ProductBase> subscriber, string eventName);
        /// <summary>
        /// In a derived class, this method can be called to notify all of the subscribers for a specific event.
        /// For example, this can be called in the RemoveFromStock method to notify the subscribers to the out of stock event.
        /// </summary>
        /// <param name="eventName">The event name that is triggered.</param>
        /// <param name="data">The data that will be passed to subscribers.</param>
        /// <param name="fieldName">The name of a data field that caused the trigger. like Product.Name, for the out of stock event.</param>
        public abstract void Notify(string eventName, ProductBase data, string fieldName);
    }
}
