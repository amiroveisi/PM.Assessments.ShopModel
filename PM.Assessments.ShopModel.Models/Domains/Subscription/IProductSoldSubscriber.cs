using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.Assessments.ShopModel.Models.Domains.Product;

namespace PM.Assessments.ShopModel.Models.Domains.Subscription
{
    /// <summary>
    /// The interface to subscribe for product sold event.
    /// An implementation of this interface can subscribe and get notified when a product is sold.
    /// </summary>
    public interface IProductSoldSubscriber : ISubscriber<ProductBase>
    {
    }
}
