using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSharp
{
    public interface IEventDispacher
    {
        void Subscribe<T>(IEventSubscriber<T> subscriber);
        void Unsubscribe<T>(IEventSubscriber<T> subscriber);
        void Publish<T>(T eventArgs);
    }
}
