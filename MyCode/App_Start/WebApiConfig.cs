using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using MyCode.Helper;
using Mycode.Helper;

namespace MyCode
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);


            config.Services.Replace(typeof(IExceptionHandler), new MyExceptionHandler());
            config.MessageHandlers.Add(new LoggingHandler());

        }
    }
}
