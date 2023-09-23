using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Assessments.ShopModel.Models.Domains.Payment
{
    /// <summary>
    /// Handles a payment method and status of a payment.
    /// </summary>
    public interface IPaymentGateway
    {
        /// <summary>
        /// Starts a payment with the given price and calls the callBackUrl when the payment is finished.
        /// the callBackUrl will be called regardless of the payment status.
        /// </summary>
        /// <param name="price">The amount to be paid using the payment gateway.</param>
        /// <param name="callBackUrl">The URL to be called back when the payment finished.</param>
        /// <returns>If the payment was not canceled, returns the payment Id, otherwise returns null</returns>
        public string? StartPayment(decimal price, string callBackUrl);
        /// <summary>
        /// Gets the status of a payment using a payment id.
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns>The status of the given payment.</returns>
        public PaymentStatus GetStatus(string paymentId);
        /// <summary>
        /// If a user wants to cancel the payment manually, this method can be used.
        /// It is not guaranteed that the payment will be canceled.
        /// </summary>
        /// <param name="paymentId">The payment id to cancel.</param>
        /// <returns>If the payment was canceled successfully, returns Canceled. otherwise, returns the current order status.</returns>
        public PaymentStatus TryCancelPayment(string paymentId);
    }
    /// <summary>
    /// Specifies the values can be used as payment status.
    /// </summary>
    public enum PaymentStatus
    {
        Unknown = 0,
        Succeeded = 10,
        Failed = 20,
        Canceled = 30,
        Pending = 40
    }
}
