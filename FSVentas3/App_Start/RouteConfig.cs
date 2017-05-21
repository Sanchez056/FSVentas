using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FSVentas3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

             routes.MapRoute(
               "CiudadList",
               "Home/Municipios/List/{codigo}",
               new { controller = "Home", action = "MunicipioList", codigo = "" }

               );
            routes.MapRoute(
              "CiudadesList",
              "Home/Ciudad/List",
              new { controller = "Home", action = "CiudadesList"}

              );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
