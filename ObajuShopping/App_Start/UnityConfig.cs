using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using ObajuShopping.Interfaces;
using ObajuShopping.Controllers;

namespace ObajuShopping
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICartService, CartVisitor>();
            container.RegisterType<ICartService, CartMember>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}