using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUl
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",

                /* указываем инфраструктуре  MVC framework, чтобы она отправляла запросы поступающие 
                  для корневого URL приложения методу List() класса AutosController*/
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
 
            );
        }
    }
}
