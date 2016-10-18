using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BusinessServices;
using webapi.config.DependencyInjection;

namespace webapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            AutoMapperConfig.CreateMaps();
            StructureDIResolver.RegisterDependencyResolver(config);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
