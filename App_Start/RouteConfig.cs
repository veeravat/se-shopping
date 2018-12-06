using System.Web.Mvc;
using System.Web.Routing;

namespace ShoppingModule
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Home", action = "Login" }
            );
            routes.MapRoute(
                name: "Cart",
                url: "cart",
                defaults: new { controller = "Shop", action = "getCart" }
            );
            
            routes.MapRoute(
                name: "register",
                url: "register",
                defaults: new { controller = "Member", action = "Register" }
            );
            routes.MapRoute(
                name: "logout",
                url: "logout",
                defaults: new { controller = "Member", action = "Logout" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
