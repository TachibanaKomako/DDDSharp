using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSharp
{
    public interface IServiceContainer
    {
        T GetService<T>()
        where T : notnull;
        T CreateService<T>() where T : notnull;
    }
}
