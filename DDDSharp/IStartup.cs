using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSharp
{
    public interface IStartup
    {
        IServiceContainer CreateServiceContainer();
    }
}
