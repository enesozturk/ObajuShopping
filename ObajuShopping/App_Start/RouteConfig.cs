using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ObajuShopping
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AdminDefault",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ObajuShopping.Admin.Controller" }
                );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ObajuShopping.Controllers" }
            );


            routes.MapRoute(
               name: "updatebasket",
               url: "{controller}/{action}/{id}/{quantity}",
               defaults: new { controller = "Cart", action = "UpdateBasket", id = UrlParameter.Optional, quantity = "" }
           );

        }
    }
}
