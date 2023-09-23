using PM.Assessments.ShopModel.Models.Domains.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Assessments.ShopModel.Models.Domains.Product
{
    /// <summary>
    /// An interface to calculate the product price based on different parameters like quantity and off percentage.
    /// </summary>
    public interface IProductPriceCalculator
    {
        /// <summary>
        /// This method will calculate the price of the given product based on its quantity and an optional off percentage.
        /// </summary>
        /// <param name="product">The product to calculate its price.</param>
        /// <param name="quantity">The quantity of the product.</param>
        /// <param name="offPercentage">An optional off percentage to calculate the price.</param>
        /// <returns></returns>
        public decimal CalculatePrice(ProductBase product, uint quantity, double offPercentage = 0);
    }
}
