//using ECommerce2.Data.Common;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Unity;
//using Unity.Lifetime;
//using WebApplication2.DataEF;
//using WebApplication2.DataEF.Repositories;
//using WebApplication2.Unity;

//namespace WebApplication2.App_Start
//{
//    public static class UnityConfig2
//    {
//        public static void RegisterComponents()
//        {
//            var container = new UnityContainer();

//            DependencyResolver.SetResolver(new UnityDependencyResolver(container, DependencyResolver.Current));
//            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));

//            RegisterDataStorages(container);

//        }

//        private static void RegisterDataStorages(UnityContainer container)
//        {
//            var dbService = new DatabaseService();

//            //container.RegisterInstance<IRepository<Customer>>(dbService.CustomerRepository, new ExternallyControlledLifetimeManager());
//            //container.RegisterInstance<IRepository<Order>>(dbService.OrderRepository, new ExternallyControlledLifetimeManager());
//            //container.RegisterInstance<IRepository<Product>>(dbService.ProductRepository, new ExternallyControlledLifetimeManager());
//            //container.RegisterInstance<IRepository<ProductCategory>>(dbService.ProductCategoryRepository, new ExternallyControlledLifetimeManager());

//            //container.RegisterInstance<IDatabaseService>(dbService, new ExternallyControlledLifetimeManager());
//            container.RegisterType<IRepository<Product>, ProductRepository>();
//            container.RegisterType<IRepository<ProductCategory>, ProductCategoryRepository>();

//            container.RegisterInstance<IDatabaseService>(dbService, new ExternallyControlledLifetimeManager());

//            var t = container.Resolve<IDatabaseService>();
//        }
//    }
//}