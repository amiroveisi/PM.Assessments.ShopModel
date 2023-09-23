using PM.Assessments.ShopModel.Models.Domains.Product;
using PM.Assessments.ShopModel.Models.Domains.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Assessments.ShopModel.Models.Domains.Product
{
    /// <summary>
    /// The base class for all normal products. 
    /// A normal product, has stock limitation and could be delivered via post.
    /// </summary>
    public abstract class NormalProduct : ProductBase
    {
        /// <summary>
        /// The stock that products of this type will be kept there.
        /// </summary>
        public required StockBase Stock { get; init; }
        /// <summary>
        /// The constructor of NormalProduct.
        /// </summary>
        /// <param name="stock">A StockBase that will be used as the stock that this product will be kept there.</param>
        protected NormalProduct(StockBase stock)
        {
            Stock = stock;
        }
    }
}
