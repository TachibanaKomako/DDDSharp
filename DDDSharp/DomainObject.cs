using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSharp
{
    public abstract class DomainObject
    {
        private IServiceContainer? container;
        protected IServiceContainer Container => container ?? throw new NullReferenceException();
        public void Initialize(IServiceContainer serviceContainer)
        {
            container = serviceContainer;
            OnInitialize();
        }
        protected virtual void OnInitialize()
        {
        }
    }
}
