using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*botdetect}",new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
            routes.MapRoute(
               name: "trang chu",
               url: "trang-chu",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "GUI_OnlineShop.Controllers" }
           );
            routes.MapRoute(
               name: "san pham",
               url: "san-pham",
               defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "GUI_OnlineShop.Controllers" }
           );
           
            routes.MapRoute(
               name: "chi tiet san pham",
               url: "san-pham/{SeoLink}-{id}",
               defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
               namespaces: new[] { "GUI_OnlineShop.Controllers" }
           );
            routes.MapRoute(
              name: "gio hang",
              url: "gio-hang",
              defaults: new { controller = "ShoppingCard", action = "viewCard", id = UrlParameter.Optional },
              namespaces: new[] { "GUI_OnlineShop.Controllers" }
          );
            routes.MapRoute(
              name: "lien he",
              url: "lien-he",
              defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "GUI_OnlineShop.Controllers" }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
