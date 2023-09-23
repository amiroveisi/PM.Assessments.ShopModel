using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Assessments.ShopModel.Models.Domains.Subscription
{
    /// <summary>
    /// The base interface for all subscriptable.
    /// You can inherit this interface in other interfaces or implement it directly.
    /// An implementation of this interface can have multiple subscribers and notify them on a certain event trigger.
    /// </summary>
    /// <typeparam name="TNotifyData">The data type that will be sent when an event was triggered.</typeparam>
    public interface ISubscriptable<TNotifyData>
    {
        /// <summary>
        /// This method adds an object as a subscriber to the given event.
        /// </summary>
        /// <param name="subscriber">An implementation of ISubscriber that will be subscribed to this ISubscriptable.</param>
        /// <param name="eventName">The event name that the given ISubscriber will subscribe to.</param>
        public void Subscribe(ISubscriber<TNotifyData> subscriber, string eventName);
        /// <summary>
        /// This method removes an object as a subscriber from the given event.
        /// </summary>
        /// <param name="subscriber">An implementation of ISubscriber that will be unsubscribed from this ISubscriptable.</param>
        /// <param name="eventName">The event name that the given ISubscriber will unsubscribe from.</param>
        public void Unsubscribe(ISubscriber<TNotifyData> subscriber, string eventName);
        /// <summary>
        /// This method will notify all subscribers of the given event when the event was triggered.
        /// </summary>
        /// <param name="eventName">The event name that is triggered.</param>
        /// <param name="data">The data that will be sent to subscribers of this event.</param>
        /// <param name="fieldName">The name of data field that caused the trigger. If there was no specific field name, you can pass null.</param>
        public void Notify(string eventName, TNotifyData data, string fieldName);
    }
}
