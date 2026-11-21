using System;
using System.Collections.Generic;

namespace ManaChess.Core
{
    public sealed class EventBus : IEventBus
    {
        
        // Delivers each event to all subscribers of that event type, in subscription order. Publishers and subscribers never reference each other.
        // 把 event 派送给所有订阅该类型的对象，按订阅顺序执行。发送方和接收方互不认识。

        private readonly Dictionary<Type, List<Delegate>> handlersByType =
            new Dictionary<Type, List<Delegate>>();

        public void Subscribe<T>(Action<T> handler) where T : struct
        {
            if (!handlersByType.TryGetValue(typeof(T), out List<Delegate> handlers))
            {
                handlers = new List<Delegate>();
                handlersByType.Add(typeof(T), handlers);
            }
            handlers.Add(handler);
        }

        public void Unsubscribe<T>(Action<T> handler) where T : struct
        {
            if (handlersByType.TryGetValue(typeof(T), out List<Delegate> handlers))
            {
                handlers.Remove(handler);
            }
        }

        public void Publish<T>(T gameEvent) where T : struct
        {
            if (!handlersByType.TryGetValue(typeof(T), out List<Delegate> handlers))
            {
                return;
            }

            foreach (Delegate handler in handlers.ToArray())
            {
                ((Action<T>)handler).Invoke(gameEvent);
            }
            
        }
    }
}