using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.Assessments.ShopModel.Models.Domains.Product;
using PM.Assessments.ShopModel.Models.Domains.User;

namespace PM.Assessments.ShopModel.Models.Domains.Product
{
    /// <summary>
    /// An interface to calculate different delivery methods cost.
    /// </summary>
    public interface IDeliveryCostCalculator
    {
        /// <summary>
        /// This method will calculate the delivery cost of a product based on the product, its quantity and the delivery address.
        /// </summary>
        /// <param name="product">The product to calculate the delivery cost for.</param>
        /// <param name="quantity">Quantity of the product.</param>
        /// <param name="address">The delivery address.</param>
        /// <returns></returns>
        public decimal Calculate(ProductBase product, uint quantity, Address address);
    }
}
