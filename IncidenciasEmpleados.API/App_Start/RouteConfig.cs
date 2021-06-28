using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IncidenciasEmpleados.API
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            "HelpPage",
            "",
            new { controller = "Help", action = "Index" }
        ).DataTokens = new RouteValueDictionary(new { area = "HelpPage" });

            routes.MapRoute(
                name: "getIncidenciasEmpleado",
                url: "{controller}/getIncidenciasEmpleado/{id}",
                defaults: new { controller = "IncidenciasApi", action = "GetIncidenciasEmpleado", id = UrlParameter.Optional }
            );
        }
    }
}
