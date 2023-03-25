using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSharp
{
    public interface IEventSubscriber<T>
    {
        void Handle(T args);
    }
}
