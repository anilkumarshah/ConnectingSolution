using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace QRCode
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
           

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // this i added
            config.Routes.MapHttpRoute(
                name: "ActionData",
                routeTemplate: "api/{controller}/{action}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );
            //config.Routes.MapHttpRoute(
            //    name: "Post",
            //    routeTemplate: "api/{controller}/{action}/",
            //     defaults: new { controller= "BusinessAPII", action= "Post" }
            // );
            config.Routes.MapHttpRoute(
                name: "PostingData",
                routeTemplate: "api/{controller}/{action}/"
             );
        }
    }
}
