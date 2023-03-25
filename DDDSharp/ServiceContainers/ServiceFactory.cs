using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSharp.ServiceContainers
{
    internal class ServiceFactory
    {
        private readonly Dictionary<Type, Type> values = new();
        public void Add<TService, T>()
        {
            if(values.ContainsKey(typeof(TService)))
            {
                values[typeof(TService)] = typeof(T);
            }
            else
            {
                values.Add(typeof(TService), typeof(T));
            }
        }
        public TService Create<TService>()
        {
            if(Activator.CreateInstance(values[typeof(TService)]) is TService service)
            {
                return service;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
