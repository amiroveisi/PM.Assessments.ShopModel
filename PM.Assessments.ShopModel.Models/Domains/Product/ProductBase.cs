using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.Assessments.ShopModel.Models.Domains.Subscription;
using PM.Assessments.ShopModel.Models.Domains.User;

namespace PM.Assessments.ShopModel.Models.Domains.Product
{
    /// <summary>
    /// The base class for all product types.
    /// It supports different price and delivery cost calculation methods.
    /// A derived class can implement IProductPriceChangeNotify to notify all subscribers when a product price changed.
    /// </summary>
    public abstract class ProductBase : IProductPriceChangeNotify
    {
        /// <summary>
        /// Name of the product. It's not unique.
        /// It supports subscription to price change events.
        /// Subscribers should implement IProductPriceSubscriber interface. then, they can use Subscribe and Unsubscribe methods 
        /// to subscribe and unsubscribe to price change events.
        /// </summary>
        public required string Name { get; init; }
        /// <summary>
        /// The article number of the product that should be unique.
        /// </summary>
        public required string ArticleNumber { get; init; }
        /// <summary>
        /// The product images. each product type can limit the number of images it could have.
        /// If there was no product image, Images will be null.
        /// </summary>
        public List<string>? Images { get; set; }
        /// <summary>
        /// The price of this product. the value of price will be calculated at runtime based on the provided parameters using CalculatePrice method.
        /// Different product classes can override the setter to call Notify method to trigger price change event of subscribers.
        /// </summary>
        public decimal Price { get; private set; } // calling notify could be done in the setter
        /// <summary>
        /// The product category. each product can have just one category.
        /// </summary>
        public required ProductCategoryBase Category { get; init; }
        /// <summary>
        /// If this product was created by a seller, the seller id will be kept.
        /// If the seller id was null, means that this product is not created by any seller.
        /// </summary>
        public string? SellerId { get; set; }
        /// <summary>
        /// When implemented in a derived class, this method will calculate the product price based on the quantity and an optional off percentage.
        /// </summary>
        /// <param name="priceCalculator">An implementation of IProductPriceCalculator that calculates the price based on quantity and an optional off percentage.</param>
        /// <param name="qty">The product quantity.</param>
        /// <param name="offPercentage">An optional off percentage.</param>
        /// <returns></returns>
        public abstract decimal CalculatePrice(IProductPriceCalculator priceCalculator, uint qty, double offPercentage = 0);
        /// <summary>
        /// When implemented in a derived class, this method will calculate the delivery price based on the product type, quantity and a delivery address.
        /// </summary>
        /// <param name="deliveryCostCalculator">An implementation of IDeliveryCostCalculator that calculated the delivery cost based on product, quantity and a delivery address.</param>
        /// <param name="qty">The product quantity.</param>
        /// <param name="address">The delivery address.</param>
        /// <returns></returns>
        public abstract decimal CalculateDeliveryCost(IDeliveryCostCalculator deliveryCostCalculator, uint qty, Address address);
        /// <summary>
        /// This method can be called to add a subscriber to an event of the product. like, price change event.
        /// </summary>
        /// <param name="subscriber">The object that wants to be added as a subscriber of the event.</param>
        /// <param name="eventName">The event name that a subscriber wants to subscribe to.</param>
        public abstract void Subscribe(ISubscriber<ProductBase> subscriber, string eventName);
        /// <summary>
        /// This method can be called to remove a subscriber from an event of the product. like, price change event.
        /// </summary>
        /// <param name="subscriber">The object that wants to be removed as a subscriber of the event.</param>
        /// <param name="eventName">The event name that a subscriber wants to unsubscribe.</param>
        public abstract void Unsubscribe(ISubscriber<ProductBase> subscriber, string eventName);
        /// <summary>
        /// In a derived class, this method can be called to notify all of the subscribers for a specific event.
        /// For example, this can be called in the price setter to notify the subscribers to the price change event.
        /// </summary>
        /// <param name="eventName">The event name that is triggered.</param>
        /// <param name="data">The data that will be passed to subscribers.</param>
        /// <param name="fieldName">The name of a product field that caused the trigger. like Price, for the price change event.</param>
        public abstract void Notify(string eventName, ProductBase data, string fieldName);

    }
}
