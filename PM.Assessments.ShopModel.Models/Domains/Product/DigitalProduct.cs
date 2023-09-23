using PM.Assessments.ShopModel.Models.Domains.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Assessments.ShopModel.Models.Domains.Product
{
    /// <summary>
    /// Base class for all digital products.
    /// A digital product, has no stock limit and normally, no delivery cost.
    /// They will be delivered via a download link or by email.
    /// </summary>
    public abstract class DigitalProduct : ProductBase
    {
        /// <summary>
        /// The download link for the product.
        /// If delivery of the product would be done via email, then the download link could be null.
        /// </summary>
        public string? DownloadLink { get; set; }
       
    }
}
