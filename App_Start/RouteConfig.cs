using System.Web.Mvc;
using System.Web.Routing;

namespace GrandLabFixers
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Service", id = UrlParameter.Optional }
           );
            //routes.MapRoute(
            //    name: "CreatQuote",
            //    url: "{ShoppingCart}/{new { id = productId }}/{id}",
            //    defaults: new { controller = "ShoppingCart", action = "CreatQuote", id = UrlParameter.Optional }
            //);


        }
    }
}
