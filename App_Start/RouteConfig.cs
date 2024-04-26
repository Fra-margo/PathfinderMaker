using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pathfinder
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "GuidaDownloadPdf",
            url: "Guida/DownloadPdf",
            defaults: new { controller = "Guida", action = "DownloadPdf" }
            );

            routes.MapRoute(
            name:"PersonaggiDownloadPdf",
            url: "Personaggi/DownloadPdf",
            defaults: new { controller = "Personaggi", action = "DownloadPdf" }
            );

        }
    }
}
