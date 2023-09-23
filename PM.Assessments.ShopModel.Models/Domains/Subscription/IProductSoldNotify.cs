using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.Assessments.ShopModel.Models.Domains.Product;

namespace PM.Assessments.ShopModel.Models.Domains.Subscription
{
    /// <summary>
    /// The interface to broadcast product sold event.
    /// An implementation of this interface can have subscribers to get notified when a product is sold.
    /// </summary>
    public interface IProductSoldNotify : ISubscriptable<ProductBase>
    {
    }
}
