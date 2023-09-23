using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Assessments.ShopModel.Models.Domains.ShoppingCart
{
    /// <summary>
    /// The base class for shopping cart. It supports operations like adding, removing and clearing items.
    /// A shopping cart, belongs to a specific user.
    /// </summary>
    public abstract class ShoppingCartBase
    {
        /// <summary>
        /// The username that this shopping cart belongs to.
        /// </summary>
        public required string Username { get; init; }
        /// <summary>
        /// The total price of this shopping cart. It will be calculated based on the product prices and the IProductPriceCalculator that is used for each product.
        /// </summary>
        public decimal TotalPrice { get; private set; }
        /// <summary>
        /// This list keeps the shopping cart items. each item has its own product, quantity and unit price.
        /// </summary>
        protected List<ShoppingCartItem> Items { get; private set; } = new List<ShoppingCartItem>();
        /// <summary>
        /// This method adds a shopping cart item to the shopping cart.
        /// </summary>
        /// <param name="item">The item to be added to the shopping cart.</param>
        /// <param name="qty">The quantity of the item.</param>
        public abstract void AddToCart(ShoppingCartItem item, uint qty);
        /// <summary>
        /// This method will remove the given item from the shopping cart.
        /// </summary>
        /// <param name="item">The item to be removed.</param>
        /// <param name="qty">The amount of the item to be removed from the shopping cart. If the given quantity and the current quantity were the same, the item will be removed completely from the cart.</param>
        public abstract void RemoveFromCart(ShoppingCartItem item, uint qty);
        /// <summary>
        /// This method will clear all items of the shopping cart.
        /// </summary>
        public abstract void Clear();
    }
}
