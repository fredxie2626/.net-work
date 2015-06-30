using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Asn2_GoodSam
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "GET,POST,PUT,DELETE");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //  name: "actionApiByName",
            //  routeTemplate: "api/{controller}/{action}/{workerName}",
            //  defaults: new { action = "GetClientsWithAssignedWorker", workerName = RouteParameter.Optional }
            //  );
			
            //config.Routes.MapHttpRoute(
            //    name: "ActionApi",
            //    routeTemplate: "api/{controller}/{action}/{status}/{workerName}",
            //    defaults: new { action = "GetClientNum", status = RouteParameter.Optional, workerName = RouteParameter.Optional }
            //);

            var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented; 
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
