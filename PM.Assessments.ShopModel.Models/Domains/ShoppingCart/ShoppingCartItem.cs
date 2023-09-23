using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.Assessments.ShopModel.Models.Domains.Product;

namespace PM.Assessments.ShopModel.Models.Domains.ShoppingCart
{
    /// <summary>
    /// This class represents a shopping cart item that can be added/removed from a ShoppingCartBase instance.
    /// </summary>
    public abstract class ShoppingCartItem
    {
        /// <summary>
        /// The product that will be in this shopping cart item.
        /// </summary>
        public ProductBase Product { get; init; }
        /// <summary>
        /// The quantity of the product in this shopping cart item.
        /// </summary>
        public uint Quantity { get; private set; }
        /// <summary>
        /// The constructor of ShoppingCartItem.
        /// </summary>
        /// <param name="product">The product that this shopping cart item represents.</param>
        protected ShoppingCartItem(ProductBase product)
        {
            Product = product;
        }


    }
}
