using System;
using ECommerce2.Data.Common;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using WebApplication2.DataEF;
using WebApplication2.DataEF.Repositories;

namespace WebApplication2
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            var uow = new DatabaseUoW();

            container.RegisterType<IRepository<Citye>, CityRepository>(new InjectionConstructor(uow));
            container.RegisterType<IRepository<Countrye>, CountryRepository>(new InjectionConstructor(uow));
            container.RegisterType<IRepository<ProductCategory>, ProductCategoryRepository>(new InjectionConstructor(uow));
            container.RegisterType<IRepository<Product>, ProductRepository>(new InjectionConstructor(uow));
            container.RegisterType<IRepository<Customer>, CustomerRepository>(new InjectionConstructor(uow));
            container.RegisterType<IRepository<Order>, OrderRepository>(new InjectionConstructor(uow));

            //container.RegisterInstance<IRepository<Customer>>(dbService.CustomerRepository, new ExternallyControlledLifetimeManager());
            //container.RegisterInstance<IDatabaseService>(dbService, new ExternallyControlledLifetimeManager());
        }
    }
}