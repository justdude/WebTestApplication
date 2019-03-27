using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Unity;

namespace WebApplication2.Unity
{
    internal class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer container;
        private IDependencyResolver resolver;

        public UnityDependencyResolver(IUnityContainer container, IDependencyResolver resolver)
        {
            this.container = container;
            this.resolver = resolver;
        }

        #region UnityDependencyResolver

        public object GetService(Type serviceType)
        {
            try
            {
                return this.container.Resolve(serviceType);
            }
            catch
            {
                return this.resolver.GetService(serviceType);
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.container.ResolveAll(serviceType);
            }
            catch
            {
                return this.resolver.GetServices(serviceType);
            }
        }

        #endregion UnityDependencyResolver

        #region Additional

        public Type GetService<Type>()
        {
            return container.Resolve<Type>();
        }

        #endregion Additional
    }
}