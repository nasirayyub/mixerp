using System;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Serilog;

namespace MixERP.Net.FrontEnd.Application
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            Log.Information("Registering Web API.");
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("VersionedApi", "api/v1.5/{schema}/{controller}/{action}/{id}", new { id = RouteParameter.Optional });
            config.Routes.MapHttpRoute("DefaultApi", "api/{schema}/{controller}/{action}/{id}", new { id = RouteParameter.Optional });

            config.Services.Replace(typeof(IAssembliesResolver), new MixERPAssemblyResolver());

            config.EnsureInitialized();
        }
    }
}