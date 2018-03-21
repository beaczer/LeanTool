﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarLotMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Create",
                url: "{par1}/{par}",
                defaults: new { controller = "Home", action = "Create", id = UrlParameter.Optional }

            );
            routes.MapRoute(
                name: "Parametry",
                url: "{par1}/{par}",
                defaults: new { controller = "Home", action = "Parametry", id = UrlParameter.Optional }
                
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            

        }
    }
}
