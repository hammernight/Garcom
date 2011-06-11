﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Garcom.Models;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace Garcom
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) { filters.Add(new HandleErrorAttribute()); }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                "MenuItemsInsidePlaces",
                "places/{placeId}/menuItems",
                new {controller = "places", action = "addMenuItem"});

            routes.MapRoute(
                "Default",
                // Route name
                "{controller}/{action}/{id}",
                // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            var container = new UnityContainer();

            container.RegisterType<MongoWrapper>(new HierarchicalLifetimeManager());
            container.RegisterControllers();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}