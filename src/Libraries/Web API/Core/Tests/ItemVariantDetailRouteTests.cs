// ReSharper disable All
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Xunit;

namespace MixERP.Net.Api.Core.Tests
{
    public class ItemVariantDetailRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/delete/{itemVariantDetailId}", "DELETE", typeof(ItemVariantDetailController), "Delete")]
        [InlineData("/api/core/item-variant-detail/delete/{itemVariantDetailId}", "DELETE", typeof(ItemVariantDetailController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/edit/{itemVariantDetailId}", "PUT", typeof(ItemVariantDetailController), "Edit")]
        [InlineData("/api/core/item-variant-detail/edit/{itemVariantDetailId}", "PUT", typeof(ItemVariantDetailController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/count-where", "POST", typeof(ItemVariantDetailController), "CountWhere")]
        [InlineData("/api/core/item-variant-detail/count-where", "POST", typeof(ItemVariantDetailController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/get-where/{pageNumber}", "POST", typeof(ItemVariantDetailController), "GetWhere")]
        [InlineData("/api/core/item-variant-detail/get-where/{pageNumber}", "POST", typeof(ItemVariantDetailController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/add-or-edit", "POST", typeof(ItemVariantDetailController), "AddOrEdit")]
        [InlineData("/api/core/item-variant-detail/add-or-edit", "POST", typeof(ItemVariantDetailController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/add/{itemVariantDetail}", "POST", typeof(ItemVariantDetailController), "Add")]
        [InlineData("/api/core/item-variant-detail/add/{itemVariantDetail}", "POST", typeof(ItemVariantDetailController), "Add")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/bulk-import", "POST", typeof(ItemVariantDetailController), "BulkImport")]
        [InlineData("/api/core/item-variant-detail/bulk-import", "POST", typeof(ItemVariantDetailController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/meta", "GET", typeof(ItemVariantDetailController), "GetEntityView")]
        [InlineData("/api/core/item-variant-detail/meta", "GET", typeof(ItemVariantDetailController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/count", "GET", typeof(ItemVariantDetailController), "Count")]
        [InlineData("/api/core/item-variant-detail/count", "GET", typeof(ItemVariantDetailController), "Count")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/all", "GET", typeof(ItemVariantDetailController), "GetAll")]
        [InlineData("/api/core/item-variant-detail/all", "GET", typeof(ItemVariantDetailController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/export", "GET", typeof(ItemVariantDetailController), "Export")]
        [InlineData("/api/core/item-variant-detail/export", "GET", typeof(ItemVariantDetailController), "Export")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/1", "GET", typeof(ItemVariantDetailController), "Get")]
        [InlineData("/api/core/item-variant-detail/1", "GET", typeof(ItemVariantDetailController), "Get")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/get?itemVariantDetailIds=1", "GET", typeof(ItemVariantDetailController), "Get")]
        [InlineData("/api/core/item-variant-detail/get?itemVariantDetailIds=1", "GET", typeof(ItemVariantDetailController), "Get")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail", "GET", typeof(ItemVariantDetailController), "GetPaginatedResult")]
        [InlineData("/api/core/item-variant-detail", "GET", typeof(ItemVariantDetailController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/page/1", "GET", typeof(ItemVariantDetailController), "GetPaginatedResult")]
        [InlineData("/api/core/item-variant-detail/page/1", "GET", typeof(ItemVariantDetailController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/count-filtered/{filterName}", "GET", typeof(ItemVariantDetailController), "CountFiltered")]
        [InlineData("/api/core/item-variant-detail/count-filtered/{filterName}", "GET", typeof(ItemVariantDetailController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/get-filtered/{pageNumber}/{filterName}", "GET", typeof(ItemVariantDetailController), "GetFiltered")]
        [InlineData("/api/core/item-variant-detail/get-filtered/{pageNumber}/{filterName}", "GET", typeof(ItemVariantDetailController), "GetFiltered")]

        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/custom-fields", "GET", typeof(ItemVariantDetailController), "GetCustomFields")]
        [InlineData("/api/core/item-variant-detail/custom-fields", "GET", typeof(ItemVariantDetailController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/custom-fields/{resourceId}", "GET", typeof(ItemVariantDetailController), "GetCustomFields")]
        [InlineData("/api/core/item-variant-detail/custom-fields/{resourceId}", "GET", typeof(ItemVariantDetailController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/meta", "HEAD", typeof(ItemVariantDetailController), "GetEntityView")]
        [InlineData("/api/core/item-variant-detail/meta", "HEAD", typeof(ItemVariantDetailController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/count", "HEAD", typeof(ItemVariantDetailController), "Count")]
        [InlineData("/api/core/item-variant-detail/count", "HEAD", typeof(ItemVariantDetailController), "Count")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/all", "HEAD", typeof(ItemVariantDetailController), "GetAll")]
        [InlineData("/api/core/item-variant-detail/all", "HEAD", typeof(ItemVariantDetailController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/export", "HEAD", typeof(ItemVariantDetailController), "Export")]
        [InlineData("/api/core/item-variant-detail/export", "HEAD", typeof(ItemVariantDetailController), "Export")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/1", "HEAD", typeof(ItemVariantDetailController), "Get")]
        [InlineData("/api/core/item-variant-detail/1", "HEAD", typeof(ItemVariantDetailController), "Get")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/get?itemVariantDetailIds=1", "HEAD", typeof(ItemVariantDetailController), "Get")]
        [InlineData("/api/core/item-variant-detail/get?itemVariantDetailIds=1", "HEAD", typeof(ItemVariantDetailController), "Get")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail", "HEAD", typeof(ItemVariantDetailController), "GetPaginatedResult")]
        [InlineData("/api/core/item-variant-detail", "HEAD", typeof(ItemVariantDetailController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/page/1", "HEAD", typeof(ItemVariantDetailController), "GetPaginatedResult")]
        [InlineData("/api/core/item-variant-detail/page/1", "HEAD", typeof(ItemVariantDetailController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/count-filtered/{filterName}", "HEAD", typeof(ItemVariantDetailController), "CountFiltered")]
        [InlineData("/api/core/item-variant-detail/count-filtered/{filterName}", "HEAD", typeof(ItemVariantDetailController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(ItemVariantDetailController), "GetFiltered")]
        [InlineData("/api/core/item-variant-detail/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(ItemVariantDetailController), "GetFiltered")]

        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/custom-fields", "HEAD", typeof(ItemVariantDetailController), "GetCustomFields")]
        [InlineData("/api/core/item-variant-detail/custom-fields", "HEAD", typeof(ItemVariantDetailController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/core/item-variant-detail/custom-fields/{resourceId}", "HEAD", typeof(ItemVariantDetailController), "GetCustomFields")]
        [InlineData("/api/core/item-variant-detail/custom-fields/{resourceId}", "HEAD", typeof(ItemVariantDetailController), "GetCustomFields")]

        [Conditional("Debug")]
        public void TestRoute(string url, string verb, Type type, string actionName)
        {
            //Arrange
            url = url.Replace("{apiVersionNumber}", this.ApiVersionNumber);
            url = Host + url;

            //Act
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(verb), url);

            IHttpControllerSelector controller = this.GetControllerSelector();
            IHttpActionSelector action = this.GetActionSelector();

            IHttpRouteData route = this.Config.Routes.GetRouteData(request);
            request.Properties[HttpPropertyKeys.HttpRouteDataKey] = route;
            request.Properties[HttpPropertyKeys.HttpConfigurationKey] = this.Config;

            HttpControllerDescriptor controllerDescriptor = controller.SelectController(request);

            HttpControllerContext context = new HttpControllerContext(this.Config, route, request)
            {
                ControllerDescriptor = controllerDescriptor
            };

            var actionDescriptor = action.SelectAction(context);

            //Assert
            Assert.NotNull(controllerDescriptor);
            Assert.NotNull(actionDescriptor);
            Assert.Equal(type, controllerDescriptor.ControllerType);
            Assert.Equal(actionName, actionDescriptor.ActionName);
        }

        #region Fixture
        private readonly HttpConfiguration Config;
        private readonly string Host;
        private readonly string ApiVersionNumber;

        public ItemVariantDetailRouteTests()
        {
            this.Host = ConfigurationManager.AppSettings["HostPrefix"];
            this.ApiVersionNumber = ConfigurationManager.AppSettings["ApiVersionNumber"];
            this.Config = GetConfig();
        }

        private HttpConfiguration GetConfig()
        {
            if (MemoryCache.Default["Config"] == null)
            {
                HttpConfiguration config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();
                config.Routes.MapHttpRoute("VersionedApi", "api/" + this.ApiVersionNumber + "/{schema}/{controller}/{action}/{id}", new { id = RouteParameter.Optional });
                config.Routes.MapHttpRoute("DefaultApi", "api/{schema}/{controller}/{action}/{id}", new { id = RouteParameter.Optional });

                config.EnsureInitialized();
                MemoryCache.Default["Config"] = config;
                return config;
            }

            return MemoryCache.Default["Config"] as HttpConfiguration;
        }

        private IHttpControllerSelector GetControllerSelector()
        {
            if (MemoryCache.Default["ControllerSelector"] == null)
            {
                IHttpControllerSelector selector = this.Config.Services.GetHttpControllerSelector();
                return selector;
            }

            return MemoryCache.Default["ControllerSelector"] as IHttpControllerSelector;
        }

        private IHttpActionSelector GetActionSelector()
        {
            if (MemoryCache.Default["ActionSelector"] == null)
            {
                IHttpActionSelector selector = this.Config.Services.GetActionSelector();
                return selector;
            }

            return MemoryCache.Default["ActionSelector"] as IHttpActionSelector;
        }
        #endregion
    }
}