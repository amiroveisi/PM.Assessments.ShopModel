using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Assessments.ShopModel.Models.Domains.Order
{
    /// <summary>
    /// Handles discount codes validation and value
    /// </summary>
    public interface IDiscountCodeHandler
    {
        /// <summary>
        /// Checks if a discount code is valid for the given user.
        /// </summary>
        /// <param name="code">Discount code to be checked</param>
        /// <param name="username">Username to check the discount for</param>
        /// <returns>If the code was valid, returns the discount percentage. otherwise, returns 0.</returns>
        public double CheckDiscountCode(string code, string username);
    }
}
