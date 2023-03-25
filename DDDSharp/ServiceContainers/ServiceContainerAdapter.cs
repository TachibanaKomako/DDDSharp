using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSharp.ServiceContainers
{
    internal class ServiceContainerAdapter : IServiceContainer, IServiceContainerBuilder
    {
        /// <summary>
        /// サービスを作成するためのデータ
        /// </summary>
        private readonly ServiceFactory serviceFactory = new();
        private readonly Dictionary<Type, object> services = new();
        public void AddService<TService, T>() where T : TService
        {
            serviceFactory.Add<TService, T>();
        }

        public T CreateService<T>() where T : notnull
        {
            return serviceFactory.Create<T>();
        }

        public T GetService<T>() 
            where T : notnull
        {
            if (services.ContainsKey(typeof(T)) is false)
            {
                T service = CreateService<T>();
                services.Add(typeof(T), service);

            }
            return (T)services[typeof(T)];
        }
    }
}
