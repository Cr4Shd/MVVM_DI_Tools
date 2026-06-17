using System;
using System.Collections.Generic;
using System.Text;

namespace NAV_Prototyp_Vorlage.MessageEventBus
{
    public interface IEventBus
    {
        void Subscribe<T>(Action<T> handler);
        void Publish<T>(T message);
        Task PublishAsync<T>(T message);
        void SubscribeAsync<T>(Func<T, Task> handler);


    }
}
