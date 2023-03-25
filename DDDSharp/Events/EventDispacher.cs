using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSharp.Events
{
    public class EventDispacher : IEventDispacher
    {
        private readonly List<object> subscribers = new();
        public void Publish<T>(T eventArgs)
        {
            foreach (object subscriber in subscribers)
            {
                if(subscriber is IEventSubscriber<T> target)
                {
                    target.Handle(eventArgs);
                }
            }
        }

        public void Subscribe<T>(IEventSubscriber<T> subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Unsubscribe<T>(IEventSubscriber<T> subscriber)
        {
            subscribers.Remove(subscriber);
        }
    }
}
