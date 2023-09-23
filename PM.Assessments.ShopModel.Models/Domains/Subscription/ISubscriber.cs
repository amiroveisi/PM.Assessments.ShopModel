using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Assessments.ShopModel.Models.Domains.Subscription
{
    /// <summary>
    /// The base interface for all event subscribers.
    /// You can inherit this interface in other interfaces or implement it directly.
    /// An implementation of this interface can subscribe to get notified on a specific event.
    /// </summary>
    /// <typeparam name="TNotifyData">The data type that will be sent when an event was triggered.</typeparam>
    public interface ISubscriber<TNotifyData>
    {
        public void OnNotify(string eventName, TNotifyData data, string fieldName);
    }
}
