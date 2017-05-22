using System.Web.Mvc;
using System.Web.Routing;

namespace WebshopASP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Products",
                url: "Products",
                defaults: new { controller = "Product", action = "Index" }
            );

            routes.MapRoute(
              name: "Product",
             url: "Product/{id}",
             defaults: new { controller = "Product", action = "Product", id = UrlParameter.Optional }
            );

            routes.MapRoute(
name: "Account/Settings",
url: "Account/Settings",
defaults: new { controller = "Account", action = "Settings" }
);

            routes.MapRoute(
name: "Account/Orders",
url: "Account/Orders",
defaults: new { controller = "Account", action = "Orders" }
);

            routes.MapRoute(
name: "LoginPost",
url: "Auth/Post",
defaults: new { controller = "Auth", action = "LoginPost" }
);

            routes.MapRoute(
  name: "Login",
 url: "Login",
 defaults: new { controller = "Auth", action = "Login", loginResult = UrlParameter.Optional }
);

            routes.MapRoute(
name: "Register",
url: "Register",
defaults: new { controller = "Auth", action = "Register" }
);

            routes.MapRoute(
name: "Logout",
url: "Logout",
defaults: new { controller = "Auth", action = "Logout" }
);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}