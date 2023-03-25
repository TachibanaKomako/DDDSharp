using DDDSharp.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSharp
{
    /// <summary>
    /// DDDSharpを利用するうえで基礎となるSetupクラス
    /// </summary>
    public class DefaultDependencySetup : IDependencySetup
    {
        public void Run(IServiceContainerBuilder builder)
        {
            builder.AddService<IEventDispacher, EventDispacher>();
        }
    }
}
