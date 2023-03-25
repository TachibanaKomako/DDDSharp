using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSharp
{
    public interface IServiceContainerBuilder
    {
        void AddService<TService, T>() where T : TService;
    }
}
