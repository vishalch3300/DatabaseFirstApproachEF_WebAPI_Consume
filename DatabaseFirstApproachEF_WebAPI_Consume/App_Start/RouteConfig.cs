using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DatabaseFirstApproachEF_WebAPI_Consume
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                //defaults: new { controller = "CrudMvc", action = "Index", id = UrlParameter.Optional }
                defaults: new { controller = "CrudMvcNew", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
