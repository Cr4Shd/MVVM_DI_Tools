using System;
using System.Collections.Generic;
using System.Text;

namespace NAV_Prototyp_Vorlage.MessageEventBus
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<Delegate>> _handlers = new(); 
        private readonly Dictionary<Type, List<Delegate>> _handlersAsync = new(); 
       
        public void Subscribe<T>(Action<T> handler)
        {
            var type = typeof(T);

            if (!_handlers.ContainsKey(type))
            {
                _handlers[type] = new List<Delegate>();
            }
            _handlers[type].Add(handler);
        }

        public void Publish<T>(T message)
        {
            var type = typeof(T);

            if (_handlers.TryGetValue(type, out var handlers))
            {
                foreach (var handler in handlers.Cast<Action<T>>())
                {
                    handler(message);
                }
            }
        }
        
        public void SubscribeAsync<T>(Func<T, Task> handler)
        {
            var type = typeof(T);

            if (!_handlersAsync.ContainsKey(type))
                _handlersAsync[type] = new List<Delegate>();

            _handlersAsync[type].Add(handler);

        }

        
        public async Task PublishAsync<T>(T message)
        {
            var type = typeof(T);

            if (_handlersAsync.TryGetValue(type, out var handlers))
            {
                var tasks = handlers
                    .Cast<Func<T, Task>>()
                    .Select(handler => handler(message));

                await Task.WhenAll(tasks);
            }
        }

    }
}
